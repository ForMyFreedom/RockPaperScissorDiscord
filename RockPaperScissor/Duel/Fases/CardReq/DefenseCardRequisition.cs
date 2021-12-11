using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using RockPaperScissor.Data;
using RockPaperScissor.Util;

namespace RockPaperScissor.Duel.Fases.CardReq
{
    public class DefenseCardRequisition : _CardRequisition
    {
        public DefenseCardRequisition(CommandContext ctx, DuelStatus duelStatus) : base(ctx, duelStatus) { }

        protected override DiscordMember GetCurrentPlayer()
        {
            return duelStatus.GetDefensePlayer();
        }

        protected override string GetRequestCardMessage()
        {
            return $"Agora, {GetCurrentPlayer().Mention}, escolha um index de carta de seu deck de duelo para ser sua Carta de Defesa";
        }

        protected override bool NeedToMarkCardAsUsed()
        {
            return true;
        }

        protected override String GetSeparationRule()
        {
            return "---";
        }



        protected override bool TryGetTheCards(string message)
        {
            if (Regex.IsMatch(message, "^[0-9]+$"))
            {
                int cardIndexInt = int.Parse(message);
                if (IndexIsInDuelDeck(cardIndexInt))
                {
                    duelStatus.SetDefenseCardIndex(cardIndexInt);
                    return true;
                }
            }
            return false;
        }



    }
}
