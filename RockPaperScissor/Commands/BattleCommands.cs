using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using DSharpPlus.Interactivity.Extensions;
using RockPaperScissor.Duel;
using RockPaperScissor.Data;
using RockPaperScissor.Util;

namespace RockPaperScissor.Commands
{
    public class BattleCommands : Util.MyBaseModule
    {

        [Command("make_duel")]
        [RequireRoles(RoleCheckMode.All, new[] { AllGameData.NAME_OF_ROLE })]
        public async Task MakeDuelGame(CommandContext ctx, DiscordMember member, int duelDeckIndex)
        {
            await MakeDuelGame(ctx, member, duelDeckIndex, "");
        }



        [Command("make_duel")]
        [RequireRoles(RoleCheckMode.All, new[] {AllGameData.NAME_OF_ROLE})]
        public async Task MakeDuelGame(CommandContext ctx, DiscordMember member, int duelDeckIndex, String duelStyleStr)
        {
            DuelStatus duelStatus = new DuelStatus(duelStyleStr);
            if (! await StartGameConditionsAreOk(ctx, member, duelDeckIndex, duelStatus)) return;

            duelStatus.SetDuelDeckIndex(0, duelDeckIndex);
            duelStatus.SetOneCombatent(0, ctx.Member);

            await ctx.Channel.SendMessageAsync(GetMessager(ctx).DuelProposalSent());
            
            duelStatus = await WaitForChallengedMemberResponse(ctx, member, duelStatus);

            if (duelStatus != null)
                await DeterminePresence(ctx, duelStatus);
            else
                await ctx.Channel.SendMessageAsync(GetMessager(ctx).DuelCanceled());
        }




        private async Task<bool> StartGameConditionsAreOk(CommandContext ctx, DiscordMember member, int duelDeckIndex, DuelStatus duelStatus)
        {
            if (!await ConditionsDiscordInterface.PlayerIsCardMaster(ctx, member))  return false;
            if (!await ConditionsDiscordInterface.IsAdequatedDuelDeckToTheGameStyle(ctx, ctx.Member, duelDeckIndex, duelStatus)) return false;
            if (!await ConditionsDiscordInterface.PlayerHasTheCoins(ctx, ctx.Member, duelStatus.GetPremiumCoins())) return false;
            if (!await ConditionsDiscordInterface.PlayerHasTheCoins(ctx, member, duelStatus.GetPremiumCoins())) return false;
            if (!await ConditionsDiscordInterface.IsNotTheSameMember(ctx, ctx.Member, member)) return false;
            
            return true;
        }


        private async Task<DuelStatus> WaitForChallengedMemberResponse(CommandContext ctx, DiscordMember member, DuelStatus duelStatus)
        {
            await member.SendMessageAsync(GetMessager(member).YouAreConvoke() + $"'{ctx.Member.Nickname}'");
            await member.SendMessageAsync(GetMessager(member).DuelFollowsFormat());
            await member.SendMessageAsync(duelStatus.GetStyleToString(member));
            DiscordMessage message = await member.SendMessageAsync(GetMessager(member).RequestConfirmationOfDuel());


            var interativity = ctx.Client.GetInteractivity();
            var result = await interativity.WaitForMessageAsync
            (
                m => m.Channel == message.Channel && m.ReferencedMessage == message
            ).ConfigureAwait(false);

            if (result.TimedOut)
            {
                //@
                return null;
            }

            String response = result.Result.Content;

            if (
                MyUtilities.TryParse(response) &&
                await ConditionsDiscordInterface.IsAdequatedDuelDeckToTheGameStyle(
                    ctx, member, int.Parse(response), duelStatus)
                )
            {
                duelStatus.SetDuelDeckIndex(1, int.Parse(response));
                duelStatus.SetOneCombatent(1, member);
            } else
            {
                duelStatus.SetGameContinue(false);
            }

            return duelStatus;
        }



        private async Task DeterminePresence(CommandContext ctx, DuelStatus duelStatus)
        {
            if (duelStatus.GetGameContinue())
            {
                GameDuel gameDuel = new GameDuel(ctx, duelStatus);
                RegisterDuelInDecks(duelStatus);
                await gameDuel.StartGameDuel();
            }
            else
            {
                await ctx.Channel.SendMessageAsync(GetMessager(ctx).DuelCanceled());
            }
        }



        private void RegisterDuelInDecks(DuelStatus duelStatus)
        {
            foreach(DiscordMember combatent in duelStatus.GetCombatents())
            {
                AllGameData.GetMemberDeck(combatent).SetDueling(true);
            }
        }

    }
}
