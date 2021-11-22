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

    }
}
