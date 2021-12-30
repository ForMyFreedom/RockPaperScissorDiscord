using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissor.Data;
using RockPaperScissor.Util;
using DSharpPlus.Entities;

namespace RockPaperScissor.Duel
{
    public class DuelStatus
    {
        //game regulation
        private DiscordMember[] combatents;
        private Deck[] decks;
        private int quantOfCards;
        private bool gameContinue;
        public int[] amountOfErrorsFromPlayers;
        private int[] duelDeckIndexFromDuelists;
        private List<int>[] usedCardsIdFromDuelists;


        //turn regulation
        private int attackPlayerIndex;
        private int[] attackFront;
        private int definitiveAttackCardIndex;
        private int defenseCardIndex;
        private int attackElement;
        private int defenseElement;
        private Award._ElementalAward[] combatentAwards;


        //win regulation
        private int[] quantOfVictoryPoints;
        private int gameWinnerIndex;
        private int turnWinnerIndex;
        private int premiumCoins;

        private WinLoseCondition winLoseCondition;




        public DuelStatus(String strParam)
        {
            combatents = new DiscordMember[2];
            decks = new Deck[2];
            gameContinue = true;
            amountOfErrorsFromPlayers = new[] { 0, 0 };
            duelDeckIndexFromDuelists = new[] { 0, 0 };
            usedCardsIdFromDuelists = new[] { new List<int>(), new List<int>() };

            quantOfVictoryPoints = new[] { 0, 0 };

            GetStatusFromStrParam(strParam);
        }


        public async Task PlayWinLoseConditions()
        {
            await winLoseCondition.PlayConditions(GetCombatents()[gameWinnerIndex], GetCombatents()[1-gameWinnerIndex]);
        }



        public void GetStatusFromStrParam(String strParam)
        {
            //@implement the variations
            quantOfCards = 4;
            premiumCoins = 20;
            winLoseCondition = new BlankWinLoseCondition();
        }

        public String GetStyleToString(DiscordMember member)
        {
            //@implement the variations
            return
            (
                $"{MyUtilities.GetMessager(member).QuantOfCards()}: {quantOfCards}"            
            );
        }


        public int GetPlayerIndex(DiscordMember user)
        {
            for (int i = 0; i<2 ; i++)
            {
                if (combatents[i]==user)
                    return i;
            }

            return -1;
        }

        public DiscordMember[] GetCombatents()
        {
            return combatents;
        }

        public void SetOneCombatent(int id, DiscordMember dm)
        {
            combatents[id] = dm;
            decks[id] = AllGameData.GetMemberDeck(dm);
        }


        public Deck[] GetDecks()
        {
            return decks;
        }


        public DiscordMember GetAttackPlayer()
        {
            return combatents[GetAttackPlayerIndex()];
        }

        public DiscordMember GetDefensePlayer()
        {
            return combatents[GetDefensePlayerIndex()];
        }


        public int GetQuantOfCards()
        {
            return quantOfCards;
        }

        public void SetQuantOfCards(int _quantOfCards)
        {
            quantOfCards = _quantOfCards;
        }


        public bool GetGameContinue()
        {
            return gameContinue;
        }

        public void SetGameContinue(bool _gameContinue)
        {
            gameContinue = _gameContinue;
        }


        public int[] GetAmoutOfErrorsFromPlayers()
        {
            return amountOfErrorsFromPlayers;
        }

        public void AddOneErrorFromPlayer(int playerId)
        {
            amountOfErrorsFromPlayers[playerId] += 1;
        }


        public int[] GetDuelDeckIndexList()
        {
            return duelDeckIndexFromDuelists;
        }
        
        public void SetDuelDeckIndex(int playerIndex, int duelDeckIndex)
        {
            if (duelDeckIndex != 0 && duelDeckIndex != 1)
                SetGameContinue(false);

            duelDeckIndexFromDuelists[playerIndex] = duelDeckIndex;
        }


        public List<int>[] GetUsedCardsIdFromDuelist()
        {
            return usedCardsIdFromDuelists;
        }

        public void AddAnUsedCardsIdFromDuelist(int playerId, int cardId)
        {
            usedCardsIdFromDuelists[playerId].Add(cardId);
        }


        public int GetAttackPlayerIndex()
        {
            return attackPlayerIndex;
        }

        public int GetDefensePlayerIndex()
        {
            return 1 - attackPlayerIndex;
        }

        public void SetAttackPlayerIndex(int _attackPlayerIndex)
        {
            attackPlayerIndex = _attackPlayerIndex;
        }


        public int[] GetAttackFront()
        {
            return attackFront;
        }

        public void SetAttackFront(int[] _attackFront)
        {
            attackFront = _attackFront;
        }


        public int GetDefinitiveAttackCardIndex()
        {
            return definitiveAttackCardIndex;
        }

        public void SetDefinitiveAttackCardIndex(int _definitiveAttackCardIndex)
        {
            definitiveAttackCardIndex = _definitiveAttackCardIndex;
        }


        public int GetDefenseCardIndex()
        {
            return defenseCardIndex;
        }

        public void SetDefenseCardIndex(int _defenseCardIndex)
        {
            defenseCardIndex = _defenseCardIndex;
        }


        public int GetAttackElement()
        {
            return attackElement;
        }

        public void SetAttackElement(int _attackElement)
        {
            attackElement = _attackElement;
        }


        public int GetDefenseElement()
        {
            return defenseElement;
        }

        public void SetDefenseElement(int _defenseElement)
        {
            defenseElement = _defenseElement;
        }


        public int[] GetQuantOfVictoryPoints()
        {
            return quantOfVictoryPoints;
        }

        public void AddOneVictoryPointToPlayer(int playerIndex)
        {
            quantOfVictoryPoints[playerIndex] += 1;
        }


        public int GetTurnWinnerIndex()
        {
            return turnWinnerIndex;
        }

        public void SetTurnWinnerIndex(int _turnWinnerIndex)
        {
            turnWinnerIndex = _turnWinnerIndex;
        }


        public int GetGameWinnerIndex()
        {
            return gameWinnerIndex;
        }

        public void SetGameWinnerIndex(int _gameWinnerIndex)
        {
            gameWinnerIndex = _gameWinnerIndex;
        }

        public void SetPremiumCoins(int coins)
        {
            premiumCoins = coins;
        }

        public int GetPremiumCoins()
        {
            return premiumCoins;
        }
    }
}
