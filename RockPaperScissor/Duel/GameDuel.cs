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
using RockPaperScissor.Text;
using RockPaperScissor.Duel.Fases;

namespace RockPaperScissor.Duel
{
    public class GameDuel
    {
        DuelStatus duelStatus;
        CommandContext ctx;
        Random rgn = new Random();

        FirstAttackFase firstAttackFase;
        FirstDefenseFase firstDefenseFase;
        SecondAttackFase secondAttackFase;
        SecondDefenseFase secondDefenseFase;

        static int VANTAGE_VALUE = 2;


        public GameDuel(CommandContext ctx, DuelStatus duelStatus)
        {
            this.duelStatus = duelStatus;
            this.ctx = ctx;

            firstAttackFase = new FirstAttackFase(ctx, duelStatus);
            firstDefenseFase = new FirstDefenseFase(ctx, duelStatus);
            secondAttackFase = new SecondAttackFase(ctx, duelStatus);
            secondDefenseFase = new SecondDefenseFase(ctx, duelStatus);
        }


        public async Task StartGameDuel()
        {
            duelStatus.SetGameContinue(true);
            duelStatus.SetAttackPlayerIndex(SortInitialAttackPlayer());
            await SendStartDuelMessage();

            do
            {
                await ctx.Channel.SendMessageAsync($"{duelStatus.GetAttackPlayer().Mention} "+ MyUtilities.GetMessager(duelStatus.GetAttackPlayer()).IsInTheAttack());
                await firstAttackFase.DoTheFase();
                await firstDefenseFase.DoTheFase();
                await secondAttackFase.DoTheFase();
                await secondDefenseFase.DoTheFase();
                await DoResolutionOfTurn();
            } while (duelStatus.GetGameContinue());

            await SendEndDuelMessage();
            await DoResolutionOfGame();
        }



        private async Task DoResolutionOfTurn()
        {
            if (!duelStatus.GetGameContinue()) return;
            int attackDefenseDif = CompareTheValues();
            int elementalBonus = ApplyAdvantages();

            if(BonusIsApplicable(elementalBonus))
                attackDefenseDif += elementalBonus;

            DefineTurnWinner(attackDefenseDif);
            GiveOneVictoryPointToWinner();
            await ShowTurnWinner(attackDefenseDif, elementalBonus);
            AnalizeWinOfGame();
            InvertAttackAndDefense();
        }


        private async Task DoResolutionOfGame()
        {
            StopDuelistDuelInDecks();
            int winnerId = duelStatus.GetGameWinnerIndex();
            if (winnerId == -1)
                await PlayDrawn();
            else
                await PlayWin(winnerId);
        }


        private async Task PlayDrawn()
        {
            await SendFormatMessageToDifferentLanguages(
                MyUtilities.GetMessager(duelStatus.GetCombatents()[0]).DuelWasDraw,
                MyUtilities.GetMessager(duelStatus.GetCombatents()[1]).DuelWasDraw,
                null
            );
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
            
            await ctx.Channel.SendMessageAsync($"`{GetAttackCardName()}` vs `{GetDefenseCardName()}`...");
            await Task.Delay(2000);
            await ctx.Channel.SendMessageAsync($"**{elementalStringAdvantage}**");
            await Task.Delay(2000);
            await SendWinText();
            await Task.Delay(1000);

            await SendFormatMessageToDifferentLanguages(
                MyUtilities.GetMessager(duelStatus.GetCombatents()[0]).CongratWinTurn,
                MyUtilities.GetMessager(duelStatus.GetCombatents()[1]).CongratWinTurn,
                new object[] { winnerName, Math.Abs(winDif) }
            );

            await Task.Delay(2000);
        }



        private string GetStringAdvantage(int elementalBonus)
        {
            String str = $"*{MyUtilities.GetElementalName(duelStatus.GetAttackElement())}*" +
                $" vs *{MyUtilities.GetElementalName(duelStatus.GetDefenseElement())}* ";
            if (elementalBonus > 0)  str += "[ATK↑]";
            if (elementalBonus < 0)  str += "[DEF↑]";
            if (elementalBonus == 0) str += "[---]";
            return str;
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

        private async Task SendWinText()
        {
            Func<String>[] funcs = new Func<string>[2];

            for(int i = 0; i < 2; i++)
            {
                if (duelStatus.GetTurnWinnerIndex() == duelStatus.GetAttackPlayerIndex())
                    funcs[i] = MyUtilities.GetMessager(duelStatus.GetCombatents()[i]).TheAttackWin;
                else
                    funcs[i] = MyUtilities.GetMessager(duelStatus.GetCombatents()[i]).TheDefenseWin;
            }

            await SendFormatMessageToDifferentLanguages(funcs[0], funcs[1], null);
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
            await SendFormatMessageToDifferentLanguages(
                MyUtilities.GetMessager(duelStatus.GetCombatents()[0]).CongratWinGame,
                MyUtilities.GetMessager(duelStatus.GetCombatents()[1]).CongratWinGame,
                new object[]
                {
                    duelStatus.GetCombatents()[winnerIndex].Mention, duelStatus.GetCombatents()[1-winnerIndex].Mention
                }
            );
        }


        private async Task GiveBasicProfitsAndLosses(int id)
        {
            int coins = duelStatus.GetPremiumCoins();

            await SendFormatMessageToDifferentLanguages(
                MyUtilities.GetMessager(duelStatus.GetCombatents()[0]).WinnerGetCoinsLoserMissCoins,
                MyUtilities.GetMessager(duelStatus.GetCombatents()[1]).WinnerGetCoinsLoserMissCoins,
                new object[] {coins, coins}
            );

            AllGameData.MakeTransference(duelStatus.GetCombatents()[1 - id], duelStatus.GetCombatents()[id], duelStatus.GetPremiumCoins());
        }
    

        private void StopDuelistDuelInDecks()
        {
            foreach (DiscordMember combatent in duelStatus.GetCombatents())
            { 
                AllGameData.GetMemberDeck(combatent).SetDueling(false);
            }
        }


        private async Task SendFormatMessageToDifferentLanguages(Func<String> funcToOne, Func<String> funcToTwo, object[] args, bool _reverseArgs=false)
        {
            if (args == null)
                args = new object[] { null };

            if (DuelistLanguagesAreDiferrent())
                await ctx.Channel.SendMessageAsync(MyUtilities.GetFormatText(funcToOne.Invoke(), args));

            if (_reverseArgs)
                args = args.Reverse().ToArray();

            await ctx.Channel.SendMessageAsync(MyUtilities.GetFormatText(funcToTwo.Invoke(), args));
        }




        private bool DuelistLanguagesAreDiferrent()
        {
            DiscordMember[] combatents = duelStatus.GetCombatents();
            return (
                AllGameData.GetMemberDeck(combatents[0]).GetLanguage() !=
                AllGameData.GetMemberDeck(combatents[1]).GetLanguage()
            );
        }


        private async Task SendStartDuelMessage()
        {
            await SendFormatMessageToDifferentLanguages(
                MyUtilities.GetMessager(duelStatus.GetCombatents()[0]).DuelStart,
                MyUtilities.GetMessager(duelStatus.GetCombatents()[1]).DuelStart,
                null
            );
        }

        private async Task SendEndDuelMessage()
        {
            await SendFormatMessageToDifferentLanguages(
                MyUtilities.GetMessager(duelStatus.GetCombatents()[0]).DuelEnd,
                MyUtilities.GetMessager(duelStatus.GetCombatents()[1]).DuelEnd,
                null
            );
        }


        private bool BonusIsApplicable(int bonus)
        {
            if (bonus == 0) return false;
            int originalValue;
            
            if (bonus > 0)
                originalValue = AllGameData.GetMemberDeck(duelStatus.GetAttackPlayer()).GetCardById(duelStatus.GetDefinitiveAttackCardIndex()).GetElements()[duelStatus.GetAttackElement()];
            else
                originalValue = AllGameData.GetMemberDeck(duelStatus.GetDefensePlayer()).GetCardById(duelStatus.GetDefenseCardIndex()).GetElements()[duelStatus.GetDefenseElement()];
            
            return originalValue >= 1;
        }

    }
}
