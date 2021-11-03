using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.Text
{
    public class EnglishTextGerenciator : TextMessagesGerenciator
    {
        public override string MemberDontHaveDeck()
        {
            return "The mentioned member doesn't have a deck";
        }

        public override string CardIdDontExist()
        {
            return "The card master doesn't have the specified card id";
        }

        public override string NotCallYourself()
        {
            return "You can't do that action with yourself";
        }

        public override string NotEnoughCoins()
        {
            return "The card master doesn't have that amount of coins";
        }

        public override string OnlyPrivateCall()
        {
            return "This action can only be called in my private...";
        }
    }
}
