﻿using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.Data
{
    public class CardCreator
    {
        static public void GetStandartCardsToDeck(Deck deck)
        {
            AddALotOFCardsToDeck(deck, "Pedra",   new[] { 1, 0, 0 }, 0, 5);
            AddALotOFCardsToDeck(deck, "Papel",   new[] { 0, 0, 1 }, 0, 5);
            AddALotOFCardsToDeck(deck, "Tesoura", new[] { 0, 1, 0 }, 0, 5);
        }


        static public void AddALotOFCardsToDeck(Deck deck, String name, int[] elements, int stars, int quant)
        {
            for (int i = 0; i < quant; i++)
            {
                CreateAndAddCardToDeck(deck, name, elements, stars);
            }
        }




        static public Card CreateAndAddCardToDeck(Deck deck, String name, int[] elements, int stars)
        {
            deck.PlusIdCounter();
            return CreateAndAddCardToDeck(deck, name, elements, stars, deck.GetIDCounter());
        }


        static public Card CreateAndAddCardToDeck(Deck deck, String name, int[] elements, int stars, int id)
        {
            Card newCard = new Card(name, elements, stars, id);
            deck.AddCard(newCard);
            return newCard;
        }

    }
}
