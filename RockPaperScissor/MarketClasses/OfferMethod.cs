using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using RockPaperScissor.Data;
using System;

namespace RockPaperScissor.Market
{
    public class OfferMethod : _TemplateDealClass
    {
        protected override bool EntryDataConditionsIsOk(CommandContext ctx, DiscordMember member, int cardID, int coinsQuant)
        {
            return
            (
                PlayerHasTheCoins(ctx.Member, coinsQuant) &&
                PlayerHasTheCardId(member, cardID)
            );
        }


        protected override string GetDealMessageContent(CommandContext ctx, DiscordMember member, int cardID, int coinsQuant)
        {
            String firstData = AllGameData.GetMemberDeck(member).GetCardById(cardID).ToString();
            String secondData = coinsQuant.ToString();
            return OrganizeMessageContent(new[] { firstData, secondData });
        }


        protected override void MakeTheDeal(DiscordMember firstMember, DiscordMember secondMember, int cardID, int coinsQuant)
        {
            Card card = AllGameData.GetMemberDeck(secondMember).GetCardById(cardID);
            AllGameData.AddNewCard(firstMember, card.GetElements(), card.GetStars(), card.GetName());

            AllGameData.GetMemberDeck(secondMember).RemoveCard(cardID);
            AllGameData.MakeTransference(firstMember, secondMember, coinsQuant);
        }


    }
}
