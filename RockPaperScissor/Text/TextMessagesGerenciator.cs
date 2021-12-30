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
        public abstract String DuelIgnored();
        public abstract String DuelCanceled();
        public abstract String DuelProposalSent();
        public abstract String YouAreConvoke();
        public abstract String DuelFollowsFormat();
        public abstract String RequestConfirmationOfDuel();
        public abstract String YouCantRepeatCard();
        public abstract String DuelDeckWithIncorretFormat();
        public abstract String CantUseActionWhileDueling();
        public abstract String ChooseWrongIndexOrBlockedCard();
        public abstract String DuelStart();
        public abstract String DuelEnd();
        public abstract String IsInTheAttack();
        public abstract String DuelWasDraw();
        public abstract String YouLostByTooMuchErrors();
        public abstract String OneMoreChanceBeforeLostTheDuel();
        public abstract String ChooseADefenseIndex();
        public abstract String ChooseAAttackFront();
        public abstract String ChooseDefinitiveAttackIndex();
        public abstract String ChooseDefenseElement();
        public abstract String ChooseAttackElement();
        public abstract String QuantOfCards();
        public abstract String CongratWinTurn();
        public abstract String CongratWinGame();
        public abstract String TheAttackWin();
        public abstract String TheDefenseWin();
        public abstract String WinnerGetCoinsLoserMissCoins();
        public abstract String CantResetAfterEarlyClaim();
    }
}
