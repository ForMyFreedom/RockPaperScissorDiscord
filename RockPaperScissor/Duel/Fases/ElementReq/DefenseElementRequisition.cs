using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using RockPaperScissor.Util;

namespace RockPaperScissor.Duel.Fases.ElementReq
{
    public class DefenseElementRequisition : _ElementRequisition
    {
        public DefenseElementRequisition(CommandContext ctx, DuelStatus duelStatus) : base(ctx, duelStatus) { }

        protected override DiscordMember GetCurrentPlayer()
        {
            return duelStatus.GetDefensePlayer();
        }

        protected override string GetRequestElementMessage()
        {
            return GetCurrentPlayer().Mention + " " + MyUtilities.GetMessager(GetCurrentPlayer()).ChooseDefenseElement();
        }

        protected override void SetCurrentElement(int id)
        {
            duelStatus.SetDefenseElement(id);
        }
    }
}
