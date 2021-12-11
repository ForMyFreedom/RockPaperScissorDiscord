using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using RockPaperScissor.Data;
using RockPaperScissor.Util;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RockPaperScissor.Commands
{
    public class DuelDeckCommands : BaseCommandModule
    {
        [Command("create_duel_deck")]
        public async Task CreateDuelDeck(CommandContext ctx, int deckIndex, params int[] cardsListIndex)
        {
            if (!await CreateDuelDeckDataIsOk(ctx, deckIndex, cardsListIndex)) return;
            AllGameData.GetMemberDeck(ctx.User.Id).SetDuelDeck(deckIndex, cardsListIndex);
            await ctx.Channel.SendMessageAsync($"O Deck {deckIndex} foi atualizado pelos valores {MyUtilities.GetArrayToString(cardsListIndex)}");
        }



        [Command("duel_deck")]
        public async Task ShowDuelDeck(CommandContext ctx)
        {
            if (!await ConditionsDiscordInterface.PlayerIsCardMaster(ctx.Channel, ctx.User.Id)) return;
            if (!await ConditionsDiscordInterface.ChannelIsPrivate(ctx.Channel)) return;

            for (int i = 0; i < AllGameData.DUEL_DECKS_LENGTH; i++)
            {
                await ctx.Channel.SendMessageAsync(MyUtilities.GetDuelDeckCardsString(ctx.User.Id, i));
            }
        }




        private async Task<bool> CreateDuelDeckDataIsOk(CommandContext ctx, int deckIndex, int[] cardsListIndex)
        {
            if (!await ConditionsDiscordInterface.PlayerIsCardMaster(ctx.Channel, ctx.User.Id)) return false;
            if (!await ConditionsDiscordInterface.IsNotDueling(ctx.Channel, ctx.User)) return false;
            if (!await ConditionsDiscordInterface.ChannelIsPrivate(ctx.Channel)) return false;

            if (deckIndex > AllGameData.DUEL_DECKS_LENGTH || deckIndex < 0)
            {
                await ctx.Channel.SendMessageAsync("O index do deck está errado");
                return false;
            }

            if (cardsListIndex.Length > AllGameData.MAX_CARDS_IN_DUEL_DECK)
            {
                await ctx.Channel.SendMessageAsync("Você colocou mais cartas que o permitido");
                return false;
            }

            foreach (int index in cardsListIndex)
            {
                if (AllGameData.GetMemberDeck(ctx.User.Id).GetCardById(index) == null)
                {
                    await ctx.Channel.SendMessageAsync("O Index das Cartas dadas está inválido");
                    return false;
                }
            }

            List<int> list = cardsListIndex.ToList();
            if(! list.TrueForAll(s => list.FindAll(g => g == s).Count == 1))
            {
                await ctx.Channel.SendMessageAsync("Você não pode repetir cartas");
                return false;
            }

            return true;
        }

    }
}
