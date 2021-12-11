using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using RockPaperScissor.Data;
using RockPaperScissor.Util;
using RockPaperScissor.Duel.Fases.BaseAbstract;

namespace RockPaperScissor.Duel.Fases.CardReq
{
    public abstract class _CardRequisition : _StepTemplatePattern
    {
        public _CardRequisition(CommandContext ctx, DuelStatus duelStatus) : base(ctx, duelStatus) { }

        public override async Task DoTheStep()
        {
            if (!duelStatus.GetGameContinue()) return;

            await ctx.Channel.SendMessageAsync(GetRequestCardMessage());
            await ctx.Channel.SendMessageAsync(GetCurretDuelDeck());
            var interativity = ctx.Client.GetInteractivity();

            var result = await interativity.WaitForMessageAsync(
                m => m.Channel == ctx.Channel && m.Author == GetCurrentPlayer()
            ).ConfigureAwait(false);


            if (!result.TimedOut)
            {
                if (TryGetTheCards(result.Result.Content))
                {
                    if (!CardWasAlreadyUsed(result.Result.Content))
                    {
                        if (NeedToMarkCardAsUsed()) MarkCard(result.Result.Content);
                        return;
                    }
                }
            }

            await ConsiderateNewError();
            await DoTheStep();
        }




        protected virtual String GetCurretDuelDeck()
        {
            return MyUtilities.GetDuelDeckCardsString(
                GetCurrentPlayer().Id,
                duelStatus.GetDuelDeckIndexList()[GetCurrentPlayerIndex()],
                duelStatus.GetUsedCardsIdFromDuelist()[GetCurrentPlayerIndex()].ToArray()
            );
        }


        protected bool IndexIsInDuelDeck(int index)
        {
            if  (AllGameData.GetMemberDeck(GetCurrentPlayer()
                ).GetDuelDeck(duelStatus.GetDuelDeckIndexList()[GetCurrentPlayerIndex()]
                ).Contains(index))
            {
                return true;
            }
            return false;
        }


        protected bool CardWasAlreadyUsed(String content)
        {
            int[] cards = GetEnteredCards(content);

            foreach(int card in cards)
            {
                if (duelStatus.GetUsedCardsIdFromDuelist()[GetCurrentPlayerIndex()].Contains(card))
                    return true;
            }

            return false;
        }


        protected void MarkCard(String content)
        {
            int[] cards = GetEnteredCards(content);
            foreach(int card in cards)
                duelStatus.AddAnUsedCardsIdFromDuelist(GetCurrentPlayerIndex(), card);
        }


        protected abstract bool TryGetTheCards(String message);
        protected abstract String GetRequestCardMessage();
        protected abstract bool NeedToMarkCardAsUsed();
        protected abstract String GetSeparationRule();



        protected int[] GetEnteredCards(String content)
        {
            int index = GetCurrentPlayerIndex();
            return Array.ConvertAll(content.Split(GetSeparationRule()), s => int.Parse(s));
        }
    }
}
