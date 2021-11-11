using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using RockPaperScissor.Data;
using System.Threading.Tasks;

namespace RockPaperScissor.Commands
{
    class LanguageCommands : BaseCommandModule
    {
        [Command("language")]
        [RequireGuild]
        public async Task GetInterfaceLanguage(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync(AllGameData.messageGerenciator.GetLanguageName());
        }


        [Command("language")]
        [RequireGuild]
        public async Task GetInterfaceLanguage(CommandContext ctx, string newLanguageAbreviation)
        {
            AllGameData.SetMessageGerenciator(newLanguageAbreviation);
            await ctx.Channel.SendMessageAsync(AllGameData.messageGerenciator.LanguageChanged());
        }
    }
}
