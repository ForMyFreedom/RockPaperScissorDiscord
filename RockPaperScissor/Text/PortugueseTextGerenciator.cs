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
            return "& lhe propõe a troca: \n & \n Por & que ele possui";
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

        public override string CantCreateAnotherDeck()
        {
            return "Você não pode criar outro deck";
        }

        public override string DuelIgnored()
        {
            return "O duelo foi ignorado...";
        }

        public override string DuelCanceled()
        {
            return "Infelizmente, o Duelo foi cancelado...";
        }

        public override string DuelProposalSent()
        {
            return "Proposta de Duelo enviada!";
        }

        public override string YouAreConvoke()
        {
            return "Você é convocado para um duelo pelo duelista: ";
        }

        public override string DuelFollowsFormat()
        {
            return "O Duelo segue o seguinte formato:";
        }

        public override string RequestConfirmationOfDuel()
        {
            return "Responda (literalmente) essa mensagem com o Index de seu Deck de Duelo escolhido caso deseje batalhar";
        }

        public override string YouCantRepeatCard()
        {
            return "Você não pode repetir cartas";
        }

        public override string DuelDeckWithIncorretFormat()
        {
            return "O Deck de Duelo não está adequado ao formato do duelo";
        }

        public override string CantUseActionWhileDueling()
        {
            return "Voce não pode usar essa ação enquanto duelar!";
        }

        public override string ChooseWrongIndexOrBlockedCard()
        {
            return "Você pode ter cometido um erro ou a carta referênciada esta bloqueada para negócios";
        }

        public override string DuelStart()
        {
            return "O DUELO SE INICIA!";
        }

        public override string DuelEnd()
        {
            return "O DUELO ENCONTRA SEU FIM!";
        }

        public override string IsInTheAttack()
        {
            return "esta no Ataque!";
        }

        public override string DuelWasDraw()
        {
            return "O Duelo acabou em empate, e com isso, nenhum dos lados ganham ou perdem...";
        }

        public override string YouLostByTooMuchErrors()
        {
            return "Você perdeu o duelo por exesso de erros";
        }

        public override string OneMoreChanceBeforeLostTheDuel()
        {
            return "Você tem mais uma chance antes de perder o duelo...";
        }

        public override string ChooseADefenseIndex()
        {
            return "escolha um index de carta de seu deck de duelo para ser sua Carta de Defesa";
        }

        public override string ChooseAAttackFront()
        {
            return "Escolha dois index de cartas de seu deck de duelo para serem seu Fronte de Ataque. Separadas com um espaço";
        }

        public override string ChooseDefinitiveAttackIndex()
        {
            return "Por fim, Jogador de Ataque, qual carta de seu Fronte de Ataques você deseja usar";
        }

        public override string ChooseDefenseElement()
        {
            return "Ainda no Defensor, escolha um elemento ('imp','pre','enc','pod') para ser seu Elemento de Defesa";
        }

        public override string ChooseAttackElement()
        {
            return "Ainda no Atacante, escolha um elemento ('imp','pre','enc','pod') para ser seu Elemento de Ataque";
        }

        public override string QuantOfCards()
        {
            return "Quantidade de Cartas";
        }

        public override string CongratWinTurn()
        {
            return "Parabêns, &. Você venceu esse turno com & pontos a mais";
        }

        public override string CongratWinGame()
        {
            return "Parabêns, &. Você venceu esse duelo contra & com incrível maestria";
        }

        public override string TheAttackWin()
        {
            return "Porem o ataque venceu!";
        }

        public override string TheDefenseWin()
        {
            return "E a defesa venceu!";
        }

        public override string WinnerGetCoinsLoserMissCoins()
        {
            return "O Duelista vencedor recebe &ℳ, ao passo que o perdedor perde &ℳ";
        }

        public override string CantResetAfterEarlyClaim()
        {
            return "Você não pode deleter o seu deck antes de ser capaz de pegar uma nova carta";
        }
    }
}
