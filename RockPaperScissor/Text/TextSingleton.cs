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
        public static Dictionary<String, TextMessagesGerenciator> GerenciatorDictionary = new Dictionary<string, TextMessagesGerenciator>()
        {
            {"en", new EnglishTextGerenciator()},
            {"pt", new PortugueseTextGerenciator()}
        };

        public static TextMessagesGerenciator GetGerenciator(String abbreviation)
        {
            if (GerenciatorDictionary.ContainsKey(abbreviation))
                return GerenciatorDictionary[abbreviation];
            else
                return GerenciatorDictionary["en"];
        }

        public static String GetAbbreviation(TextMessagesGerenciator gerenciator)
        {
            if (GerenciatorDictionary.ContainsValue(gerenciator))
                return GerenciatorDictionary.FirstOrDefault(x => x.Value == gerenciator).Key;
            else
                return "en";
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
