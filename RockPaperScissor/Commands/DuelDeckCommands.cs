using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using RockPaperScissor.Data;
using RockPaperScissor.Util;
using System.Threading.Tasks;

namespace RockPaperScissor.Commands
{
    public class DuelDeckCommands : MyBaseModule
    {
        [Command("create_duel_deck")]
        [RequireRoles(RoleCheckMode.All, new[] {AllGameData.NAME_OF_ROLE})]
        public async Task CreateDuelDeck(CommandContext ctx, int deckIndex, params int[] cardsListIndex)
        {
            if (!await CreateDuelDataIsOk(ctx, deckIndex, cardsListIndex)) return;
            AllGameData.GetMemberDeck(ctx.User.Id).SetDuelDeck(deckIndex, cardsListIndex);
            await ctx.Channel.SendMessageAsync(GetMessager(ctx).DuelDeckActualized());
        }



        [Command("duel_deck")]
        [RequireRoles(RoleCheckMode.All, new[] { AllGameData.NAME_OF_ROLE })]
        public async Task ShowDuelDeck(CommandContext ctx)
        {
            if (!await ConditionsDiscordInterface.ChannelIsPrivate(ctx)) return;

            for (int i = 0; i < AllGameData.DUEL_DECKS_LENGTH; i++)
            {
                await ctx.Channel.SendMessageAsync(MyUtilities.GetDuelDeckCardsString(ctx.User.Id, i));
            }
        }




        private async Task<bool> CreateDuelDataIsOk(CommandContext ctx, int deckIndex, int[] cardsListIndex)
        {
            if (!await ConditionsDiscordInterface.ChannelIsPrivate(ctx)) return false;

            if (deckIndex > AllGameData.DUEL_DECKS_LENGTH || deckIndex < 0)
            {
                await ctx.Channel.SendMessageAsync(GetMessager(ctx).WrongDeckIndex());
                return false;
            }

            if (cardsListIndex.Length > AllGameData.MAX_CARDS_IN_DUEL_DECK)
            {
                await ctx.Channel.SendMessageAsync(GetMessager(ctx).MoreCardsThatIsPermitted());
                return false;
            }

            foreach (int index in cardsListIndex)
            {
                if (AllGameData.GetMemberDeck(ctx.User.Id).GetCardById(index) == null)
                {
                    await ctx.Channel.SendMessageAsync(GetMessager(ctx).InvalidCardId());
                    return false;
                }
            }

            return true;
        }

    }
}
