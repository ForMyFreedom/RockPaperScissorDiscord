using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using RockPaperScissor.Data;
using RockPaperScissor.Util;
using System;

namespace RockPaperScissor.Market
{
    public class TradeMethod : _TemplateDealClass
    {
        protected override bool EntryDataConditionsIsOk(CommandContext ctx, DiscordMember member, int firstCardID, int secondCardID)
        {
            return
            (
                PlayerHasTheCardId(ctx.Member, firstCardID) &&
                !CardInADuelDeck(ctx.Member, firstCardID) &&
                PlayerHasTheCardId(member, secondCardID) &&
                !CardInADuelDeck(member, secondCardID)
            );
        }

        protected override string GetDealMessageContent(CommandContext ctx, DiscordMember member, int firstCardID, int secondCardID)
        {
            String firstData = AllGameData.GetMemberDeck(member).GetCardById(secondCardID).ToString();
            String secondData = AllGameData.GetMemberDeck(ctx.Member).GetCardById(firstCardID).ToString();
            return MyUtilities.GetFormatText(MyUtilities.GetMessager(member).DealMessageTemplate(), new[] { ctx.Member.Nickname, firstData, secondData });
        }


        protected override void MakeTheDeal(DiscordMember firstMember, DiscordMember secondMember, int firstCardID, int secondCardID)
        {
            Card firstCard = AllGameData.GetMemberDeck(firstMember).GetCardById(firstCardID);
            Card secondCard = AllGameData.GetMemberDeck(secondMember).GetCardById(secondCardID);

            AllGameData.AddNewCard(firstMember, secondCard.GetElements(), secondCard.GetStars(), secondCard.GetName());
            AllGameData.GetMemberDeck(firstMember).RemoveCard(firstCardID);

            AllGameData.AddNewCard(secondMember, firstCard.GetElements(), firstCard.GetStars(), firstCard.GetName());
            AllGameData.GetMemberDeck(secondMember).RemoveCard(secondCardID);
        }


    }
}
