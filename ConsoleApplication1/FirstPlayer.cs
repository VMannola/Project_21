using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_21
{
    class FirstPlayer: ClassBase
    {

        public override void startBet()
        {
            Console.WriteLine("1 игрок делает ставку!");
            while (true)
            {
                try
                {
                    betFirstPlayer = Convert.ToInt16(Console.ReadLine());
                    if (betFirstPlayer <= billFirstPlayer)
                    {
                        Console.Clear();
                        Console.WriteLine("Первый игрок ставку сделал (" + (betFirstPlayer) + ") , очередь за вторым!\n");
                        billFirstPlayer = billFirstPlayer - betFirstPlayer;
                        bankCurrentSum = betSecondPlayer + betFirstPlayer;
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите число корректно!\nВаша ставка не должна превышать сумму, которая на счету у вас.");
                }

            }

        }
        public override void addCardsFromSuit()
        {
            Random rand = new Random();

            Console.Clear();
            Console.WriteLine("В банке: " + (bankCurrentSum) + "\n");
            Console.WriteLine((nameFirstPlayer) + " получает двушку!\n");

            Console.WriteLine("\nCдается карта...");
            Console.WriteLine();
            Console.ReadKey();

            int ind_0 = rand.Next(suitCardsList.Count - 1);
            removeCardFromSuit(suitCardsList, suitCardsList[ind_0]);
            cardsInHandFirstPlayer.Add(suitCardsList[ind_0]);
            displayCard(cardsInHandFirstPlayer);

            Console.ReadKey();
            Console.WriteLine("\nСдается еще одна карта...\n");
            Console.ReadKey();
            int ind_1 = rand.Next(suitCardsList.Count - 1);
            removeCardFromSuit(suitCardsList, suitCardsList[ind_1]);
            cardsInHandFirstPlayer.Add(suitCardsList[ind_1]);
            displayCard(cardsInHandFirstPlayer);

            Console.WriteLine();

            sumCardsFirstPlayer = summationCardPoints(cardsInHandFirstPlayer);


            Console.ReadKey();
        }
        public override int summationCardPoints(List<double> cards)
        {
            sumCardsFirstPlayer = 0;

            for (int i = 0; i < cardsInHandFirstPlayer.Count; i++)
            {
                sumCardsFirstPlayer = sumCardsFirstPlayer + cardsInHandFirstPlayer[i];
            }

            Console.WriteLine("Сумма карт игрока: " + (Convert.ToInt16(sumCardsFirstPlayer)));

            if (sumCardsFirstPlayer > 22)
            {
                Console.WriteLine("Перебор");
            }
            return Convert.ToInt16(sumCardsFirstPlayer);
        }
    }
}
