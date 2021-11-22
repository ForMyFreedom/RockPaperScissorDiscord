using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using RockPaperScissor.Data;
using RockPaperScissor.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.Commands
{
    class LanguageCommands : Util.MyBaseModule
    {
        [Command("all_languages"), Aliases(new[]{"allang"})]
        public async Task ShowAllLanguages(CommandContext ctx)
        {
            string allLanguages = "";
            foreach(TextMessagesGerenciator language in TextSingleton.GerenciatorList)
            {
                allLanguages += $"{language.GetLanguageName()} | {language.GetLanguageAbbreviation()}\n";
            }
            await ctx.Channel.SendMessageAsync(allLanguages);
        }


        [Command("language")]
        [RequireRoles(RoleCheckMode.All, new[] { AllGameData.NAME_OF_ROLE })]
        public async Task ShowMemberLanguage(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync(GetMessager(ctx).GetLanguageName());
        }


        [Command("language")]
        [RequireRoles(RoleCheckMode.All, new[] {AllGameData.NAME_OF_ROLE})]
        public async Task ShowMemberLanguage(CommandContext ctx, string newLanguageAbbreviation)
        {
            if (TextSingleton.GetGerenciator(newLanguageAbbreviation) != null)
            {
                AllGameData.GetMemberDeck(ctx.User.Id).SetLanguage(newLanguageAbbreviation);
                await ctx.Channel.SendMessageAsync(GetMessager(ctx).LanguageChanged());
            }
            else
            {
                await ctx.Channel.SendMessageAsync(GetMessager(ctx).LanguageRefused());
            }
        }
    }
}
