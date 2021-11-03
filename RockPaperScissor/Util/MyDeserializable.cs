using RockPaperScissor.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissor.Util
{
    class MyDeserializable
    {
        static Deck actualDeck = new Deck();

        static public bool GetDataFromText(List<String> allDataText)
        {
            bool[] operationsResult = new bool[2];
            operationsResult[0] = GetGlobalGameData(allDataText);
            operationsResult[1] = GetDecksGameData(allDataText);

            if (MyUtilities.WasSucefullOperation(operationsResult)) return true;
            return false;
        }


        static private bool GetGlobalGameData(List<String> allDataText)
        {
            try
            {
                String firstLine = allDataText[0];
                String[] allGlobalGameDataArray = GetArrayFromStringArray(firstLine);

                //Add New Global Vars Here:
                AllGameData.gameRoleID = ulong.Parse(allGlobalGameDataArray[0]);
                AllGameData.SetMessageGerenciator(allGlobalGameDataArray[1]);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        static private bool GetDecksGameData(List<String> allDataText)
        {
            try
            {
                allDataText.Remove(allDataText[0]);
                foreach (String line in allDataText)
                {
                    String[] actualGameDataArray = GetArrayFromStringArray(line);
                    String typeData = (String)actualGameDataArray[0];
                    switch (typeData)
                    {
                        case "d":
                            //Add New Deck Vars Here:
                            ulong ownerID = ulong.Parse(actualGameDataArray[1]);
                            int coins = int.Parse(actualGameDataArray[2]);
                            int idCounter = int.Parse(actualGameDataArray[3]);
                            List<List<int>> duelDecks = GetDuelDeck(actualGameDataArray[4]);

                            actualDeck = new Deck(ownerID, idCounter, coins, duelDecks);
                            AllGameData.AddDeck(actualDeck);
                            actualDeck.ResetAllCards();
                            break;

                        case "c":
                            //Add New Card Vars Here:
                            String name = actualGameDataArray[1];
                            int id = int.Parse(actualGameDataArray[2]);
                            int impact = int.Parse(actualGameDataArray[3]);
                            int precision = int.Parse(actualGameDataArray[4]);
                            int enchant = int.Parse(actualGameDataArray[5]);
                            int stars = int.Parse(actualGameDataArray[6]);


                            CardCreator.CreateAndAddCardToDeck(actualDeck, name, new[] { impact, precision, enchant }, stars, id);
                            break;
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        static private String[] GetArrayFromStringArray(String text)
        {
            return text.Trim('[', ']').Split("; ");
        }






        static private List<List<int>> GetDuelDeck(String data)
        {
            List<List<String>> objArrArr = DeserializeArrayOfArray(data);

            try
            {
                return ConvertDoubleStringArrayToDoubleIntArray(objArrArr);
            }
            catch (Exception)
            {
                return new List<List<int>>(AllGameData.DUEL_DECKS_LENGTH);
            }
        }






        static private List<List<String>> DeserializeArrayOfArray(String data)
        {
            String[] stringArray = data.Trim('{', '}').Split(". ");
            List<List<String>> arrayOfArray = new List<List<String>>();

            foreach (String str in stringArray)
            {
                arrayOfArray.Add(str.Trim('(', ')').Split(",").ToList());
            }

            return arrayOfArray;
        }


        static private List<List<int>> ConvertDoubleStringArrayToDoubleIntArray(List<List<String>> doubleStrArray)
        {
            List<List<int>> doubleArrayInt = new List<List<int>>();

            for (int i = 0; i < doubleStrArray.Count; i++)
            {
                doubleArrayInt.Add(new List<int>());

                for (int j = 0; j < doubleStrArray[i].Count; j++)
                {
                    if (doubleStrArray[i][j] != "")
                    {
                        doubleArrayInt[i].Add(int.Parse(doubleStrArray[i][j]));
                    }
                }
            }

            return doubleArrayInt;
        }





        /**
        static private List<List<T>> ConvertArrayArrayType<T>(List<List<Object>> arrayArray)
        {
            List<List<T>> convertedList = new List<List<T>>();
            List<T> internalList;

            foreach(List<Object> list in arrayArray)
            {
                internalList = new List<T>();
                foreach(Object obj in list)
                {
                    internalList.Add((T)obj);
                }
                convertedList.Add(internalList);
            }

            return convertedList;
        }
        **/



    }
}
