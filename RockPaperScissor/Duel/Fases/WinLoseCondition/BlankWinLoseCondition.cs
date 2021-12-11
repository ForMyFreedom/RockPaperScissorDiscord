using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace RockPaperScissor.Duel
{
    public class BlankWinLoseCondition : WinLoseCondition
    {

        public override async Task PlayConditions(DiscordMember winner, DiscordMember looser)
        {
        }
    }
}