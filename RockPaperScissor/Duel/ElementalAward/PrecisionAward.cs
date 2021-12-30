using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using RockPaperScissor.Data;
using RockPaperScissor.Duel.Fases.BaseAbstract;
using RockPaperScissor.Util;
using RockPaperScissor.Duel.Fases;
using RockPaperScissor.Text;


namespace RockPaperScissor.Duel.Award
{
    public class PrecisionAward : _ElementalAward
    {
        private Type fase;

        public PrecisionAward(int combatentIndex, DuelStatus duelStatus) : base(combatentIndex, duelStatus)
        {
            if(IsAttacker())
                fase = typeof(FirstAttackFase);
            else
                fase = typeof(FirstDefenseFase);
        }

        public override bool IsBefore()
        {
            return true;
        }

        public override Type GetFase()
        {
            return fase;
        }


        public override string GetMessage(TextMessagesGerenciator geren)
        {
            return PrettyPrint(geren.PrecisionAwardMessage());
        }


        public override async Task DoAward()
        {
            //@
            await Task.CompletedTask;
        }
    }
}
