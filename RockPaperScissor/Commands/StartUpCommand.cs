using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using RockPaperScissor.Data;
using System.Threading.Tasks;
using RockPaperScissor.Text;

namespace RockPaperScissor.Commands
{
    class StartUpCommand : Util.MyBaseModule
    {
        [Command("start")]
        [RequireGuild]
        public async Task StartWarOfCards(CommandContext ctx)
        {
            DiscordRole role = AllGameData.TryToGetGameRole(ctx);
            if (role == null)
            {
                await ctx.Channel.SendMessageAsync($"**{GetMessager(ctx).StartWar()}**");
                DiscordRole gameRole = await ctx.Guild.CreateRoleAsync(AllGameData.NAME_OF_ROLE);
                AllGameData.gameRoleID = gameRole.Id;
                MainExecuter.RegisterDefaultCommands();
            }
            else
            {
                await ctx.Channel.SendMessageAsync(GetMessager(ctx).WarAlreadyStarted());
            }
        }
    }
}
