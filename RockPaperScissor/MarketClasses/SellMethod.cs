using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using RockPaperScissor.Data;
using RockPaperScissor.Util;
using System;

namespace RockPaperScissor.Market
{
    public class SellMethod : _TemplateDealClass
    {
        protected override bool EntryDataConditionsIsOk(CommandContext ctx, DiscordMember member, int cardID, int coinsQuant)
        {
            return
            (
                PlayerHasTheCardId(ctx.Member, cardID) &&
                !CardInADuelDeck(ctx.Member, cardID) &&
                PlayerHasTheCoins(member, coinsQuant)
            );
        }


        protected override string GetDealMessageContent(CommandContext ctx, DiscordMember member, int cardID, int coinsQuant)
        {
            String firstData = coinsQuant.ToString()+"ℳ";
            String secondData = AllGameData.GetMemberDeck(ctx.Member).GetCardById(cardID).ToString();
            return MyUtilities.GetFormatText(MyUtilities.GetMessager(ctx).DealMessageTemplate(), new[] { ctx.Member.Nickname, firstData, secondData });
        }


        protected override void MakeTheDeal(DiscordMember firstMember, DiscordMember secondMember, int cardID, int coinsQuant)
        {
            Card card = AllGameData.GetMemberDeck(firstMember).GetCardById(cardID);
            AllGameData.AddNewCard(secondMember, card.GetElements(), card.GetStars(), card.GetName());

            AllGameData.GetMemberDeck(firstMember).RemoveCard(cardID);
            AllGameData.MakeTransference(secondMember, firstMember, coinsQuant);
        }


    }
}
