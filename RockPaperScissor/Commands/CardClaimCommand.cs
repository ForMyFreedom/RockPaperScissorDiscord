using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;
using RockPaperScissor.Data;
using RockPaperScissor.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissor.Commands
{
    class CardClaimCommand : BaseCommandModule
    {
        Random rng = new Random();


        [Command("claim")]
        [RequireRoles(RoleCheckMode.All, new[] { AllGameData.NAME_OF_ROLE })]
        [RequireGuild]
        [Cooldown(1, AllGameData.TIME_TO_CLAIM_IN_SECONDS, CooldownBucketType.User)]
        public async Task ClaimCard(CommandContext ctx)
        {
            if (TodayIsPremiated()) await PremiateMemberWithCard(ctx);
            else await ctx.Channel.SendMessageAsync("Você não foi premiado hoje...");

            await ctx.Channel.SendMessageAsync(
             $"Você só podera pedir novamente em {AllGameData.TIME_TO_CLAIM_IN_SECONDS / 60} minutos"
            );
        }




        private bool TodayIsPremiated()
        {
            return true;
            //return rng.Next(1, 7) > 3; ///////////////@DEBUG PROPOSE. REMOVE WHEN COMPLETE CODE
        }



        private async Task PremiateMemberWithCard(CommandContext ctx)
        {
            int focusIndex = await RequestFocusFromMember(ctx);
            if (focusIndex == -1)
            {
                await ctx.Channel.SendMessageAsync("Você cometeu um erro e por isso perdeu sua carta diária");
                return;
            }
            Card newCard = CreateCard(ctx, focusIndex);
            PrintNewCardInfo(ctx, newCard);
        }



        private async Task<int> RequestFocusFromMember(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pababéns! Hoje você foi premiado! Envie a seguinte mensagem para determinar o foco de sua carta: Impacto 'imp' / Precisão 'pre' / Encanto 'enc'");

            var interativity = ctx.Client.GetInteractivity();
            var result = await interativity.WaitForMessageAsync(m => m.Channel == ctx.Channel && m.Author == ctx.User).ConfigureAwait(false);
            if (!result.TimedOut) return GetFocusIndex(result.Result.Content);
            return -1;
        }


        private int GetFocusIndex(String emojiName)
        {
            switch (emojiName.ToLower())
            {
                case "imp":
                    return 0;
                case "pre":
                    return 1;
                case "enc":
                    return 2;
                default:
                    return -1;
            }
        }


        private Card CreateCard(CommandContext ctx, int focus)
        {
            int stars = GetRandomStars();
            int quantElements = stars * 2 + 2;
            int[] elementsDistribution = GetRandomElementsDistribuition(quantElements, focus);
            String name = GetRandomName(quantElements, focus, elementsDistribution);
            return AllGameData.AddNewCard(ctx.Member, elementsDistribution, stars, name);
        }


        private int GetRandomStars()
        {
            int value = rng.Next(1, 101);
            if (value <= 50)
            {
                return 1;
            }
            else if (value <= 75)
            {
                return 2;
            }
            else if (value <= 90)
            {
                return 3;
            }
            else if (value <= 98)
            {
                return 4;
            }
            else
            {
                return 5;
            }
        }


        private int[] GetRandomElementsDistribuition(int quantElements, int focus)
        {
            int[] values = new int[3];
            values[0] = rng.Next(0, (quantElements + 1) / 2);
            values[0] = rng.Next(0, (quantElements + 1) / 2);
            values[1] = rng.Next(0, quantElements + 1 - values[0]);
            values[2] = quantElements - values[0] - values[1];

            int[] elementsDestribution = new int[3];
            elementsDestribution[focus] = values.Max();

            List<int> x = values.ToList();
            x.RemoveAt(x.IndexOf(values.Max()));
            int[] remaingValues = x.ToArray();

            var count = 0;

            for (int i = 0; i < 3; i++)
            {
                if (elementsDestribution[i] == 0)
                {
                    elementsDestribution[i] = remaingValues[count];
                    count++;
                }
            }

            return elementsDestribution;
        }




        private String GetRandomName(int quantElements, int focus, int[] elementsDistribution)
        {
            String name = CardsNameList.GetFirstName(focus, elementsDistribution) + " ";
            name += CardsNameList.GetSecondName(quantElements);
            return name;
        }


        private void PrintNewCardInfo(CommandContext ctx, Card newCard)
        {
            ctx.Channel.SendMessageAsync("**Carta Criada com Sucesso:** " + newCard.ToString());
        }



    }
}
