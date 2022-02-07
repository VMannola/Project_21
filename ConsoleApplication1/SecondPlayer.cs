using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_21
{
    class SecondPlayer: ClassBase
    {
        public override void startBet()
        {
            Console.WriteLine((nameSecondPlayer) + " отвечает!");
            while (true)
            {
                try
                {
                    betSecondPlayer = Convert.ToInt16(Console.ReadLine());
                    if (betSecondPlayer <= billSecondPlayer)
                    {
                        Console.WriteLine("\nВторой игрок поставил: (" + (betSecondPlayer) + ")");
                        billSecondPlayer = billSecondPlayer - betSecondPlayer;
                        bankCurrentSum = betSecondPlayer + betFirstPlayer;
                        Console.ReadKey();
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите число корректно!\nВаша ставка не должна превышать сумму, которая на счету у вас.");
                }

            }

        }
        public override int summationCardPoints(List<double> cards)
        {
            sumCardsSecondPlayer = 0;

            for (int i = 0; i < cardsInHandSecondPlayer.Count; i++)
            {
                sumCardsSecondPlayer = sumCardsSecondPlayer + cardsInHandSecondPlayer[i];
            }

            Console.WriteLine("Сумма карт игрока: " + (Convert.ToInt16(sumCardsSecondPlayer)));

            if (sumCardsSecondPlayer > 22)
            {
                flagTooMuchPoints = 1;                           
                Console.WriteLine("Перебор");
            }
            return Convert.ToInt16(sumCardsSecondPlayer);
        }
        public override void addCardsFromSuit()
        {
            Random rand = new Random();

            Console.Clear();
            Console.WriteLine("В банке: " + (bankCurrentSum) + "\n");
            Console.WriteLine("Старт " + (nameSecondPlayer) + "\n");

            Console.WriteLine("Cдается карта...");
            Console.WriteLine();
            Console.ReadKey();

            int ind_0 = rand.Next(suitCardsList.Count - 1);
            removeCardFromSuit(suitCardsList, suitCardsList[ind_0]);
            cardsInHandSecondPlayer.Add(suitCardsList[ind_0]);
            displayCard(cardsInHandSecondPlayer);

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Сдается еще одна карта...\n");
            Console.ReadKey();
            int ind_1 = rand.Next(suitCardsList.Count - 1);
            removeCardFromSuit(suitCardsList, suitCardsList[ind_1]);
            cardsInHandSecondPlayer.Add(suitCardsList[ind_1]);
            displayCard(cardsInHandSecondPlayer);
            Console.WriteLine();

            sumCardsSecondPlayer = summationCardPoints(cardsInHandSecondPlayer);

            Console.ReadKey();
        }
        public void answerRoundThirdSecondPlayer()  
        {
            List<string> decisionCardSecondPlayerList = new List<string>() {
                "Еще карту",
                "Достаточно на этот кон"
                                                   };
            List<string> decisionCardSecondPlayerVariantTwoList = new List<string>() {
                "Еще",
                "Хватит"
                                                   };

            if (flagSecondPlayerOutThatswhyBet != 1 && flagFirstPlayerOutWithoutBet != 1 && flagTooMuchPoints != 1)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine((nameSecondPlayer) + ", как поступаем?\n");
                Console.ReadKey();
                Console.WriteLine("На руках в сумме: " + (sumCardsSecondPlayer) + ", " + (nameSecondPlayer) + "\n");
                Console.ReadKey();
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(nameSecondPlayer + " , что будет дальше?\n");
                    string decisionCardSecondPlayer = drawMenu(decisionCardSecondPlayerList);
                    switch (decisionCardSecondPlayer)
                    {
                        case "Еще карту":
                            {
                                addCardsFromSuitSecondPlayer();
                                displayCard(cardsInHandSecondPlayer);
                                sumCardsSecondPlayer = summationCardPoints(cardsInHandSecondPlayer);

                                if (flagTooMuchPoints == 1)
                                {
                                    flagTooMuchPoints = 0;
                                    Console.WriteLine("Перебор!");
                                    Console.ReadKey();
                                    return;
                                }

                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Текущая сумма карт: " + (sumCardsSecondPlayer) + "\n");

                                    displayCard(cardsInHandSecondPlayer);

                                    Console.WriteLine();
                                    Console.WriteLine("А дальше-то что? (С)");

                                    string decisionCardSecondPlayerVariantTwo = drawMenu(decisionCardSecondPlayerVariantTwoList);
                                    switch (decisionCardSecondPlayerVariantTwo)
                                    {

                                        case "Еще":
                                            {
                                                addCardsFromSuitSecondPlayer();
                                                displayCard(cardsInHandSecondPlayer);
                                                sumCardsSecondPlayer = summationCardPoints(cardsInHandSecondPlayer);

                                                if (flagTooMuchPoints == 1)
                                                {
                                                    Console.WriteLine("Перебор!");
                                                    Console.ReadKey();
                                                    flagTooMuchPoints = 0;
                                                    return;
                                                }
                                                while (true)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Текущая сумма карт: " + (sumCardsSecondPlayer) + "\n");

                                                    displayCard(cardsInHandSecondPlayer);

                                                    Console.WriteLine();
                                                    Console.WriteLine("Ну и?(С)");
                                                    string decisionCardSecondPlayerVariantThree = drawMenu(decisionCardSecondPlayerVariantTwoList);
                                                    switch (decisionCardSecondPlayerVariantThree)
                                                    {
                                                        case "Еще":
                                                            {
                                                                addCardsFromSuitSecondPlayer();
                                                                displayCard(cardsInHandSecondPlayer);
                                                                sumCardsSecondPlayer = summationCardPoints(cardsInHandSecondPlayer);
                                                                flagOneMoreCard = 1;             
                                                                return;
                                                            }
                                                        case "Хватит":
                                                            {
                                                                flagEnoughCardsInHand = 1;             
                                                                sumCardsSecondPlayer = summationCardPoints(cardsInHandSecondPlayer);
                                                                return;
                                                            }
                                                        default: break;
                                                    }

                                                }
                                                
                                            }
                                        case "Хватит":
                                            {
                                                flagEnoughCardsInHand = 1;                             
                                                sumCardsSecondPlayer = summationCardPoints(cardsInHandSecondPlayer);
                                                return;
                                            }

                                        default: break;

                                    }
                                }
                                
                            }

                        case "Достаточно на этот кон":
                            {
                                flagEnoughCardsInHand = 1;                                            
                                sumCardsSecondPlayer = summationCardPoints(cardsInHandSecondPlayer);
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
