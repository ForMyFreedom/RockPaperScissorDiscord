using System;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using RockPaperScissor.Text;

namespace RockPaperScissor.Util
{
    public class MyBaseModule : BaseCommandModule
    {
        protected TextMessagesGerenciator GetMessager(CommandContext ctx)
        {
            return TextSingleton.GetMemberGerenciator(ctx.User.Id);
        }

        protected TextMessagesGerenciator GetMessager(DiscordMember member)
        {
            return TextSingleton.GetMemberGerenciator(member);
        }
    }
}