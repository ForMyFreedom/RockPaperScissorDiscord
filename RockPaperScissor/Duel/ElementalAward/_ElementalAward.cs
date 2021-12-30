using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using RockPaperScissor.Data;
using RockPaperScissor.Util;
using RockPaperScissor.Text;
using RockPaperScissor.Duel.Fases.BaseAbstract;
using RockPaperScissor.Duel.Fases.CardReq;
using RockPaperScissor.Duel.Fases.ElementReq;

namespace RockPaperScissor.Duel.Award
{
    public abstract class _ElementalAward
    {
        protected int combatentIndex;
        protected DuelStatus duelStatus;

        public _ElementalAward(int combatentIndex, DuelStatus duelStatus)
        {
            this.combatentIndex = combatentIndex;
            this.duelStatus = duelStatus;
        }

        public abstract Type GetFase();
        public abstract bool IsBefore();
        public abstract String GetMessage(TextMessagesGerenciator geren);

        public async virtual Task DoAward() //override
        {
            await Task.CompletedTask;
        }

        protected String PrettyPrint(String text)
        {
            return $"```md\n# {text}\n```";
        }

        protected bool IsAttacker()
        {
            if (duelStatus.GetAttackPlayerIndex() == combatentIndex)
                return true;
            else
                return false;
        }
    }
}
