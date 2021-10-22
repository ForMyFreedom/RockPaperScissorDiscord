using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.Data
{
    public class Deck
    {
        List<Card> allCards;
        ulong ownerID;
        int idCounter = 0;
        int coinsQuant;
        List<List<int>> duelDecksList;



        public Deck(ulong memberID)
        {//Create new Deck in game
            allCards = new List<Card>(30);
            CardCreator.GetStandartCardsToDeck(this);
            ownerID = memberID;
            coinsQuant = 50;
            duelDecksList = new List<List<int>>(2);
        }


        public Deck(ulong memberID, int idCounter, int coinsQuant, List<List<int>> duelDecks)
        {//Create new deck in load
            List<Card> allCards = new List<Card>(30);
            this.ownerID = memberID;
            this.idCounter = idCounter;
            this.coinsQuant = coinsQuant;
            this.duelDecksList = duelDecks;
        }


        public Deck() { }




        public void AddCard(Card card)
        {
            allCards.Add(card);
        }


        public bool RemoveCard(int ID)
        {
            foreach(Card card in allCards)
            {
                if (card.GetID() == ID)
                {
                    allCards.Remove(card);
                    return true;
                }
            }
            return false;
        }


        public override string ToString()
        {
            String cardsToString = $"{GetCoins()}  ℳ \n";
            foreach (Card _card in allCards)  cardsToString += _card.ToString() + "\n";
            return cardsToString;
        }



        public List<Card> GetAllCards()
        {
            return allCards;
        }

        public ulong GetOwner()
        {
            return ownerID;
        }

        public int GetIDCounter()
        {
            return idCounter;
        }

        public int GetCoins()
        {
            return coinsQuant;
        }

        public List<int> GetDuelDeck(int i)
        {
            return duelDecksList[i];
        }

        public List<List<int>> GetAllDuelDecks()
        {
            return duelDecksList;
        }

        public Card GetCardById(int id)
        {
            foreach (Card card in allCards)
            {
                if (card.GetID() == id)
                {
                    return card;
                }
            }
            return null;
        }



        public void SetDuelDeck(int duelDeckIndex, int[] cardsListIndex)
        {
            duelDecksList[duelDeckIndex] = cardsListIndex.ToList();
        }

        public void RemoveCoins(int quant)
        {
            coinsQuant -= quant;
        }

        public void AddCoins(int quant)
        {
            coinsQuant += quant;
        }

        public void ResetAllCards()
        {
            allCards = new List<Card>(30);
        }

        public void PlusIdCounter()
        {
            idCounter++;
        }

    }
}
