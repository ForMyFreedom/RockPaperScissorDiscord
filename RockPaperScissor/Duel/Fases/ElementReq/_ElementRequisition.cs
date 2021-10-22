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

namespace RockPaperScissor.Duel.Fases.ElementReq
{
    public abstract class _ElementRequisition : _StepTemplatePattern
    {
        public _ElementRequisition(CommandContext ctx, DuelStatus duelStatus) : base(ctx, duelStatus) { }

        public override async Task DoTheStep()
        {
            if (!duelStatus.GetGameContinue()) return;

            await ctx.Channel.SendMessageAsync(GetRequestElementMessage());
            var interativity = ctx.Client.GetInteractivity();

            var result = await interativity.WaitForMessageAsync(
                m => m.Channel == ctx.Channel && m.Author == GetCurrentPlayer()
            ).ConfigureAwait(false);

            if (!result.TimedOut)
            {
                if (!TryGetTheElement(result.Result.Content))
                {
                    await ConsiderateNewError();
                    await DoTheStep();
                }
            }
            else
            {
                await ConsiderateNewError();
                await DoTheStep();
            }
        }


        protected bool TryGetTheElement(String message)
        {
            switch (message)
            {
                case "imp":
                    SetCurrentElement(0);
                    break;
                case "pre":
                    SetCurrentElement(1);
                    break;
                case "enc":
                    SetCurrentElement(2);
                    break;
                case "pod":
                    SetCurrentElement(3);
                    break;
                default:
                    return false;
            }
            return true;
        }







        protected abstract void SetCurrentElement(int id);
        protected abstract String GetRequestElementMessage();

    }
}
