using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using RockPaperScissor.Data;
using System.Threading.Tasks;


namespace RockPaperScissor.Commands
{
    class DeckManagementCommands : BaseCommandModule
    {
        [Command("deck")]
        [Description("Mostra seu Deck ou de um Mestre escolhido")]
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
        [Description("Cria um Deck para sí. Se tornando um Mestre das Cartas")]
        public async Task CreateDeckCommand(CommandContext ctx)
        {
            await CreateNewDeck(ctx, ctx.User.Id);
        }


        [Command("del_deck"), Aliases("dd")]
        [RequireGuild]
        [RequireRoles(RoleCheckMode.All, new[] { AllGameData.NAME_OF_ROLE })]
        [Description("Deleta seu Deck")]
        public async Task ResetDeck(CommandContext ctx)
        {
            await DeleteSelfDeck(ctx);
        }


        [Command("del_card"), Aliases("dc")]
        [RequireGuild]
        [RequireRoles(RoleCheckMode.All, new[] { AllGameData.NAME_OF_ROLE })]
        [Description("Deleta uma Carta de seu Deck")]
        public async Task RemoveCard(CommandContext ctx, int ID)
        {
            bool sucessefulRemove = AllGameData.GetMemberDeck(ctx.Member).RemoveCard(ID);
            if (sucessefulRemove) await ctx.Channel.SendMessageAsync("Carta Removida");
            else await ctx.Channel.SendMessageAsync("ID invalido, tente novamente");
        }






        private async Task ShowCards(CommandContext ctx, ulong id)
        {
            if (AllGameData.GetMemberDeck(id) != null)
            {
                Deck deck = AllGameData.GetMemberDeck(id);
                await ctx.Channel.SendMessageAsync(deck.ToString());
            }
            else
                await ctx.Channel.SendMessageAsync("O membro não possui um deck. Para criar use 'create_deck'");
        }



        private async Task CreateNewDeck(CommandContext ctx, ulong id)
        {
            AllGameData.CreateAndAddNewDeck(id);
            DiscordMember member = await ctx.Guild.GetMemberAsync(id);
            await member.GrantRoleAsync(ctx.Guild.GetRole(AllGameData.gameRoleID));
            await ctx.Channel.SendMessageAsync("Deck Criado com Sucesso!");
        }



        private async Task DeleteSelfDeck(CommandContext ctx)
        {
            if (AllGameData.GetMemberDeck(ctx.Member).GetCoins() < 50)
            {
                await ctx.Channel.SendMessageAsync("Você precisa ter pelo menos 50ℳ para resetar o seu deck");
                return;
            }

            await ctx.Channel.SendMessageAsync("Você tem certeza que deseja deletar todo seu deck e deixar de ser um guerreiro das cartas? Envie 'sim' para confirmar");
            var interativity = ctx.Client.GetInteractivity();
            var result = await interativity.WaitForMessageAsync(m => m.Author == ctx.User && m.Content.ToLower() == "sim");

            if (!result.TimedOut)
            {
                await ctx.Channel.SendMessageAsync("Deck deletado com sucesso... Um adeus, velho mestre das cartas...");
                await ctx.Member.RevokeRoleAsync(ctx.Guild.GetRole(AllGameData.gameRoleID));
                AllGameData.DeleteDeckFromMember(ctx.Member);
            }
        }
    }
}
