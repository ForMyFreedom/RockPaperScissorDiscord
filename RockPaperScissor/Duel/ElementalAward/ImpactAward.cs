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
    public class ImpactAward : _ElementalAward
    {
        public ImpactAward(int combatentIndex, DuelStatus duelStatus) : base(combatentIndex, duelStatus) { }

        public override Type GetFase()
        {
            return typeof(SecondAttackFase);
        }

        public override bool IsBefore()
        {
            return false;
        }


        public override string GetMessage(TextMessagesGerenciator geren)
        {
            return PrettyPrint(geren.ImpactAwardMessage());
        }


        public override async Task DoAward()
        {
            Card buffedCard = BuffCardCertainElement(GetCardUsed(), GetElementUsed());
            SetCombatentCard(buffedCard);
            await Task.CompletedTask;
        }

        private Card GetCardUsed()
        {
            int index;
            
            if (IsAttacker())
                index = duelStatus.GetDefinitiveAttackCardIndex();
            else
                index = duelStatus.GetDefenseCardIndex();

            return duelStatus.GetDecks()[combatentIndex].GetCardById(index);
        }


        private int GetElementUsed()
        {
            if (IsAttacker())
                return duelStatus.GetAttackElement();
            else
                return duelStatus.GetDefenseElement();
        }


        private Card BuffCardCertainElement(Card card, int elementIndex)
        {
            int[] newElements = card.GetElements();
            newElements[elementIndex] += GetRandomBuff();
            return new Card(card.GetName(), newElements, card.GetStars(), card.GetID());
        }

        private int GetRandomBuff()
        {
            Random rgn = new Random();
            return rgn.Next(1, 4) + rgn.Next(1, 4);
        }


        private void SetCombatentCard(Card card)
        {
            //@
            if (IsAttacker()) { } else { }
        }
    }
}
