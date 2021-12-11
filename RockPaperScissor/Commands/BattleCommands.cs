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
    public class BattleCommands : BaseCommandModule
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

            await ctx.Channel.SendMessageAsync("Proposta de Duelo enviada!");
            try
            {
                duelStatus = await WaitForChallengedMemberResponse(ctx, member, duelStatus);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            await DeterminePresence(ctx, duelStatus);
        }




        private async Task<bool> StartGameConditionsAreOk(CommandContext ctx, DiscordMember member, int duelDeckIndex, DuelStatus duelStatus)
        {
            if (!await ConditionsDiscordInterface.PlayerIsCardMaster(ctx.Channel, member))  return false;
            if (!await ConditionsDiscordInterface.IsAdequatedDuelDeckToTheGameStyle(ctx.Channel, ctx.Member, duelDeckIndex, duelStatus)) return false;
            if (!await ConditionsDiscordInterface.PlayerHasTheCoins(ctx.Channel, ctx.Member, duelStatus.GetPremiumCoins())) return false;
            if (!await ConditionsDiscordInterface.PlayerHasTheCoins(ctx.Channel, member, duelStatus.GetPremiumCoins())) return false;
            if (!await ConditionsDiscordInterface.IsNotTheSameMember(ctx.Channel, ctx.Member, member)) return false;
            
            return true;
        }


        private async Task<DuelStatus> WaitForChallengedMemberResponse(CommandContext ctx, DiscordMember member, DuelStatus duelStatus)
        {
            await member.SendMessageAsync($"O Duelista '{ctx.Member.Nickname}' o convoca para um duelo com o seguinte formato:");
            await member.SendMessageAsync(duelStatus.GetStyleToString());
            DiscordMessage message = await member.SendMessageAsync("Responda (literalmente) essa mensagem com o Index de seu Deck de Duelo escolhido caso deseje batalhar");


            var interativity = ctx.Client.GetInteractivity();
            var result = await interativity.WaitForMessageAsync
            (
                m => m.Channel == message.Channel && m.ReferencedMessage == message
            ).ConfigureAwait(false);

            String response = result.Result.Content;

            if (
                MyUtilities.TryParse(response) &&
                await ConditionsDiscordInterface.IsAdequatedDuelDeckToTheGameStyle(
                    ctx.Channel, member, int.Parse(response), duelStatus)
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
                await gameDuel.StartGameDuel();
            }
            else
            {
                await ctx.Channel.SendMessageAsync("Infelizmente, o Duelo foi cancelado...");
            }
        }

    }
}
