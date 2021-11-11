using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.Text
{
    public class PortugueseTextGerenciator : TextMessagesGerenciator
    {
        public override string GetLanguageName()
        {
            return "Português [Portuguese]";
        }


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

        public override string LanguageChanged()
        {
            return "Linguagem alterada para Português!";
        }

        public override string DeckDuelName()
        {
            return "Deck de Duelo";
        }

        public override string DealMessageTemplate()
        {
            return "@ lhe propõe a troca: \n @ \n Por @ que ele possui";
        }

        public override string DealDeclined()
        {
            return "recusou sua proposta / o tempo expirou...";
        }

        public override string DealAccepted()
        {
            return "aceitou sua proposta. Troca realizada!";
        }

        public override string EmojiDealReaction()
        {
            return "Reaja essa mensagem com algum emoji caso aceite o acordo";
        }

        public override string LackOfGoods()
        {
            return "Você/ele não possui o que você diz ter...";
        }

        public override string DealSent()
        {
            return "Proposta enviada!";
        }



        public override string[] ImpactNameList()
        {
            return new[] { "Dragão", "Baleia", "Bufalo", "Leão", "Martelo", "Bigorna", "Halter", "Canhão" };
        }

        public override string[] PrecisionNameList()
        {
            return new[] { "Pássaro", "Insetos", "Tigre", "Golfinho", "Adaga", "Flecha", "Pistola", "Agulha" };
        }

        public override string[] EnchantNameList()
        {
            return new[] { "Coruja", "Gato", "Borboleta", "Fada", "Varinha", "Grimório", "Mascara", "Anel" };
        }

        public override string[] MiddleNameList()
        {
            return new[] { "Macaco", "Lobo", "Cavalo", "Gavião", "Espada", "Machado", "Bola", "Lança" };
        }

        public override string[] WeakAdjectiveList()
        {
            return new[] { "Sutíl", "Banal", "Fracote", "Inútil" };
        }

        public override string[] MiddleAdjectiveList()
        {
            return new[] { "Refinado(a)", "Aprimado(a)", "Poderoso(a)", "Treinado(a)" };
        }

        public override string[] StrongAdjectiveList()
        {
            return new[] { "Divino(a)", "Demoniaco(a)", "Mestre", "Superior" };
        }
    }
}
