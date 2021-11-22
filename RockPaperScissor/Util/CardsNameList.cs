using System;
using RockPaperScissor.Text;

namespace RockPaperScissor.Util
{
    static class CardsNameList
    {
        static string[] ImpactName = new[] { "Dragon", "Whale", "Buffalo", "Lion", "Hammer", "Anvil", "Dumbbell", "Cannon" };
        static string[] PrecisionName = new[] { "Bird", "Insects", "Tiger", "Dolphin", "Dagger", "Arrow", "Pistol", "Needle" };
        static string[] EnchantName = new[] { "Owl", "Cat", "Butterfly", "Fairy", "Wand", "Grimoire", "Mask", "Ring" };
        static string[] MiddleName = new[] { "Monkey", "Wolf", "Horse", "Hawk", "Sword", "Axe", "Ball", "Spear" };
        static string[] WeakAdjective = new[] { "Subtle", "Trivial", "Weak", "Useless" };
        static string[] MiddleAdjective = new[] { "Refined", "Improved", "Powerfull", "Trained" };
        static string[] StrongAdjective = new[] { "Divine", "Demonic", "Master", "Supreme" };

        static Random rng = new Random();

        public static String GetRandomElement(String[] list) { return list[rng.Next(0, list.Length + 1)]; }


        public static String GetBaseName(int focus, int[] elementsDestribution)
        {
            focus = IsMiddleDestribution(elementsDestribution) ? 3 : focus;

            switch (focus)
            {
                case 0:
                    return GetRandomElement(ImpactName);
                case 1:
                    return GetRandomElement(PrecisionName);
                case 2:
                    return GetRandomElement(EnchantName);
                default:
                    return GetRandomElement(MiddleName);
            }
        }


        public static String GetAdjectiveName(int quantElements)
        {
            if (quantElements < 5)
                return GetRandomElement(WeakAdjective);
            else if (quantElements < 10)
                return GetRandomElement(MiddleAdjective);
            else
                return GetRandomElement(StrongAdjective);
        }



        static public bool IsMiddleDestribution(int[] elementsDest)
        {
            int sumDif = 0;
            int[][] comparations = new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 0 } };
            foreach (int[] compar in comparations)
            {
                int actualDif = Math.Abs(elementsDest[compar[0]] - elementsDest[compar[1]]);
                sumDif += actualDif;
            }
            return sumDif <= 4;
        }


        private static TextMessagesGerenciator EnglishGerenciator()
        {
            return TextSingleton.GetGerenciator("en");
        }
    }
}
