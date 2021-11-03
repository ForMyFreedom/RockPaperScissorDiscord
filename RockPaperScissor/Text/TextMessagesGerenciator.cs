using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.Text
{
    public abstract class TextMessagesGerenciator
    {

        public abstract String MemberDontHaveDeck();
        public abstract String CardIdDontExist();
        public abstract String NotEnoughCoins();
        public abstract String OnlyPrivateCall();
        public abstract String NotCallYourself();
    }
}
