using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using RockPaperScissor.Data;
using System;
using System.Text.RegularExpressions;

namespace RockPaperScissor.Market
{
    public class TradeMethod : _TemplateDealClass
    {
        protected override bool EntryDataConditionsIsOk(CommandContext ctx, DiscordMember member, int firstCardID, int secondCardID)
        {
            return
            (
                PlayerHasTheCardId(ctx.Member, firstCardID) &&
                PlayerHasTheCardId(member, secondCardID)
            );
        }

        protected override string GetDealMessageContent(CommandContext ctx, DiscordMember member, int firstCardID, int secondCardID)
        {
            String firstData = AllGameData.GetMemberDeck(ctx.Member).GetCardById(firstCardID).ToString();
            String secondData = AllGameData.GetMemberDeck(member).GetCardById(secondCardID).ToString();
            return OrganizeMessageContent(new[] { firstData, secondData }, ctx.Member);
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
