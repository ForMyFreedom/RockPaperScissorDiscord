using System;
using RockPaperScissor.Data;

namespace RockPaperScissor.Util
{
    static class CardsNameList
    {
        static Random rng = new Random();

        public static String GetRandomElement(String[] list) { return list[rng.Next(0, list.Length + 1)]; }


        public static String GetFirstName(int focus, int[] elementsDestribution)
        {
            focus = IsMiddleDestribution(elementsDestribution) ? 3 : focus;

            switch (focus)
            {
                case 0:
                    return GetRandomElement(AllGameData.messageGerenciator.ImpactNameList());
                case 1:
                    return GetRandomElement(AllGameData.messageGerenciator.PrecisionNameList());
                case 2:
                    return GetRandomElement(AllGameData.messageGerenciator.EnchantNameList());
                default:
                    return GetRandomElement(AllGameData.messageGerenciator.MiddleNameList());
            }
        }


        public static String GetSecondName(int quantElements)
        {
            if (quantElements < 5)
            {
                return GetRandomElement(AllGameData.messageGerenciator.WeakAdjectiveList());
            }
            else if (quantElements < 10)
            {
                return GetRandomElement(AllGameData.messageGerenciator.MiddleAdjectiveList());
            }
            else
            {
                return GetRandomElement(AllGameData.messageGerenciator.StrongAdjectiveList());
            }
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
    }
}
