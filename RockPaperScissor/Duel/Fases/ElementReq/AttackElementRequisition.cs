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

namespace RockPaperScissor.Duel.Fases.ElementReq
{
    public class AttackElementRequisition : _ElementRequisition
    {
        public AttackElementRequisition(CommandContext ctx, DuelStatus duelStatus) : base(ctx, duelStatus) { }

        protected override DiscordMember GetCurrentPlayer()
        {
            return duelStatus.GetAttackPlayer();
        }

        protected override string GetRequestElementMessage()
        {
            return GetCurrentPlayer().Mention + " " + MyUtilities.GetMessager(GetCurrentPlayer()).ChooseAttackElement();
        }

        protected override void SetCurrentElement(int id)
        {
            duelStatus.SetAttackElement(id);
        }

    }
}
