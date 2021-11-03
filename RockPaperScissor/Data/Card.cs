using RockPaperScissor.Util;
using System;

namespace RockPaperScissor.Data
{
    public class Card
    {
        private String name;
        private int ID;
        private int impact;
        private int precision;
        private int enchant;
        private int stars;


        public Card(String name, int impact, int precision, int enchant, int stars, int ID)
            : this(name, new[] { impact, precision, enchant }, stars, ID) { }


        public Card(String name, int[] elements, int stars, int ID)
        {
            this.name = name;
            this.impact = elements[0];
            this.precision = elements[1];
            this.enchant = elements[2];
            this.stars = stars;
            this.ID = ID;
        }



        public override string ToString()
        {
            return $"{ID}. {name} [{MyUtilities.GetEmoteStars(stars)}] (Imp: {impact}, Pre: {precision}, Enc: {enchant})";
        }



        public int GetID()
        {
            return ID;
        }

        public String GetName()
        {
            return name;
        }

        public int GetImpact()
        {
            return impact;
        }

        public int GetPrecision()
        {
            return precision;
        }

        public int GetEnchant()
        {
            return enchant;
        }

        public int GetStars()
        {
            return stars;
        }

        public int[] GetElements()
        {
            return new[] { impact, precision, enchant };
        }

        public int GetPower()
        {
            int sum = 0;
            foreach (int element in GetElements())
                sum += element;
            return sum;
        }

    }
}

