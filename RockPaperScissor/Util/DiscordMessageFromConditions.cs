using DSharpPlus.Entities;
using System.Threading.Tasks;
using RockPaperScissor.Data;
using RockPaperScissor.Duel;

namespace RockPaperScissor.Util
{
    public class ConditionsDiscordInterface
    {
        public static async Task<bool> PlayerIsCardMaster(DiscordChannel channel, DiscordMember member)
        {
            if (MyConditions.PlayerIsCardMaster(member)) return true;
            else
            {
                await channel.SendMessageAsync("O membro mencionado não possui um deck");
                return false;
            }
        }


        public static async Task<bool> PlayerIsCardMaster(DiscordChannel channel, ulong id)
        {
            if (MyConditions.PlayerIsCardMaster(id)) return true;
            else
            {
                await channel.SendMessageAsync("O membro mencionado não possui um deck");
                return false;
            }
        }


        public static async Task<bool> PlayerHasTheCardId(DiscordChannel channel, DiscordMember member, int cardID)
        {
            if (MyConditions.PlayerHasTheCardId(member, cardID)) return true;
            else
            {
                await channel.SendMessageAsync("O mestre não possui o id de carta especificada");
                return false;
            }
        }


        public static async Task<bool> PlayerHasTheCoins(DiscordChannel channel, DiscordMember member, int coinsQuant)
        {
            if (MyConditions.PlayerHasTheCoins(member, coinsQuant)) return true;
            else
            {
                await channel.SendMessageAsync("O mestre das cartas não possui essa quantidade de moedas");
                return false;
            }
        }


        public static async Task<bool> ChannelIsPrivate(DiscordChannel channel)
        {
            if (MyConditions.ChannelIsPrivate(channel)) return true;
            else
            {
                await channel.SendMessageAsync("Essa ação apenas pode ser chamada em meu privado...");
                return false;
            }
        }


        public static async Task<bool> IsNotTheSameMember(DiscordChannel channel, DiscordMember member1, DiscordMember member2)
        {
            if (MyConditions.IsNotTheSameMember(member1, member2)) return true;
            else
            {
                await channel.SendMessageAsync("Você não pode realizar esta ação consigo mesmo");
                return false;
            }
        }

        public static async Task<bool> IsAdequatedDuelDeckToTheGameStyle(DiscordChannel channel, DiscordMember member, int duelDeckIndex, DuelStatus duelStatus)
        {
            if (MyConditions.IsAdequatedDuelDeckToTheGameStyle(member, duelDeckIndex, duelStatus)) return true;
            else
            {
                await channel.SendMessageAsync("O Deck de Duelo não está adequado ao formato do duelo");
                return false;
            }
        }
    }
}
