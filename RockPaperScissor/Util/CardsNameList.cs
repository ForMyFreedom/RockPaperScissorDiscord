using System;

namespace RockPaperScissor.Util
{
    static class CardsNameList
    {
        static String[] impactList = new[] { "Dragão", "Baleia", "Bufalo", "Leão", "Martelo", "Bigorna", "Altere", "Canhão" };
        static String[] precisionList = new[] { "Pássaro", "Insetos", "Tigre", "Golfinho", "Adaga", "Flecha", "Pistola", "Agulha" };
        static String[] enchantList = new[] { "Coruja", "Gato", "Borboleta", "Fada", "Varinha", "Grimório", "Mascara", "Anel" };
        static String[] middleList = new[] { "Macaco", "Lobo", "Cavalo", "Gavião", "Espada", "Machado", "Bola", "Lança" };

        static String[] weakAdject = new[] { "Sutíl", "Banal", "Fracote", "Inútil" };
        static String[] middleAdject = new[] { "Refinado(a)", "Aprimado(a)", "Poderoso(a)", "Treinado(a)" };
        static String[] strongAdject = new[] { "Divino(a)", "Demoniaco(a)", "Mestre", "Superior" };


        static Random rng = new Random();


        public static String GetImpactName() { return impactList[rng.Next(0, impactList.Length + 1)]; }
        public static String GetPrecisionName() { return precisionList[rng.Next(0, precisionList.Length + 1)]; }
        public static String GetEnchantName() { return enchantList[rng.Next(0, enchantList.Length + 1)]; }
        public static String GetMiddleName() { return middleList[rng.Next(0, middleList.Length + 1)]; }

        public static String GetWeakAdject() { return weakAdject[rng.Next(0, weakAdject.Length + 1)]; }
        public static String GetMiddleAdject() { return middleAdject[rng.Next(0, middleAdject.Length + 1)]; }
        public static String GetStrongAdject() { return strongAdject[rng.Next(0, strongAdject.Length + 1)]; }



        public static String GetFirstName(int focus, int[] elementsDestribution)
        {
            focus = IsMiddleDestribution(elementsDestribution) ? 3 : focus;

            switch (focus)
            {
                case 0:
                    return GetImpactName();
                case 1:
                    return GetPrecisionName();
                case 2:
                    return GetEnchantName();
                default:
                    return GetMiddleName();
            }
        }


        public static String GetSecondName(int quantElements)
        {
            if (quantElements < 5)
            {
                return GetWeakAdject();
            }
            else if (quantElements < 10)
            {
                return GetMiddleAdject();
            }
            else
            {
                return GetStrongAdject();
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
