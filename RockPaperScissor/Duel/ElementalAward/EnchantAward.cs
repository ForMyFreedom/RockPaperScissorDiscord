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
    public class EnchantAward : _ElementalAward
    {
        public EnchantAward(int combatentIndex, DuelStatus duelStatus) : base(combatentIndex, duelStatus) { }

        public override Type GetFase()
        {
            return typeof(FirstAttackFase);
        }

        public override bool IsBefore()
        {
            return true;
        }

        public override string GetMessage(TextMessagesGerenciator geren)
        {
            return PrettyPrint(geren.EnchantAwardMessage());
        }


        public override async Task DoAward()
        {
            //@
            await Task.CompletedTask;
        }
    }
}
