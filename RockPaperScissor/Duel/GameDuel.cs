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

            await ctx.Channel.SendMessageAsync($"**O DUELO SE INICIA!**");

            do
            {
                await ctx.Channel.SendMessageAsync($"{duelStatus.GetAttackPlayer().Mention} esta no Ataque!");
                await firstAttackFase.DoTheFase();
                await defenseFase.DoTheFase();
                await secondAttackFase.DoTheFase();
                await DoResolutionOfTurn();
            } while (duelStatus.GetGameContinue());

            await ctx.Channel.SendMessageAsync("**O DUELO ENCONTRA SEU FIM!**");
            await DoResolutionOfGame();
        }



        private async Task DoResolutionOfTurn()
        {
            if (!duelStatus.GetGameContinue()) return;
            int attackDefenseDif = CompareTheValues();
            int elementalBonus = ApplyAdvantages();
            attackDefenseDif += elementalBonus;
            DefineTurnWinner(attackDefenseDif);
            GiveOneVictoryPointToWinner();
            await ShowTurnWinner(attackDefenseDif, elementalBonus);
            AnalizeWinOfGame();
            InvertAttackAndDefense();
        }


        private async Task DoResolutionOfGame()
        {
            int winnerId = duelStatus.GetGameWinnerIndex();
            if (winnerId == -1)
                await PlayDrawn();
            else
                await PlayWin(winnerId);
        }


        private async Task PlayDrawn()
        {
            await ctx.Channel.SendMessageAsync("O Duelo acabou em empate, e com isso," +
                "nenhum dos lados ganham ou perdem...");
        }

        private async Task PlayWin(int winnerId)
        {
            await Task.Delay(2000);
            await CongratWinner(winnerId);
            await Task.Delay(2000);
            await GiveBasicProfitsAndLosses(winnerId);
            await Task.Delay(2000);
            await duelStatus.PlayWinLoseConditions();
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


        private async Task ShowTurnWinner(int winDif, int elementalBonus)
        {
            String winnerName = duelStatus.GetCombatents()[duelStatus.GetTurnWinnerIndex()].Nickname;
            String elementalStringAdvantage = GetStringAdvantage(elementalBonus);
            
            await ctx.Channel.SendMessageAsync($"`{GetAttackCardName()}` ataca `{GetDefenseCardName()}`...");
            await Task.Delay(2000);
            await ctx.Channel.SendMessageAsync($"**{elementalStringAdvantage}**");
            await Task.Delay(2000);
            await ctx.Channel.SendMessageAsync(GetWinText());
            await Task.Delay(1000);
            await ctx.Channel.SendMessageAsync($"Parabens, { winnerName}. Você venceu esse turno com { Math.Abs(winDif)} pontos a mais {GetZeroExplanation(winDif)}");
            await Task.Delay(2000);
        }

        private string GetStringAdvantage(int elementalBonus)
        {
            String str = $"*{MyUtilities.GetElementalName(duelStatus.GetAttackElement())}*" +
                $" vs *{MyUtilities.GetElementalName(duelStatus.GetDefenseElement())}* ";
            if (elementalBonus > 0)  str += "[Ataque com vantagem]";
            if (elementalBonus < 0)  str += "[Ataque com desvantagem]";
            if (elementalBonus == 0) str += "[Sem vantagem]";
            return str;
        }

        private string GetZeroExplanation(int winDiferrence)
        {
            if (winDiferrence == 0) return "[Ataque ganha no empate]";
            return "";
        }

        private string GetAttackCardName()
        {
            return AllGameData.GetMemberDeck(duelStatus.GetAttackPlayer()).GetCardById(
                duelStatus.GetDefinitiveAttackCardIndex()).ToString();
        }

        private string GetDefenseCardName()
        {
            return AllGameData.GetMemberDeck(duelStatus.GetDefensePlayer()).GetCardById(
                duelStatus.GetDefenseCardIndex()).ToString();
        }

        private string GetWinText()
        {
            if(duelStatus.GetTurnWinnerIndex() == duelStatus.GetAttackPlayerIndex())
                return "Porem o ataque venceu!";
            else
                return "E a defesa venceu!";
        }


        private void AnalizeWinOfGame()
        {
            if (duelStatus.GetUsedCardsIdFromDuelist()[0].Count >= duelStatus.GetQuantOfCards()-1)
            {
                duelStatus.SetGameContinue(false);
                duelStatus.SetGameWinnerIndex(GetGameWinner());
            }
        }


        private int GetGameWinner()
        {
            int[] victories = duelStatus.GetQuantOfVictoryPoints();
            if (victories[0] == victories[1])
                return -1;
            return (victories[0] > victories[1]) ? 0 : 1;
        }


        private void InvertAttackAndDefense()
        {
            duelStatus.SetAttackPlayerIndex(1-duelStatus.GetAttackPlayerIndex());
        }


        private int SortInitialAttackPlayer()
        {
            return rgn.Next(0, 2);
        }


        private async Task CongratWinner(int winnerIndex)
        {
            await ctx.Channel.SendMessageAsync(
                $"Parabêns, {duelStatus.GetCombatents()[winnerIndex].Mention}, voce venceu " +
                $"esse duelo contra {duelStatus.GetCombatents()[1-winnerIndex].Mention} com " +
                $"incrível maestria"
            );
        }


        private async Task GiveBasicProfitsAndLosses(int id)
        {
            int coins = duelStatus.GetPremiumCoins();
            await ctx.Channel.SendMessageAsync($"O Duelista vencedor recebe {coins}ℳ, ao passo que o perdedor perde {coins}ℳ");
            AllGameData.MakeTransference(duelStatus.GetCombatents()[1 - id], duelStatus.GetCombatents()[id], duelStatus.GetPremiumCoins());
        }
    }
}
