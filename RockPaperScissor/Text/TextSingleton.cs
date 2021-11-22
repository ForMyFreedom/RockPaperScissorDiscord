using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using RockPaperScissor.Data;

namespace RockPaperScissor.Text
{
    public class TextSingleton
    {
        public static List<TextMessagesGerenciator> GerenciatorList = new List<TextMessagesGerenciator>()
        {
            new EnglishTextGerenciator(), new PortugueseTextGerenciator()
        };


        public static TextMessagesGerenciator GetGerenciator(String abbreviation)
        {
            foreach(TextMessagesGerenciator language in GerenciatorList)
            {
                if (language.GetLanguageAbbreviation() == abbreviation)
                    return language;
            }
            return null;
        }

        public static TextMessagesGerenciator GetMemberGerenciator(DiscordMember member)
        {
            return GetGerenciator(AllGameData.GetMemberDeck(member).GetLanguage());
        }

        public static TextMessagesGerenciator GetMemberGerenciator(ulong id)
        {
            return GetGerenciator(AllGameData.GetMemberDeck(id).GetLanguage());
        }

        public static TextMessagesGerenciator GetMemberGerenciator(Deck deck)
        {
            return GetGerenciator(deck.GetLanguage());
        }
    }
}
