using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using RockPaperScissor.Data;
using RockPaperScissor.Market;
using System.Threading.Tasks;

namespace RockPaperScissor.Commands
{
    class GameMarketCommands : BaseCommandModule
    {
        SellMethod sellMethod = new SellMethod();
        OfferMethod offerMethod = new OfferMethod();
        TradeMethod tradeMethod = new TradeMethod();


        [Command("sell")]
        [RequireGuild]
        [RequireRoles(RoleCheckMode.All, new[] { AllGameData.NAME_OF_ROLE })]
        [Description("Sugere troca com um **mestre**, de **sua carta** por **dinheiro dele**")]
        public async Task MakeCardSell(CommandContext ctx, DiscordMember member, int coinsQuant, int cardID)
        {
            await sellMethod.MakeCardDeal(ctx, member, coinsQuant, cardID);
        }


        [Command("offer")]
        [RequireGuild]
        [RequireRoles(RoleCheckMode.All, new[] { AllGameData.NAME_OF_ROLE })]
        [Description("Sugere troca com um **mestre**, de **seu dinheiro** por **uma carta dele**")]
        public async Task MakeCardOffer(CommandContext ctx, DiscordMember member, int cardID, int coinsQuant)
        {
            await offerMethod.MakeCardDeal(ctx, member, cardID, coinsQuant);
        }


        [Command("trade")]
        [RequireGuild]
        [RequireRoles(RoleCheckMode.All, new[] { AllGameData.NAME_OF_ROLE })]
        [Description("Sugere troca com um **mestre**, de **sua carta** por **uma carta dele**")]
        public async Task MakeCardTrade(CommandContext ctx, DiscordMember member, int firstCardID, int secondCardID)
        {
            await tradeMethod.MakeCardDeal(ctx, member, firstCardID, secondCardID);
        }

    }
}
