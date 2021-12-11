using DSharpPlus.Entities;
using System.Collections.Generic;
using RockPaperScissor.Data;
using RockPaperScissor.Duel;

namespace RockPaperScissor.Util
{
    public class MyConditions
    {
        public static bool CardInADuelDeck(DiscordMember member, int cardID)
        {
            foreach (List<int> duelDeck in AllGameData.GetMemberDeck(member).GetAllDuelDecks())
            {
                foreach(int id in duelDeck)
                {
                    if (id == cardID)
                        return true;
                }
            }
            return false;
        }

        public static bool PlayerIsCardMaster(DiscordMember member)
        {
            return AllGameData.GetMemberDeck(member) != null;
        }


        public static bool PlayerIsCardMaster(ulong id)
        {
            return AllGameData.GetMemberDeck(id) != null;
        }


        public static bool PlayerHasTheCardId(DiscordMember member, int cardID)
        {
            return AllGameData.GetMemberDeck(member).GetCardById(cardID) != null;

        }

        public static bool PlayerHasTheCoins(DiscordMember member, int coinsQuant)
        {
            return AllGameData.GetMemberDeck(member).GetCoins() >= coinsQuant;
        }


        public static bool ChannelIsPrivate(DiscordChannel channel)
        {
            return channel.IsPrivate;
        }


        public static bool IsNotTheSameMember(DiscordMember member1, DiscordMember member2)
        {
            return member1 != member2;
        }

        public static bool IsAdequatedDuelDeckToTheGameStyle(DiscordMember member, int duelDeckIndex, DuelStatus duelStatus)
        {
            return duelStatus.GetQuantOfCards() == AllGameData.GetMemberDeck(member).GetDuelDeck(duelDeckIndex).ToArray().Length;
        }

        public static bool IsNotDueling(DiscordUser user)
        {
            return ! AllGameData.GetMemberDeck(user.Id).GetDueling();
        }
    }
}
