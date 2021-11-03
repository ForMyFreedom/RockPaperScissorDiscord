using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.Text
{
    public class PortugueseTextGerenciator : TextMessagesGerenciator
    {
        public override string MemberDontHaveDeck()
        {
            return "O membro mencionado não possui um deck";
        }

        public override string CardIdDontExist()
        {
            return "O mestre não possui o id de carta especificada";
        }

        public override string NotCallYourself()
        {
            return "Você não pode realizar esta ação consigo mesmo";
        }

        public override string NotEnoughCoins()
        {
            return "O mestre das cartas não possui essa quantidade de moedas";
        }

        public override string OnlyPrivateCall()
        {
            return "Essa ação apenas pode ser chamada em meu privado...";
        }
    }
}
