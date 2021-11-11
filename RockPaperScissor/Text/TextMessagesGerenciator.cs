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

        public abstract String MemberDontHaveDeck();
        public abstract String CardIdDontExist();
        public abstract String NotEnoughCoins();
        public abstract String OnlyPrivateCall();
        public abstract String NotCallYourself();
        public abstract String LanguageChanged();
        public abstract String DeckDuelName();
        public abstract String DealMessageTemplate();
        public abstract String DealDeclined();
        public abstract String DealAccepted();
        public abstract String EmojiDealReaction();
        public abstract String LackOfGoods();
        public abstract String DealSent();

        public abstract String[] ImpactNameList();
        public abstract String[] PrecisionNameList();
        public abstract String[] EnchantNameList();
        public abstract String[] MiddleNameList();
        public abstract String[] WeakAdjectiveList();
        public abstract String[] MiddleAdjectiveList();
        public abstract String[] StrongAdjectiveList();
    }
}
