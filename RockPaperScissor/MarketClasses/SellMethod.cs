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
            String nameCard = AllGameData.GetMemberDeck(ctx.Member).GetCardById(cardID).ToString();
            String messageContent = $"{ctx.Member.Nickname} lhe propõe a troca: \n {coinsQuant} ℳ \n pela {nameCard} que ele possui";
            return messageContent;
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
