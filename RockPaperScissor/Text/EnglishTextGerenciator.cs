using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.Text
{
    public class EnglishTextGerenciator : TextMessagesGerenciator
    {
        public override string GetLanguageName()
        {
            return "English";
        }

        public override string GetLanguageAbbreviation()
        {
            return "en";
        }

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

        public override string LanguageChanged()
        {
            return "Language changed to English!";
        }

        public override string LanguageRefused()
        {
            return "This language does not exist, please consults the abbreviations in the command 'all_languages'";
        }

        public override string DeckDuelName()
        {
            return "Deck of Duel";
        }

        public override string DealMessageTemplate()
        {
            return "@ proposes the deal: \n @ \n For @ that he has";
        }

        public override string DealDeclined()
        {
            return "refused your deal / the time has expired...";
        }

        public override string DealAccepted()
        {
            return "accepted your deal. Deal carried out!";
        }

        public override string EmojiDealReaction()
        {
            return "React to this message with some emoji in case you accept the deal";
        }

        public override string LackOfGoods()
        {
            return "You/it do not have what you say that have...";
        }

        public override string DealSent()
        {
            return "Deal sent!";
        }

        public override string WarAlreadyStarted()
        {
            return "The Cards War has already started...";
        }

        public override string NotPremiated()
        {
            return "You was not premiated today...";
        }

        public override string LostCardByError()
        {
            return "You commited an error and for this you lost your card";
        }

        public override string ExplaningPremiation()
        {
            return "Congratulations! You were premiated! Send the following message to determine your cards focus: Impact 'imp' / Precision 'pre' / Enchant 'enc'";
        }

        public override string SuccessfulCardCreation()
        {
            return "CARD CREATED SUCCESSFULLY";
        }

        public override string TellAboutCooldown()
        {
            return "You may only request again after this amount of minutes";
        }

        public override string RemovedCard()
        {
            return "Card removed";
        }

        public override string InvalidCardId()
        {
            return "Invalid Card ID";
        }

        public override string NeedCoinsToReset(int quant)
        {
            return $"You need at least {quant}ℳ to reset your deck";
        }

        public override string DeckCreatedSuccessfully()
        {
            return "Deck created successfully!";
        }

        public override string AreYouSureToDeleteTheDeck()
        {
            return "Are you sure that want delete your deck and stop being a card warrior? Send a '.' to confirm";
        }

        public override string FarewellMate()
        {
            return "Deck deleted successfully... Farewell, old card master...";
        }

        public override string DuelDeckActualized()
        {
            return "The Duel Deck was actualized for the new values";
        }

        public override string WrongDeckIndex()
        {
            return "The index of the deck is wrong";
        }

        public override string MoreCardsThatIsPermitted()
        {
            return "You put more cards than is permitted";
        }



    }
}
