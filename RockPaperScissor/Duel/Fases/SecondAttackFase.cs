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


namespace RockPaperScissor.Duel.Fases
{
    public class SecondAttackFase : _FaseTemplatePattern
    {
        public SecondAttackFase(CommandContext ctx, DuelStatus duelStatus) : base(ctx, duelStatus)
        {
            steps = new _StepTemplatePattern[] {
                new CardReq.SecondAttackCardRequisition(ctx,duelStatus),
                new ElementReq.AttackElementRequisition(ctx,duelStatus),
            };
        }


    }
}
