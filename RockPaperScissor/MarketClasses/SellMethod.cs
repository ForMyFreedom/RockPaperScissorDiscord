using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using RockPaperScissor.Data;
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
                PlayerHasTheCoins(member, coinsQuant)
            );
        }


        protected override string GetDealMessageContent(CommandContext ctx, DiscordMember member, int cardID, int coinsQuant)
        {
            String firstData = coinsQuant.ToString();
            String secondData = AllGameData.GetMemberDeck(ctx.Member).GetCardById(cardID).ToString();
            return OrganizeMessageContent(new[] { firstData, secondData }, ctx.Member);
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
