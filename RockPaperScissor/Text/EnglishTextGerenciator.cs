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
            return "Proposta enviada!";
        }



        public override string[] ImpactNameList()
        {
            return new[] { "Dragon", "Whale", "Buffalo", "Lion", "Hammer", "Anvil", "Dumbbell", "Cannon" };
        }

        public override string[] PrecisionNameList()
        {
            return new[] { "Bird", "Insects", "Tiger", "Dolphin", "Dagger", "Arrow", "Pistol", "Needle" };
        }

        public override string[] EnchantNameList()
        {
            return new[] { "Owl", "Cat", "Butterfly", "Fairy", "Wand", "Grimoire", "Mask", "Ring" };
        }

        public override string[] MiddleNameList()
        {
            return new[] { "Monkey", "Wolf", "Horse", "Hawk", "Sword", "Axe", "Ball", "Spear" };
        }

        public override string[] WeakAdjectiveList()
        {
            return new[] { "Subtle", "Trivial", "Weak", "Useless" };
        }

        public override string[] MiddleAdjectiveList()
        {
            return new[] { "Refined", "Improved", "Powerfull", "Trained" };
        }

        public override string[] StrongAdjectiveList()
        {
            return new[] { "Divine", "Demonic", "Master", "Supreme" };
        }
    }
}
