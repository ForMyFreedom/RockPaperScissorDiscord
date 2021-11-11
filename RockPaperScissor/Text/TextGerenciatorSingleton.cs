using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.Text
{
    public class TextGerenciatorSingleton
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
    }
}
