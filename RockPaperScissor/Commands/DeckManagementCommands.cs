using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using RockPaperScissor.Data;
using System.Threading.Tasks;


namespace RockPaperScissor.Commands
{
    class DeckManagementCommands : Util.MyBaseModule
    {
        [Command("deck")]
        public async Task ShowCardsCommand(CommandContext ctx)
        {
            await ShowCards(ctx, ctx.User.Id);
        }


        [Command("deck")]
        public async Task ShowCardsCommand(CommandContext ctx, DiscordMember member)
        {
            await ShowCards(ctx, member.Id);
        }


        [Command("create_deck"), Aliases("cd")]
        [RequireGuild]
        public async Task CreateDeckCommand(CommandContext ctx)
        {
            await CreateNewDeck(ctx, ctx.User.Id);
        }


        [Command("del_deck"), Aliases("dd")]
        [RequireGuild]
        [RequireRoles(RoleCheckMode.All, new[] { AllGameData.NAME_OF_ROLE })]
        public async Task ResetDeck(CommandContext ctx)
        {
            await DeleteSelfDeck(ctx);
        }


        [Command("del_card"), Aliases("dc")]
        [RequireGuild]
        [RequireRoles(RoleCheckMode.All, new[] { AllGameData.NAME_OF_ROLE })]
        public async Task RemoveCard(CommandContext ctx, int ID)
        {
            bool sucessefulRemove = AllGameData.GetMemberDeck(ctx.Member).RemoveCard(ID);
            if (sucessefulRemove) await ctx.Channel.SendMessageAsync(GetMessager(ctx).RemovedCard());
            else await ctx.Channel.SendMessageAsync(GetMessager(ctx).InvalidCardId());
        }






        private async Task ShowCards(CommandContext ctx, ulong id)
        {
            if (AllGameData.GetMemberDeck(id) != null)
            {
                Deck deck = AllGameData.GetMemberDeck(id);
                await ctx.Channel.SendMessageAsync(deck.ToString());
            }
            else
                await ctx.Channel.SendMessageAsync(GetMessager(ctx).MemberDontHaveDeck());
        }



        private async Task CreateNewDeck(CommandContext ctx, ulong id)
        {
            AllGameData.CreateAndAddNewDeck(id);
            DiscordMember member = await ctx.Guild.GetMemberAsync(id);
            await member.GrantRoleAsync(ctx.Guild.GetRole(AllGameData.gameRoleID));
            await ctx.Channel.SendMessageAsync(GetMessager(ctx).DeckCreatedSuccessfully());
        }



        private async Task DeleteSelfDeck(CommandContext ctx)
        {
            if (AllGameData.GetMemberDeck(ctx.Member).GetCoins() < 50)
            {
                await ctx.Channel.SendMessageAsync(GetMessager(ctx).NeedCoinsToReset(50));
                return;
            }

            await ctx.Channel.SendMessageAsync(GetMessager(ctx).AreYouSureToDeleteTheDeck());
            var interativity = ctx.Client.GetInteractivity();
            var result = await interativity.WaitForMessageAsync(m => m.Author == ctx.User && m.Content == ".");

            if (!result.TimedOut)
            {
                await ctx.Channel.SendMessageAsync(GetMessager(ctx).FarewellMate());
                await ctx.Member.RevokeRoleAsync(ctx.Guild.GetRole(AllGameData.gameRoleID));
                AllGameData.DeleteDeckFromMember(ctx.Member);
            }
        }
    }
}
