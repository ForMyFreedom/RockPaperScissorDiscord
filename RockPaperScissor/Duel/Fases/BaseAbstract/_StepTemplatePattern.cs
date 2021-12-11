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
using RockPaperScissor.Duel.Fases;

namespace RockPaperScissor.Duel.Fases.BaseAbstract
{
    public abstract class _StepTemplatePattern
    {
        protected CommandContext ctx;
        protected DuelStatus duelStatus;

        public _StepTemplatePattern(CommandContext ctx, DuelStatus duelStatus)
        {
            this.ctx = ctx;
            this.duelStatus = duelStatus;
        }



        public virtual async Task DoTheStep()
        {
            await Task.CompletedTask;
        }


        protected abstract DiscordMember GetCurrentPlayer();
        protected int GetCurrentPlayerIndex() { return duelStatus.GetPlayerIndex(GetCurrentPlayer()); }


        protected async Task ConsiderateNewError()
        {
            int currentPlayerIndex = GetCurrentPlayerIndex();

            duelStatus.amountOfErrorsFromPlayers[currentPlayerIndex] += 1;

            if (duelStatus.amountOfErrorsFromPlayers[currentPlayerIndex] == 2)
            {
                await ctx.Channel.SendMessageAsync("Você perdeu o duelo por exesso de erros");
                duelStatus.SetGameContinue(false);
                duelStatus.SetGameWinnerIndex(1 - currentPlayerIndex);
                return;
            }

            await ctx.Channel.SendMessageAsync("Você tem mais uma chance antes de perder o duelo...");
        }
    }
}
