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
    public class DefenseFase : _FaseTemplatePattern
    {
        public DefenseFase(CommandContext ctx, DuelStatus duelStatus) : base(ctx, duelStatus)
        {
            steps = new _StepTemplatePattern[2] {
                new CardReq.DefenseCardRequisition(ctx,duelStatus),
                new ElementReq.DefenseElementRequisition(ctx,duelStatus),
            };
        }

    }
}
