using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_21
{
    class ThirdRound: ClassBase
    {
        public void thirdRound()
        {

            List<string> decisionAddCardFirstPlayerList = new List<string>() {
                "Еще карту",
                "Достаточно на этот кон"
                                                   };
            List<string> decisionAddCardFirstPlayerListTwoVariant = new List<string>() {
                "Еще",
                "Хватит"
                                                   };
            if (flagFirstPlayerOutWithoutBet != 1 && flagSecondPlayerOutThatswhyBet != 1)
            {
                Console.WriteLine((nameFirstPlayer) + ", как поступаем?\n");
                Console.ReadKey();
                Console.WriteLine("На руках в сумме: " + (sumCardsFirstPlayer) + ", " + (nameFirstPlayer) + "\n");
                Console.ReadKey();

                while (true)
                {

                    Console.Clear();
                    Console.WriteLine(nameFirstPlayer + " , что будет дальше?\n");

                    string decisionAddCardFirstPlayer = drawMenu(decisionAddCardFirstPlayerList);
                    switch (decisionAddCardFirstPlayer)
                    {


                        case "Еще карту":
                            {
                                addCardsFromSuit();
                                displayCard(cardsInHandFirstPlayer);
                                sumCardsFirstPlayer = summationCardPoints(cardsInHandFirstPlayer);

                                if (flagTooMuchPoints == 1)
                                {
                                    Console.WriteLine("Это поражение");
                                    Console.ReadKey();
                                    return;
                                }

                                while (true)
                                {

                                    Console.Clear();
                                    Console.WriteLine("Текущая сумма карт: " + (sumCardsFirstPlayer) + "\n");

                                    displayCard(cardsInHandFirstPlayer);

                                    Console.WriteLine();
                                    Console.WriteLine("А дальше-то что? (С)\n");

                                    string decisionAddCardFirstPlayerTwoVariant = drawMenu(decisionAddCardFirstPlayerListTwoVariant);
                                    switch (decisionAddCardFirstPlayerTwoVariant)
                                    {

                                        case "Еще":
                                            {

                                                addCardsFromSuit();
                                                displayCard(cardsInHandFirstPlayer);
                                                sumCardsFirstPlayer = summationCardPoints(cardsInHandFirstPlayer);

                                                if (flagTooMuchPoints == 1)
                                                {
                                                    Console.WriteLine("Это поражение");
                                                    Console.ReadKey();
                                                    return;
                                                }

                                                while (true)
                                                {

                                                    Console.Clear();
                                                    Console.WriteLine("Текущая сумма карт: " + (sumCardsFirstPlayer) + "\n");
                                                    displayCard(cardsInHandFirstPlayer);
                                                    Console.WriteLine();
                                                    Console.WriteLine("Ну и? (С)\n");

                                                    string decisionAddCardFirstPlayerThirdVariant = drawMenu(decisionAddCardFirstPlayerListTwoVariant);
                                                    switch (decisionAddCardFirstPlayerThirdVariant)
                                                    {

                                                        case "Еще":
                                                            {
                                                                addCardsFromSuit();
                                                                Console.WriteLine();
                                                                displayCard(cardsInHandFirstPlayer);
                                                                sumCardsFirstPlayer = summationCardPoints(cardsInHandFirstPlayer);

                                                                Console.ReadKey();

                                                                flagOneMoreCard = 1;             
                                                                return;
                                                            }
                                                        case "Хватит":
                                                            {
                                                                flagEnoughCardsInHand = 1;             
                                                                sumCardsFirstPlayer = summationCardPoints(cardsInHandFirstPlayer);
                                                                return;
                                                            }
                                                        default: break;
                                                    }

                                                } 
                                                
                                            }
                                        case "Хватит":
                                            {
                                                flagEnoughCardsInHand = 1;                             
                                                sumCardsFirstPlayer = summationCardPoints(cardsInHandFirstPlayer);
                                                return;
                                            }

                                        default: break;

                                    }
                                }
                               
                            }

                        case "Достаточно на этот кон":
                            {
                                flagEnoughCardsInHand = 1;                                            
                                sumCardsFirstPlayer = summationCardPoints(cardsInHandFirstPlayer);
                                return;
                            }
                        default: break;
                    }

                }

            }
            else return;
        }


    }
}
