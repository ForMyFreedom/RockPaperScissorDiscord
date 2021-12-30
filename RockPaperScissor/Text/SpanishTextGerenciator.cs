using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.Text
{
    public class SpanishTextGerenciator : TextMessagesGerenciator
    {
        public override string GetLanguageName()
        {
            return "Spanish";
        }

        public override string GetLanguageAbbreviation()
        {
            return "es";
        }

        public override string MemberDontHaveDeck()
        {
            return "El miembro mencionado no tiene baraja";
        }

        public override string CardIdDontExist()
        {
            return "La maestro de naipes no tiene la id especificada";
        }

        public override string NotCallYourself()
        {
            return "No puedes hacer esa acción contigo mismo";
        }

        public override string NotEnoughCoins()
        {
            return "La maestro de naipes no tiene esa cantidad de monedas";
        }

        public override string OnlyPrivateCall()
        {
            return "Esta acción solo se puede llamar en mi privado...";
        }

        public override string LanguageChanged()
        {
            return "¡Idioma cambiado a español!";

        }

        public override string LanguageRefused()
        {
            return "Este idioma no existe, consulte las abreviaturas en el comando 'all_languages'";
        }

        public override string DeckDuelName()
        {
            return "Mazo de duelo";
        }

        public override string DealMessageTemplate()
        {
            return "& propone el trato: \n & \n Por & que tiene";
        }

        public override string DealDeclined()
        {
            return "rechazó su trato / el tiempo ha expirado...";
        }

        public override string DealAccepted()
        {
            return "aceptó su trato. ¡Trato cumplido!";
        }

        public override string EmojiDealReaction()
        {
            return "Reacciona a este mensaje con un emoji en caso de que aceptes el trato";
        }

        public override string LackOfGoods()
        {
            return "Tu o eso no tienes lo que dices que tienes...";
        }

        public override string DealSent()
        {
            return "¡Trato enviado!";
        }

        public override string WarAlreadyStarted()
        {
            return "La Guerra de las Cartas ya ha comenzado...";
        }

        public override string NotPremiated()
        {
            return "No fuiste premiado hoy...";
        }

        public override string LostCardByError()
        {
            return "Cometiste un error y por ello perdiste tu naipe";
        }

        public override string ExplaningPremiation()
        {
            return "¡Felicidades! ¡Fuiste premiado! Envíe el siguiente mensaje para determinar el enfoque de sus naipe: Impacto 'imp' / Precisión 'pre' / Encanto 'enc'";
        }

        public override string SuccessfulCardCreation()
        {
            return "NAIPE CREADA EXITOSAMENTE";
        }

        public override string TellAboutCooldown()
        {
            return "Solo puede solicitar nuevamente después de esta cantidad de minutos";
        }

        public override string RemovedCard()
        {
            return "Carta eliminada";
        }

        public override string InvalidCardId()
        {
            return "ID de carta no válido";
        }

        public override string NeedCoinsToReset(int quant)
        {
            return $"Necesitas al menos {quant}ℳ para reiniciar tu mazo";
        }

        public override string DeckCreatedSuccessfully()
        {
            return "¡Mazo creado con éxito!";
        }

        public override string AreYouSureToDeleteTheDeck()
        {
            return "¿Estás seguro de que quieres borrar tu mazo y dejar de ser un guerrero de cartas? Enviar una '.' para confirmar";
        }

        public override string FarewellMate()
        {
            return "Mazo eliminado con éxito... Adiós, viejo maestro de cartas...";
        }

        public override string DuelDeckActualized()
        {
            return "El Mazo de Duelo se actualizó para los nuevos valores";
        }

        public override string WrongDeckIndex()
        {
            return "El índice de la baraja es incorrecto";
        }

        public override string MoreCardsThatIsPermitted()
        {
            return "Pones más cartas de las permitidas";
        }

        public override string CantCreateAnotherDeck()
        {
            return "No puedes crear otro mazo";
        }

        public override string DuelIgnored()
        {
            return "El duelo fue ignorado...";
        }

        public override string DuelCanceled()
        {
            return "Desafortunadamente, el Duelo fue cancelado...";
        }

        public override string DuelProposalSent()
        {
            return "¡Propuesta de duelo enviada!";
        }

        public override string YouAreConvoke()
        {
            return "Estás convocado a un duelo por el duelista: ";
        }

        public override string DuelFollowsFormat()
        {
            return "El Duelo sigue el siguiente formato:";
        }

        public override string RequestConfirmationOfDuel()
        {
            return "Responde (literalmente) este mensaje con el índice de tu Mazo de Duelo elegido si quieres luchar";
        }

        public override string YouCantRepeatCard()
        {
            return "No puedes repetir cartas";
        }

        public override string DuelDeckWithIncorretFormat()
        {
            return "Mazo de Duelo no se adapta al formato de duelo";
        }

        public override string CantUseActionWhileDueling()
        {
            return "¡No puedes usar esta acción mientras estás en duelo!";
        }

        public override string ChooseWrongIndexOrBlockedCard()
        {
            return "Es posible que haya cometido un error o haya hecho referencia a una carta que está bloqueada para repartir";
        }

        public override string DuelStart()
        {
            return "¡COMIENZA EL DUELO!";
        }

        public override string DuelEnd()
        {
            return "¡EL DUELO LLEGA A SU FIN!";
        }

        public override string IsInTheAttack()
        {
            return "¡Está en ataque!";
        }

        public override string DuelWasDraw()
        {
            return "El Duelo terminó en empate, y con eso, ningún bando gana ni pierde...";
        }

        public override string YouLostByTooMuchErrors()
        {
            return "Perdiste el duelo por errores";
        }

        public override string OneMoreChanceBeforeLostTheDuel()
        {
            return "Tienes una oportunidad más antes de perder el duelo...";
        }

        public override string ChooseADefenseIndex()
        {
            return "elige un índice de cartas de tu mazo de duelo para que sea tu carta de defensa";
        }

        public override string ChooseAAttackFront()
        {
            return "Elige dos índices de cartas de tu mazo de duelo para que sean tu Frente de Ataque. Separado con un espacio";
        }

        public override string ChooseDefinitiveAttackIndex()
        {
            return "Jugador de Ataque, qué carta de tu Frente de Ataque quieres usar";
        }

        public override string ChooseDefenseElement()
        {
            return "Defensor, elija un elemento ('imp', 'pre', 'enc', 'pod') para que sea su elemento de defensa";
        }

        public override string ChooseAttackElement()
        {
            return "Atacante, elija un elemento ('imp', 'pre', 'enc', 'pod') para que sea su elemento de ataque";
        }

        public override string QuantOfCards()//@
        {
            return "Cantidad de cartas";
        }

        public override string CongratWinTurn()
        {
            return "Felicidades, &. Ganas este turno con & puntos más";
        }

        public override string CongratWinGame()
        {
            return "Felicidades, &. Ganas el duelo contra & con una maestría increíble";
        }

        public override string TheAttackWin()
        {
            return "¡Sin embargo, el ataque gana!";
        }

        public override string TheDefenseWin()
        {
            return "¡Y la defensa gana!";
        }

        public override string WinnerGetCoinsLoserMissCoins()
        {
            return "El duelista ganador recibe &ℳ, mientras que el perdedor pierde &ℳ";
        }

        public override string CantResetAfterEarlyClaim()
        {
            return "No puedes eliminar tu mazo antes de poder reclamar una nueva carta";
        }
    }
}
