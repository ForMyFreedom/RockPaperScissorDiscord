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
            return "& proposes the deal: \n & \n For & that it has";
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
            return "You committed an error and for this you lost your card";
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

        public override string CantCreateAnotherDeck()
        {
            return "You can't create another deck";
        }

        public override string DuelIgnored()
        {
            return "The duel was ignored...";
        }

        public override string DuelCanceled()
        {
            return "Unfortunately, the Duel was cancelled...";
        }

        public override string DuelProposalSent()
        {
            return "Duel proposal submitted!";
        }

        public override string YouAreConvoke()
        {
            return "You are convoke to a duel by the duelist: ";
        }

        public override string DuelFollowsFormat()
        {
            return "The Duel follows the following format:";
        }

        public override string RequestConfirmationOfDuel()
        {
            return "Reply (literally) this message with the Index of your chosen Duel Deck if you want to battle";
        }

        public override string YouCantRepeatCard()
        {
            return "You cannot repeat cards";
        }

        public override string DuelDeckWithIncorretFormat()
        {
            return "Duel Deck is not suited to the duel format";
        }

        public override string CantUseActionWhileDueling()
        {
            return "You cannot use this action while dueling!";
        }

        public override string ChooseWrongIndexOrBlockedCard()
        {
            return "You may have made a mistake or the referenced a card that is blocked for deal";
        }

        public override string DuelStart()
        {
            return "DUEL STARTS!";
        }

        public override string DuelEnd()
        {
            return "THE DUEL COMES TO AN END!";
        }

        public override string IsInTheAttack()
        {
            return "it's on Attack!";
        }

        public override string DuelWasDraw()
        {
            return "The Duel ended in a draw, and with that, neither side wins or loses...";
        }

        public override string YouLostByTooMuchErrors()
        {
            return "You lost the duel due to errors";
        }

        public override string OneMoreChanceBeforeLostTheDuel()
        {
            return "You have one more chance before you lose the duel...";
        }

        public override string ChooseADefenseIndex()
        {
            return "choose a card index of your duel deck to be your defense card";
        }

        public override string ChooseAAttackFront()
        {
            return "Choose two card indexes of your duel deck to be your Attack Front. Separated with a space";
        }

        public override string ChooseDefinitiveAttackIndex()
        {
            return "Attack Player, which card of your Attak Front you want to use";
        }

        public override string ChooseDefenseElement()
        {
            return "Defender, choose an element ('imp','pre','enc','pod') to be your Defense Element";
        }

        public override string ChooseAttackElement()
        {
            return "Attacker, choose an element ('imp','pre','enc','pod') to be your Attack Element";
        }

        public override string QuantOfCards()//@
        {
            return "Quant of Cards";
        }

        public override string CongratWinTurn()
        {
            return "Congratulations, &. You win this turn with & points more";
        }

        public override string CongratWinGame()
        {
            return "Congratulations, &. You win this duel against & with incredible maestry";
        }

        public override string TheAttackWin()
        {
            return "However the attack win!";
        }

        public override string TheDefenseWin()
        {
            return "And the defense win!";
        }

        public override string WinnerGetCoinsLoserMissCoins()
        {
            return "The winner duelist receive &ℳ, while the loser lost &ℳ";
        }

        public override string CantResetAfterEarlyClaim()
        {
            return "You can't delete your deck before be able to claim a new card";
        }
    }
}
