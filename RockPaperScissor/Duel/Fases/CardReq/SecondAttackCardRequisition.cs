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
    public class SecondAttackCardRequisition : _CardRequisition
    {
        public SecondAttackCardRequisition(CommandContext ctx, DuelStatus duelStatus) : base(ctx, duelStatus) { }

        protected override DiscordMember GetCurrentPlayer()
        {
            return duelStatus.GetAttackPlayer();
        }

        protected override string GetRequestCardMessage()
        {
            int[] attackFront = duelStatus.GetAttackFront();
            return $"Por fim, Jogador de Ataque, qual carta de seus dois frontes de ataque deseja usar ({attackFront[0]},{attackFront[1]})?";
        }

        protected override String GetSeparationRule()
        {
            return "---";
        }

        protected override bool TryGetTheCards(string message)
        {
            if (Regex.IsMatch(message, "[0-9]+"))
            {
                int cardIndexInt = int.Parse(message);
                if (IndexIsInTheFront(cardIndexInt))
                {
                    duelStatus.SetDefinitiveAttackCardIndex(cardIndexInt);
                    return true;
                }
            }
            return false;
        }



        private bool IndexIsInTheFront(int index)
        {
            if (duelStatus.GetAttackFront().Contains(index))
            {
                return true;
            }
            return false;
        }







        protected override bool NeedToMarkCardAsUsed()
        {
            throw new NotImplementedException();
        }

    }
}
