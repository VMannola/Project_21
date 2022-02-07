using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_21
{
    class PastRound : ClassBase
    {
        public void restorationSuit(List<double> freshSuit)
        {
            freshSuit = new List<double>() {
            2.01, 2.02, 2.03, 2.04, 3.01, 3.02, 3.03, 3.04, 4.01, 4.02, 4.03, 4.04, 6.01, 6.02, 6.03, 6.04,
            7.01, 7.02, 7.03, 7.04, 8.01, 8.02, 8.03, 8.04,
            9.01, 9.02, 9.03, 9.04, 10.01, 10.02, 10.03, 10.04, 11.01, 11.02, 11.03, 11.04
        };
            suitCardsList = freshSuit;
        }
        public void announcementOfRoundResult()
        {
            if (billFirstPlayer == 0)
            {
                Console.WriteLine((nameSecondPlayer) + " одержал победу!");
            }
            else if (billSecondPlayer == 0)
            {
                Console.WriteLine((nameFirstPlayer) + " выиграл");
            }
        }
        public void removeCardsInHand(List<double> cards)
        {

            cards.Clear();
        }
        public void summingUp()
        {

            Console.Clear();
            Console.WriteLine("Подводим итоги!");
            Console.ReadKey();

            if (((sumCardsFirstPlayer > sumCardsSecondPlayer || sumCardsSecondPlayer > 21) && sumCardsFirstPlayer < 22) && flagFirstPlayerOutWithoutBet != 1)                      // Игрок 1 выиграл 
            {
                Console.WriteLine("\nОчки " + (nameFirstPlayer) + ": " + (sumCardsFirstPlayer));
                Console.WriteLine("\nОчки " + (nameSecondPlayer) + ": " + (sumCardsSecondPlayer));
                Console.WriteLine("\n" + (nameFirstPlayer) + " has won the party!");
                billFirstPlayer = billFirstPlayer + bankCurrentSum;
                bankCurrentSum = 0;
                Console.ReadKey();


            }
            else if (((sumCardsFirstPlayer < sumCardsSecondPlayer || sumCardsFirstPlayer > 21) && sumCardsSecondPlayer < 22) && flagSecondPlayerOutThatswhyBet != 1)                   // Игрок 2 выиграл 
            {
                Console.WriteLine("\nОчки " + (nameFirstPlayer) + ": " + (sumCardsFirstPlayer));
                Console.WriteLine("\nОчки " + (nameSecondPlayer) + ": " + (sumCardsSecondPlayer));
                Console.WriteLine("\n" + (nameSecondPlayer) + " has won the party!");
                billSecondPlayer = billSecondPlayer + bankCurrentSum;
                bankCurrentSum = 0;
                Console.ReadKey();

            }
            else if (sumCardsFirstPlayer == sumCardsSecondPlayer && sumCardsFirstPlayer < 22 && sumCardsSecondPlayer < 22 && (flagFirstPlayerOutWithoutBet != 1 && flagSecondPlayerOutThatswhyBet != 1))             // Ничья
            {

                Console.WriteLine("\nОчки " + (nameFirstPlayer) + ": " + (sumCardsFirstPlayer));
                Console.WriteLine("\nОчки " + (nameSecondPlayer) + ": " + (sumCardsSecondPlayer));
                Console.WriteLine("\nНичья!\n");
                billSecondPlayer = billSecondPlayer + bankCurrentSum / 2;
                billFirstPlayer = billFirstPlayer + bankCurrentSum / 2;
                bankCurrentSum = 0;
            }
            else if (((sumCardsFirstPlayer > sumCardsSecondPlayer || sumCardsSecondPlayer > 21) && sumCardsFirstPlayer < 22))
            {
                specialСombinationsToWin(1);
            }
            else if (((sumCardsFirstPlayer < sumCardsSecondPlayer || sumCardsFirstPlayer > 21) && sumCardsSecondPlayer < 22))
            {
                specialСombinationsToWin(2);
            }
            else
            {
                Console.WriteLine("Это как?");
            }
        }

    }
}
