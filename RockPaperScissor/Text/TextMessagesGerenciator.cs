using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.Text
{
    public abstract class TextMessagesGerenciator
    {
        public abstract String GetLanguageName();
        public abstract String GetLanguageAbbreviation();

        public abstract String MemberDontHaveDeck();
        public abstract String CardIdDontExist();
        public abstract String NotEnoughCoins();
        public abstract String OnlyPrivateCall();
        public abstract String NotCallYourself();
        public abstract String LanguageChanged();
        public abstract String LanguageRefused();
        public abstract String DeckDuelName();
        public abstract String DealMessageTemplate();
        public abstract String DealDeclined();
        public abstract String DealAccepted();
        public abstract String EmojiDealReaction();
        public abstract String LackOfGoods();
        public abstract String DealSent();
        public abstract String WarAlreadyStarted();
        public abstract String NotPremiated();
        public abstract String LostCardByError();
        public abstract String ExplaningPremiation();
        public abstract String SuccessfulCardCreation();
        public abstract String TellAboutCooldown();
        public abstract String RemovedCard();
        public abstract String InvalidCardId();
        public abstract String NeedCoinsToReset(int quant);
        public abstract String DeckCreatedSuccessfully();
        public abstract String AreYouSureToDeleteTheDeck();
        public abstract String FarewellMate();
        public abstract String DuelDeckActualized();
        public abstract String WrongDeckIndex();
        public abstract String MoreCardsThatIsPermitted();
        public abstract String CantCreateAnotherDeck();
        public abstract String DuelCanceled(); //"Infelizmente, o Duelo foi cancelado..."
        public abstract String DuelProposalSent(); //"Proposta de Duelo enviada!"
        public abstract String YouAreConvoke(); //"Você é convocado para um duelo pelo duelista: "
        public abstract String DuelFollowsFormat();//"O Duelo segue o seguinte formato:"
        public abstract String RequestConfirmationOfDuel();//"Responda (literalmente) essa mensagem com o Index de seu Deck de Duelo escolhido caso deseje batalhar"
        public abstract String YouCantRepeatCard();//"Você não pode repetir cartas"
        public abstract String DuelDeckWithIncorretFormat();//"O Deck de Duelo não está adequado ao formato do duelo"
        public abstract String CantUseActionWhileDueling();//"Voce não pode usar essa ação enquanto duelar!"
        public abstract String ChooseWrongIndexOrBlockedCard();//"Você pode ter cometido um erro ou a carta referênciada esta bloqueada para venda"
        public abstract String DuelStart();//"O DUELO SE INICIA!"
        public abstract String DuelEnd();//"O DUELO ENCONTRA SEU FIM!"
        public abstract String IsInTheAttack();//esta no Ataque!
        public abstract String DuelWasDraw();//"O Duelo acabou em empate, e com isso, nenhum dos lados ganham ou perdem..."
        public abstract String YouLostByTooMuchErrors();//"Você perdeu o duelo por exesso de erros"
        public abstract String OneMoreChanceBeforeLostTheDuel();//"Você tem mais uma chance antes de perder o duelo..."
    }
}
