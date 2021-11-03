using RockPaperScissor.Data;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace RockPaperScissor.Util
{
    class MySerializable
    {
        static public bool SetDataInText(String filePath)
        {
            File.WriteAllText(filePath, string.Empty);
            FileStream fileStream = File.OpenWrite(filePath);

            bool[] operationsResult = new bool[2];
            operationsResult[0] = SetGlobalGameData(fileStream);
            operationsResult[1] = SetDecksGameData(fileStream);


            fileStream.Close();
            if (MyUtilities.WasSucefullOperation(operationsResult)) return true;
            return false;
        }



        static private bool SetGlobalGameData(FileStream fileStream)
        {
            try
            {
                Object[] globalGameData = new Object[]
                {
                    //Add new Global vars here:
                    AllGameData.gameRoleID
                };
                String stringArray = SetArrayInStringArray(globalGameData) + "\n";

                fileStream.Write(GetEncoding().GetBytes(stringArray));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        static private bool SetDecksGameData(FileStream fileStream)
        {
            try
            {
                foreach (Deck deck in AllGameData.GetAllDecks())
                {
                    Object[] deckGameData = new Object[]
                    {
                        //Add new Deck vars here:
                        "d",
                        deck.GetOwner(),
                        deck.GetCoins(),
                        deck.GetIDCounter(),
                        GetStringOfArrayOfDuelDecks(deck)
                };
                    String stringDeckArray = SetArrayInStringArray(deckGameData) + "\n";
                    fileStream.Write(GetEncoding().GetBytes(stringDeckArray));
                    foreach (Card card in deck.GetAllCards())
                    {
                        Object[] cardsFromDeckGameData = new Object[]
                        {
                            //Add new Cards vars here:
                            "c",
                            card.GetName(),
                            card.GetID(),
                            card.GetImpact(),
                            card.GetPrecision(),
                            card.GetEnchant(),
                            card.GetStars(),
                        };
                        String stringCardArray = SetArrayInStringArray(cardsFromDeckGameData) + "\n";
                        fileStream.Write(GetEncoding().GetBytes(stringCardArray));
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                fileStream.Write(GetEncoding().GetBytes(e.ToString()));
                fileStream.Close();
                return false;
            }
        }



        static private String SetArrayInStringArray(Object[] array)
        {
            String stringArray = "[";
            for (int i = 0; i < array.Length; i++)
            {
                stringArray += array[i].ToString();
                if (i != array.Length - 1) stringArray += "; ";
            }
            stringArray += "]";
            return stringArray;
        }


        static private Encoding GetEncoding()
        {
            return Encoding.UTF8;
        }



        static private String GetStringOfArrayOfDuelDecks(Deck deck)
        {
            String str = "{";
            int[][] allDuelDecks = deck.GetAllDuelDecks().ToArray().Select(x => x.ToArray()).ToArray();

            for (int i = 0; i < AllGameData.DUEL_DECKS_LENGTH; i++)
            {
                str += "(" + GetDuelDeckContent(allDuelDecks, i) + ")";
                if (i + 1 < AllGameData.DUEL_DECKS_LENGTH) str += ". ";
            }

            return str + "}";
        }


        static private String GetDuelDeckContent(int[][] allDuelDecks, int index)
        {
            try
            {
                return string.Join(",", allDuelDecks[index]);
            }
            catch (Exception)
            {
                return "";
            }
        }

    }
}