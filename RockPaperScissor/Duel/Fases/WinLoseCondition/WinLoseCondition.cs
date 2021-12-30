using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace RockPaperScissor.Duel
{
    public abstract class WinLoseCondition
    {
        //implement
        public virtual async Task PlayConditions(DiscordMember winner, DiscordMember looser) { }
    }
}