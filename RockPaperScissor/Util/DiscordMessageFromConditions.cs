using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using RockPaperScissor.Data;
using RockPaperScissor.Duel;
using RockPaperScissor.Text;

namespace RockPaperScissor.Util
{
    public class ConditionsDiscordInterface
    {
        public static async Task<bool> PlayerIsCardMaster(CommandContext ctx, DiscordMember member)
        {
            if (MyConditions.PlayerIsCardMaster(member)) return true;
            else
            {
                await ctx.Channel.SendMessageAsync(MyUtilities.GetMessager(ctx).MemberDontHaveDeck());
                return false;
            }
        }


        public static async Task<bool> PlayerIsCardMaster(CommandContext ctx, ulong id)
        {
            if (MyConditions.PlayerIsCardMaster(id)) return true;
            else
            {
                await ctx.Channel.SendMessageAsync(MyUtilities.GetMessager(ctx).MemberDontHaveDeck());
                return false;
            }
        }


        public static async Task<bool> PlayerHasTheCardId(CommandContext ctx, DiscordMember member, int cardID)
        {
            if (MyConditions.PlayerHasTheCardId(member, cardID)) return true;
            else
            {
                await ctx.Channel.SendMessageAsync(
                    MyUtilities.GetMessager(ctx).CardIdDontExist());
                return false;
            }
        }


        public static async Task<bool> PlayerHasTheCoins(CommandContext ctx, DiscordMember member, int coinsQuant)
        {
            if (MyConditions.PlayerHasTheCoins(member, coinsQuant)) return true;
            else
            {
                await ctx.Channel.SendMessageAsync(
                    MyUtilities.GetMessager(ctx).NotEnoughCoins());
                return false;
            }
        }


        public static async Task<bool> ChannelIsPrivate(CommandContext ctx)
        {
            if (MyConditions.ChannelIsPrivate(ctx.Channel)) return true;
            else
            {
                await ctx.Channel.SendMessageAsync(
                    MyUtilities.GetMessager(ctx).OnlyPrivateCall());
                return false;
            }
        }


        public static async Task<bool> IsNotTheSameMember(CommandContext ctx, DiscordMember member1, DiscordMember member2)
        {
            if (MyConditions.IsNotTheSameMember(member1, member2)) return true;
            else
            {
                await ctx.Channel.SendMessageAsync(
                    MyUtilities.GetMessager(ctx).NotCallYourself());
                return false;
            }
        }
      
      
        public static async Task<bool> IsAdequatedDuelDeckToTheGameStyle(CommandContext ctx, DiscordMember member, int duelDeckIndex, DuelStatus duelStatus)
        {
            if (MyConditions.IsAdequatedDuelDeckToTheGameStyle(member, duelDeckIndex, duelStatus)) return true;
            else
            {
                await ctx.Channel.SendMessageAsync(MyUtilities.GetMessager(ctx).DuelDeckWithIncorretFormat());
                return false;
            }
        }

        public static async Task<bool> IsNotDueling(CommandContext ctx, DiscordUser user)
        {
            if (MyConditions.IsNotDueling(user)) return true;
            else
            {
                await ctx.Channel.SendMessageAsync(MyUtilities.GetMessager(ctx).CantUseActionWhileDueling());
                return false;
            }
        }
    }
}
