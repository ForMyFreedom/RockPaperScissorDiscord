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
using RockPaperScissor.Duel.Fases;

namespace RockPaperScissor.Duel
{
    public class GameDuel
    {
        DuelStatus duelStatus;
        CommandContext ctx;
        Random rgn = new Random();

        FirstAttackFase firstAttackFase;
        DefenseFase defenseFase;
        SecondAttackFase secondAttackFase;

        static int VANTAGE_VALUE = 3;


        public GameDuel(CommandContext ctx, DuelStatus duelStatus)
        {
            this.duelStatus = duelStatus;
            this.ctx = ctx;

            firstAttackFase = new FirstAttackFase(ctx, duelStatus);
            defenseFase = new DefenseFase(ctx, duelStatus);
            secondAttackFase = new SecondAttackFase(ctx, duelStatus);
        }


        public async Task StartGameDuel()
        {
            duelStatus.SetGameContinue(true);
            duelStatus.SetAttackPlayerIndex(SortInitialAttackPlayer());

            await ctx.Channel.SendMessageAsync(
                $"**O DUELO SE INICIA!** \n {duelStatus.GetAttackPlayer().Mention} começa no Ataque!"
            );
            
            do
            {
                await firstAttackFase.DoTheFase();
                await defenseFase.DoTheFase();
                await secondAttackFase.DoTheFase();
                if (duelStatus.GetGameContinue()) DoResolutionOfTurn();
            } while (duelStatus.GetGameContinue());

            //DoResolutionOfGame();
        }



        private void DoResolutionOfTurn()
        {
            int attackDefenseDif = CompareTheValues();
            attackDefenseDif += ApplyAdvantages();
            DefineTurnWinner(attackDefenseDif);
            GiveOneVictoryPointToWinner();
            AnalizeWinOfGame();
        }


        private int CompareTheValues()
        {
            int attackPower = GetBrutePowerOfCard(duelStatus.GetDefinitiveAttackCardIndex(), duelStatus.GetAttackElement(), duelStatus.GetAttackPlayerIndex());
            int defensePower = GetBrutePowerOfCard(duelStatus.GetDefenseCardIndex(), duelStatus.GetDefenseElement(), duelStatus.GetDefensePlayerIndex());
            return attackPower-defensePower;
        }


        private int GetBrutePowerOfCard(int cardIndex, int elementIndex, int combatentId)
        {
            Deck deck = AllGameData.GetMemberDeck(duelStatus.GetCombatents()[combatentId]);
            Card card = deck.GetCardById(cardIndex);
            if (elementIndex == 3) return card.GetPower();
            return card.GetElements()[elementIndex];
        }



        private int ApplyAdvantages()
        {
            int atkElement = duelStatus.GetAttackElement();
            int defElement = duelStatus.GetDefenseElement();

            if (atkElement == defElement) return 0;
            if (atkElement == 3 || defElement == 3) return GetAdvantageWithPowerPresent(atkElement, defElement);
            if (atkElement != 3 && defElement != 3) return GetAdvantageWithoutPowerPresent(atkElement, defElement);
            return 0;
        }


        private int GetAdvantageWithoutPowerPresent(int atkElement, int defElement)
        {
            int distance = MyUtilities.GetCircularDistanceInIntArray(atkElement, defElement, 3, true);
                                                      //In circular distance of 3 elements:
            if (distance == 1) return +VANTAGE_VALUE; // 1 means that is in front, then advantage to attack 
            if (distance == 2) return -VANTAGE_VALUE; // 2 means that is in back, then advantage to defense
            return 0;
        }


        private int GetAdvantageWithPowerPresent(int atkElement, int defElement)
        {
            if (defElement == 3) return +VANTAGE_VALUE;  //any attack element has advantage over power
            if (atkElement == 3) return -VANTAGE_VALUE;  //any defense element has advantage over power
            return 0;
        }


        private void DefineTurnWinner(int attackDefenseDif)
        {
            int winnerIndex = (attackDefenseDif>=0) ? 
                duelStatus.GetAttackPlayerIndex() : duelStatus.GetDefensePlayerIndex();

            duelStatus.SetTurnWinnerIndex(winnerIndex);
        }


        private void GiveOneVictoryPointToWinner()
        {
            duelStatus.AddOneVictoryPointToPlayer(duelStatus.GetTurnWinnerIndex());
        }


        private void AnalizeWinOfGame()
        {
            //////////////////@@@@@@@@@
        }




        private int SortInitialAttackPlayer()
        {
            return rgn.Next(0, 2);
        }

    }
}
