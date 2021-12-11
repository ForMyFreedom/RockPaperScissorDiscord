using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using RockPaperScissor.Data;
using RockPaperScissor.Text;
using RockPaperScissor.Util;
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
        public async Task ShowMemberLanguage(CommandContext ctx)
        {
            if (! await ConditionsDiscordInterface.PlayerIsCardMaster(ctx, ctx.User.Id)) return;
            await ctx.Channel.SendMessageAsync(GetMessager(ctx).GetLanguageName());
        }


        [Command("language")]
        public async Task ShowMemberLanguage(CommandContext ctx, string newLanguageAbbreviation)
        {
            if (!await ConditionsDiscordInterface.PlayerIsCardMaster(ctx, ctx.User.Id)) return;

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
