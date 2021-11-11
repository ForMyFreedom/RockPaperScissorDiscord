using DSharpPlus.Entities;
using System.Threading.Tasks;
using RockPaperScissor.Data;
//using RockPaperScissor.Duel;

namespace RockPaperScissor.Util
{
    public class ConditionsDiscordInterface
    {
        public static async Task<bool> PlayerIsCardMaster(DiscordChannel channel, DiscordMember member)
        {
            if (MyConditions.PlayerIsCardMaster(member)) return true;
            else
            {
                await channel.SendMessageAsync(AllGameData.messageGerenciator.MemberDontHaveDeck());
                return false;
            }
        }


        public static async Task<bool> PlayerIsCardMaster(DiscordChannel channel, ulong id)
        {
            if (MyConditions.PlayerIsCardMaster(id)) return true;
            else
            {
                await channel.SendMessageAsync(AllGameData.messageGerenciator.MemberDontHaveDeck());
                return false;
            }
        }


        public static async Task<bool> PlayerHasTheCardId(DiscordChannel channel, DiscordMember member, int cardID)
        {
            if (MyConditions.PlayerHasTheCardId(member, cardID)) return true;
            else
            {
                await channel.SendMessageAsync(AllGameData.messageGerenciator.CardIdDontExist());
                return false;
            }
        }


        public static async Task<bool> PlayerHasTheCoins(DiscordChannel channel, DiscordMember member, int coinsQuant)
        {
            if (MyConditions.PlayerHasTheCoins(member, coinsQuant)) return true;
            else
            {
                await channel.SendMessageAsync(AllGameData.messageGerenciator.NotEnoughCoins());
                return false;
            }
        }


        public static async Task<bool> ChannelIsPrivate(DiscordChannel channel)
        {
            if (MyConditions.ChannelIsPrivate(channel)) return true;
            else
            {
                await channel.SendMessageAsync(AllGameData.messageGerenciator.OnlyPrivateCall());
                return false;
            }
        }


        public static async Task<bool> IsNotTheSameMember(DiscordChannel channel, DiscordMember member1, DiscordMember member2)
        {
            if (MyConditions.IsNotTheSameMember(member1, member2)) return true;
            else
            {
                await channel.SendMessageAsync(AllGameData.messageGerenciator.NotCallYourself());
                return false;
            }
        }

    }
}
