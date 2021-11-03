using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissor.Data
{
    class AllGameData
    {
        public const String NAME_OF_ROLE = "Guerreiro das Cartas";
        public const int TIME_TO_CLAIM_IN_SECONDS = 1800;
        public const int DUEL_DECKS_LENGTH = 2;
        public const int MAX_CARDS_IN_DUEL_DECK = 10;
        public static ulong gameRoleID;
        static private List<Deck> allDecks;


        static public void StartNewData()
        {
            allDecks = new List<Deck>();
        }

        static public void AddDeck(Deck deck)
        {
            allDecks.Add(deck);
        }

        static public void CreateAndAddNewDeck(ulong memberID)
        {
            allDecks.Add(new Deck(memberID));
        }


        static public Card AddNewCard(DiscordMember member, int[] distribution, int stars, String name)
        {
            Deck memberDeck = GetMemberDeck(member.Id);
            if (memberDeck == null) return null;
            Card card = CardCreator.CreateAndAddCardToDeck(memberDeck, name, distribution, stars);
            return card;
        }


        /*static public Card[] GetAllCardsFromDeck(ulong id)
        {
            Deck deck = GetMemberDeck(id);
            if (deck == null)  return null;
            return deck.GetAllCards().ToArray();
        }
        */


        static public DiscordRole TryToGetGameRole(CommandContext ctx)
        {
            return ctx.Guild.Roles.Values.FirstOrDefault(r => r.Name == NAME_OF_ROLE);
        }



        static public void DeleteDeckFromMember(DiscordMember member)
        {
            Deck deck = GetMemberDeck(member);
            if (deck != null) allDecks.Remove(deck);
        }



        static public Deck GetMemberDeck(DiscordMember member)
        {
            return GetMemberDeck(member.Id);
        }


        static public Deck GetMemberDeck(ulong id)
        {
            foreach (Deck deck in allDecks)
            {
                if (deck.GetOwner() == id) return deck;
            }
            return null;
        }




        static public void MakeTransference(DiscordMember firstMember, DiscordMember secondMember, int coinsQuant)
        {
            GetMemberDeck(firstMember).RemoveCoins(coinsQuant);
            GetMemberDeck(secondMember).AddCoins(coinsQuant);
        }



        static public List<Deck> GetAllDecks()
        {
            return allDecks;
        }


    }
}
