using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using RockPaperScissor.Util;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using RockPaperScissor.Text;

namespace RockPaperScissor.Market
{
    public abstract class _TemplateDealClass
    {
        public async Task MakeCardDeal(CommandContext ctx, DiscordMember member, int firstInt, int secondInt)
        {
            if (!await ConditionsAreOk(ctx, member, firstInt, secondInt)) return;

            await ctx.Channel.SendMessageAsync(MyUtilities.GetMessager(ctx).DealSent());
            bool proposeAcepted = await SendOfferToSecond(ctx, member, firstInt, secondInt);

            await ConsidereResultOfDeal(proposeAcepted, ctx, member, firstInt, secondInt);
        }




        protected async Task<bool> ConditionsAreOk(CommandContext ctx, DiscordMember member, int firstInt, int secondInt)
        {
            if (!await ConditionsDiscordInterface.PlayerIsCardMaster(ctx, member)) return false;

            if (!await ConditionsDiscordInterface.IsNotTheSameMember(ctx, ctx.Member, member)) return false;

            if (!EntryDataConditionsIsOk(ctx, member, firstInt, secondInt))
            {
                await ctx.Channel.SendMessageAsync(MyUtilities.GetMessager(ctx).ChooseWrongIndexOrBlockedCard());
                return false;
            }

            return true;
        }


        protected async Task<bool> SendOfferToSecond(CommandContext ctx, DiscordMember member, int firstCardID, int secondCardID)
        {
            String messageContent = GetDealMessageContent(ctx, member, firstCardID, secondCardID);
            await member.SendMessageAsync(messageContent);
            var message = await member.SendMessageAsync($"\n **{MyUtilities.GetMessager(ctx).EmojiDealReaction()}**");

            var result = await message.WaitForReactionAsync(member);
            if (!result.TimedOut) return true;
            else return false;
        }


        protected async Task ConsidereResultOfDeal(bool proposeAcepted, CommandContext ctx, DiscordMember member, int firstInt, int secondInt)
        {
            String subjectOfMessage;
            if (proposeAcepted)
            {
                MakeTheDeal(ctx.Member, member, firstInt, secondInt);
                subjectOfMessage = MyUtilities.GetMessager(ctx).DealAccepted();
            }
            else
            {
                subjectOfMessage = MyUtilities.GetMessager(ctx).DealDeclined();
            }

            await ctx.Channel.SendMessageAsync
            (
                $"{ctx.Member.Nickname}... {member.Nickname} {subjectOfMessage}"
            );
        }



        protected abstract bool EntryDataConditionsIsOk(CommandContext ctx, DiscordMember member, int firstInt, int secondInt);

        protected abstract void MakeTheDeal(DiscordMember firstMember, DiscordMember secondMember, int firstCardID, int secondCardID);

        protected abstract String GetDealMessageContent(CommandContext ctx, DiscordMember member, int firstCardID, int secondCardID);


        protected bool PlayerHasTheCardId(DiscordMember member, int cardID) { return MyConditions.PlayerHasTheCardId(member, cardID); }
        protected bool PlayerHasTheCoins(DiscordMember member, int coinsQuant) { return MyConditions.PlayerHasTheCoins(member, coinsQuant); }
        protected bool CardInADuelDeck(DiscordMember member, int cardID) { return MyConditions.CardInADuelDeck(member, cardID); }

    }
}
