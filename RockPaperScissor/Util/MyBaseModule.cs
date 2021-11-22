using System;
using DSharpPlus.CommandsNext;
using RockPaperScissor.Text;

namespace RockPaperScissor.Util
{
    public class MyBaseModule : BaseCommandModule
    {
        protected TextMessagesGerenciator GetMessager(CommandContext ctx)
        {
            return TextSingleton.GetMemberGerenciator(ctx.User.Id);
        }
    }
}