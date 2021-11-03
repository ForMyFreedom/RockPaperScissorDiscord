using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using RockPaperScissor.Data;
using System.Threading.Tasks;

namespace RockPaperScissor.Commands
{
    class StartUpCommand : BaseCommandModule
    {
        [Command("start")]
        [RequireGuild]
        [Description("Inicia a guerra das cartas (Cria o cargo de 'Mestre das Cartas')")]
        public async Task StartWarOfCards(CommandContext ctx)
        {
            DiscordRole role = AllGameData.TryToGetGameRole(ctx);
            if (role == null)
            {
                await ctx.Channel.SendMessageAsync("**A GUERRA DAS CARTAS TEM SEU INÍCIO!**");
                DiscordRole gameRole = await ctx.Guild.CreateRoleAsync(AllGameData.NAME_OF_ROLE);
                AllGameData.gameRoleID = gameRole.Id;
                MainExecuter.RegisterDefaultCommands();
            }
            else
            {
                await ctx.Channel.SendMessageAsync("A guerra das cartas já teve seu início...");
            }
        }
    }
}
