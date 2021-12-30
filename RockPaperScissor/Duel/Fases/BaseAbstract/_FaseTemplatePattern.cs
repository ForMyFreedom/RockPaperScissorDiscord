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
    public abstract class _FaseTemplatePattern
    {
        protected CommandContext ctx;
        protected DuelStatus duelStatus;
        protected _StepTemplatePattern[] steps;

        public _FaseTemplatePattern(CommandContext ctx, DuelStatus duelStatus)
        {
            this.ctx = ctx;
            this.duelStatus = duelStatus;
        }


        public async Task DoTheFase()
        {
            foreach(_StepTemplatePattern step in steps)
            {
                await step.DoTheStep();
            }
        }
    }
}
