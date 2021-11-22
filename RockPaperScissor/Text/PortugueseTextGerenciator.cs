﻿using System;
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

        public override string GetLanguageAbbreviation()
        {
            return "pt";
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

        public override string LanguageRefused()
        {
            return "Essa linguagem não existe, por favor consulte as abreviações de linguagem no comando 'all_languages'";
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

        public override string WarAlreadyStarted()
        {
            return "A guerra das cartas já teve seu início...";
        }

        public override string NotPremiated()
        {
            return "Você não foi premiado hoje...";
        }

        public override string LostCardByError()
        {
            return "Você cometeu um erro e por isso perdeu sua carta";
        }

        public override string ExplaningPremiation()
        {
            return "Pababéns! Você foi premiado! Envie a seguinte mensagem para determinar o foco de sua carta: Impacto 'imp' / Precisão 'pre' / Encanto 'enc'";
        }

        public override string SuccessfulCardCreation()
        {
            return "CARTA CRIADA COM SUCESSO";
        }

        public override string TellAboutCooldown()
        {
            return "Você só podera pedir novamente após essa quantidade de minutos";
        }

        public override string RemovedCard()
        {
            return "Carta removida";
        }

        public override string InvalidCardId()
        {
            return "ID de carta invalido";
        }

        public override string NeedCoinsToReset(int quant)
        {
            return $"Você precisa ter pelo menos {quant}ℳ para resetar o seu deck";
        }

        public override string DeckCreatedSuccessfully()
        {
            return "Deck Criado com Sucesso!";
        }

        public override string AreYouSureToDeleteTheDeck()
        {
            return "Você tem certeza que deseja deletar todo seu deck e deixar de ser um guerreiro das cartas? Envie um '.' para confirmar";
        }

        public override string FarewellMate()
        {
            return "Deck deletado com sucesso... Um adeus, velho mestre das cartas...";
        }

        public override string DuelDeckActualized()
        {
            return "O Deck de Duelo foi atualizado pelos novos valores";
        }

        public override string WrongDeckIndex()
        {
            return "O index do deck está errado";
        }

        public override string MoreCardsThatIsPermitted()
        {
            return "Você colocou mais cartas que o permitido";
        }

    }
}
