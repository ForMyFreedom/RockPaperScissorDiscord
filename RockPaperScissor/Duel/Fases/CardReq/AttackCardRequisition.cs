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
    public class AttackCardRequisition : _CardRequisition
    {
        public AttackCardRequisition(CommandContext ctx, DuelStatus duelStatus) : base(ctx, duelStatus) { }

        protected override DiscordMember GetCurrentPlayer()
        {
            return duelStatus.GetAttackPlayer();
        }

        protected override string GetRequestCardMessage()
        {
            return $"Escolha dois index de cartas de seu deck de duelo para serem seu Fronte de Ataque. Separadas com um espaço";
        }

        protected override bool NeedToMarkCardAsUsed()
        {
            return false;
        }

        protected override String GetSeparationRule()
        {
            return " ";
        }



        protected override bool TryGetTheCards(string message)
        {
            if (Regex.IsMatch(message, "^[0-9]+ [0-9]+$"))
            {
                String[] cardsIndexStr = Regex.Split(message, " ");
                int[] cardsIndexInt = Array.ConvertAll(cardsIndexStr, s => int.Parse(s));
                if (IndexIsInDuelDeck(cardsIndexInt[0]) && IndexIsInDuelDeck(cardsIndexInt[1]))
                {
                    duelStatus.SetAttackFront(cardsIndexInt);
                    return true;
                }
            }
            return false;
        }






    }
}
