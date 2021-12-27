using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using RockPaperScissor.Data;
using RockPaperScissor.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System;

namespace RockPaperScissor.Util
{
    public class MyUtilities
    {
        public static DateTime START_TIME = new DateTime(2020, 1, 1);

        public static String GetEmoteStars(int stars)
        {
            String starsString = "";
            for (int i = 0; i < stars; i++) starsString += "★";
            if (starsString == "") starsString = "0☆";
            return starsString;
        }


        static public bool WasSucefullOperation(bool[] op)
        {
            List<bool> operationsResult = new List<bool>(op);
            bool isSucess = true;
            foreach (bool operation in operationsResult) isSucess = isSucess && operation;
            return isSucess;
        }



        public static String GetArrayToString(int[] array)
        {
            String str = "[";

            for (int i = 0; i < array.Length; i++)
            {
                str += array[i];
                if (array.Length > i + 1) str += ", ";
            }

            str += "]";
            return str;
        }


        public static bool TryParse(String str)
        {
            int result;
            return int.TryParse(str, out result);
        }


        public static String GetDuelDeckCardsString(ulong userId, int duelDeckIndex, int[] dontPrintThatCards = null)
        {
            if (dontPrintThatCards == null) dontPrintThatCards = Array.Empty<int>();

            String str = $"{TextSingleton.GetMemberGerenciator(userId).DeckDuelName()} {duelDeckIndex}: \n";
            int[] duelDeck = AllGameData.GetMemberDeck(userId).GetDuelDeck(duelDeckIndex).ToArray();

            foreach (int cardIndex in duelDeck)
            {
                if (!dontPrintThatCards.Contains(cardIndex))
                {
                    str += "-\t " + AllGameData.GetMemberDeck(userId).GetCardById(cardIndex) + "\n";
                }
            }

            return str;
        }



        public static int GetCircularDistanceInIntArray(int firstId, int secondId, int arrayLength, bool isHorary = true)
        {
            int distance = 0;

            while (firstId + distance != secondId)
            {
                if (distance == arrayLength - firstId - 1)
                {
                    firstId = -(distance + 1);
                }
                distance++;
            }

            if (isHorary || distance == 0) return distance;
            else return distance - arrayLength;
        }


        public static string GetElementalName(int id)
        {
            switch (id)
            {
                case 0:
                    return "IMP";
                case 1:
                    return "PRE";
                case 2:
                    return "ENC";
                case 3:
                    return "POD";
            }
            return "";
        }

        public static TextMessagesGerenciator GetMessager(CommandContext ctx)
        {
            return GetMessager(ctx.Member);
        }

        public static TextMessagesGerenciator GetMessager(DiscordMember member)
        {
            return TextSingleton.GetMemberGerenciator(member);
        }

        public static String GetFormatText(String baseMessage, object[] data)
        {
            if (data[0] == null) return baseMessage;

            Regex regex = new Regex(Regex.Escape("&"));
            String message = baseMessage;

            foreach(object obj in data)
            {
                message = regex.Replace(message, obj.ToString(), 1);
            }

            return message;
        }



        /* @With a more stable server...
         * 
        public static async void CreatePoolReaction(DiscordClient client, DiscordMessage message, String[] emojisNameList)
        {
            foreach(String emojiName in emojisNameList)
            {
                await message.CreateReactionAsync(DiscordEmoji.FromName(client, emojiName));
            }
        }
        */
    }
}
