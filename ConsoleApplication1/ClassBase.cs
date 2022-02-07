using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Console_21
{
    public class ClassBase {
        protected static string nameFirstPlayer = "First player";        // Значение - заглушка для отладки
        protected static string nameSecondPlayer = "Second player";      // Значение - заглушка для отладки

        protected static int billFirstPlayer = 5;                        // Значение - заглушка для отладки
        protected static int billSecondPlayer = 5;                       // Значение - заглушка для отладки
        protected static int betFirstPlayer = 4;                         // значение - заглушка для отладки
        protected static int betSecondPlayer = 4;                        // значение - заглушка для отладки  
        protected static int bankCurrentSum = 0;                         // текущая сумма в банке     

        protected static byte flagBetanswerSecondPlayerSecondRound;
        protected static byte flagEnoughCardsInHand;
        protected static byte flagOneMoreCard;
        protected static byte flagTooMuchPoints;
        protected static byte flagFirstPlayerOutWithoutBet;              
        protected static byte flagSecondPlayerOutThatswhyBet;

        protected static double sumCardsFirstPlayer = 0;
        protected static double sumCardsSecondPlayer = 0;
        static int index;

        protected static List<double> cardsInHandFirstPlayer = new List<double>();
        protected static List<double> cardsInHandSecondPlayer = new List<double>();

        protected static List<double> suitCardsList = new List<double>() {        

            2.01, 2.02, 2.03, 2.04, 3.01, 3.02, 3.03,
            3.04, 4.01, 4.02, 4.03, 4.04, 6.01, 6.02,                  // Валет -2 , дама - 3, король - 4, туз - 11
            6.03, 6.04, 7.01, 7.02, 7.03, 7.04, 8.01,                  // 01 - черви, 02 - пики, 03 - буби, 04 - крести
            8.02, 8.03, 8.04, 9.01, 9.02, 9.03, 9.04,
            10.01, 10.02, 10.03, 10.04, 11.01, 11.02,
            11.03, 11.04
                                                                         };
        
        public static string drawMenu(List<string> items)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo ckey = Console.ReadKey();

            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (index == items.Count - 1)
                {
                }
                else
                {
                    index++;
                }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0)
                {
                }
                else
                {
                    index--;
                }
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                string strReturn = items[index];
                index = 0;
                return strReturn;
            }
            else
            {
                return "";
            }
            Console.Clear();
            return "";
        }
        public void displayText(string transmittedText)
        {
            int length = transmittedText.Length;                                                              
            int cursor = 0;                                                                                       // позиция, на которо нужно вставить разрыв
            int consoleWidthMinus = 80;

            while (length > Console.WindowWidth)
            {

                string newLine = transmittedText.Substring(cursor, Console.WindowWidth - consoleWidthMinus);      // получаем новую строку, влезающую в ширину консоли
                int lineLength = newLine.LastIndexOf(' ');                                                        // находим положение последнего курсора в текущей строке

                cursor += lineLength;                                                                             // прибавляем к курсору? длину новой строки
                transmittedText.Insert(cursor, "\n");                                                             // вставляем разрыв - переход на новую строку
                length -= lineLength;                                                                             // отнимаем от длины текста длину новой строки

            }

            string[] lines = Regex.Split(transmittedText, "\r\n|\r|\n");

            for (int j = 0; j < lines.Length; j++)
            {
                Console.WriteLine(lines[j]);
            }
        }
        protected static void displayCard(List<double> cardsInHand)
        {

            for (int j = 0; j < cardsInHand.Count; j++)
            {
                int card = Convert.ToInt16(cardsInHand[j]);           
                switch (card)
                {
                    case 2: Console.WriteLine("Валет");  break;
                    case 3: Console.WriteLine("Дама");   break;
                    case 4: Console.WriteLine("Король"); break;
                    case 11: Console.WriteLine("Туз");   break;
                    case 6: Console.WriteLine("6");      break;
                    case 7: Console.WriteLine("7");      break;
                    case 8: Console.WriteLine("8");      break;
                    case 9: Console.WriteLine("9");      break;
                    case 10: Console.WriteLine("10");    break;
                    default:                             break;
                }
            }
        }
        public virtual void startBet()
        {
            Console.WriteLine("\nДелаем ставку!");
            while (true)
            {
                try
                {
                    betFirstPlayer = Convert.ToInt16(Console.ReadLine());
                    if (betFirstPlayer <= billFirstPlayer)
                    {
                        Console.Clear();
                        Console.WriteLine("\nЗакинуто: " + (betFirstPlayer) + "\n");

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
        public virtual void betSecondPlayerAnswerInSecondRound()
        {
            Console.WriteLine("Делаем ставку, " + (nameSecondPlayer));
            while (true)
            {
                try
                {
                    betSecondPlayer = Convert.ToInt16(Console.ReadLine());
                    if (betSecondPlayer <= billSecondPlayer && betSecondPlayer == betFirstPlayer)
                    {
                        Console.Clear();
                        Console.WriteLine("\nЗакинуто: " + (betSecondPlayer) + "\n");

                        billSecondPlayer = billSecondPlayer - betSecondPlayer;
                        bankCurrentSum = betSecondPlayer + betFirstPlayer;
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите число корректно!\nВаша ставка должна соответствовать ставке " + (nameFirstPlayer) + " - " + (betFirstPlayer));
                }

            }

        }
        public virtual void betHighSecondPlayer()
        {
            Console.WriteLine("Делаем ставку, " + (nameSecondPlayer));
            while (true)
            {
                try
                {
                    betSecondPlayer = Convert.ToInt16(Console.ReadLine());
                    if (betSecondPlayer <= billSecondPlayer)
                    {
                        Console.Clear();
                        Console.WriteLine("\nЗакинуто: " + (betSecondPlayer) + "\n");

                        billSecondPlayer = billSecondPlayer - betSecondPlayer;
                        bankCurrentSum = betSecondPlayer + betFirstPlayer;
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите число корректно!\nВаша ставка должна соответствовать сумме на счету: " + (billSecondPlayer));
                }
            }

        }
        public virtual void betAgreeFirstPlayer()
        {
            Console.WriteLine("Делаем ставку, " + (nameFirstPlayer));
            while (true)
            {
                try
                {
                    betFirstPlayer = Convert.ToInt16(Console.ReadLine());
                    if (betFirstPlayer <= billFirstPlayer && betSecondPlayer == betFirstPlayer)
                    {
                        Console.Clear();
                        Console.WriteLine("Уравнено!\n");
                        billFirstPlayer = billFirstPlayer - betFirstPlayer;
                        bankCurrentSum = betSecondPlayer + betFirstPlayer;
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите число корректно!\nВаша ставка должна соответствовать повышению оппонента - " + (betSecondPlayer));
                }
            }

        }
        public virtual void allIn(int flag) {

            Console.WriteLine("\nALL IN!\n");
            Console.ReadKey();
            Console.Clear();

            if (flag == 1) {
                betFirstPlayer = billFirstPlayer;
                billFirstPlayer = 0;
                bankCurrentSum = bankCurrentSum + betSecondPlayer + betFirstPlayer;
            }
            else if (flag == 2) {
                betSecondPlayer = billSecondPlayer;
                billSecondPlayer = 0;
                bankCurrentSum = bankCurrentSum + betSecondPlayer + betFirstPlayer;
            }
        
              
        }
        public void zeroedBankAndBets() {
            bankCurrentSum = 0;
            betFirstPlayer = 0;
            betSecondPlayer = 0;
        }
        public virtual void addCardsFromSuit()
        {
            Random rand = new Random();

            Console.Clear();
            Console.WriteLine("В банке: " + (bankCurrentSum) + "\n");

            Console.WriteLine("Cдается карта...");
            int ind_0 = rand.Next(suitCardsList.Count - 1);
            removeCardFromSuit(suitCardsList, suitCardsList[ind_0]);
            cardsInHandFirstPlayer.Add(suitCardsList[ind_0]);

        }   
        public virtual void addCardsFromSuitSecondPlayer()
        {
            Random rand = new Random();

            Console.Clear();
            Console.WriteLine("В банке: " + (bankCurrentSum) + "\n");

            Console.WriteLine("Cдается карта...");
            int ind_0 = rand.Next(suitCardsList.Count - 1);
            removeCardFromSuit(suitCardsList, suitCardsList[ind_0]);
            cardsInHandSecondPlayer.Add(suitCardsList[ind_0]);

        } 
        public virtual int summationCardPoints(List<double> cards)
        {
          
            flagTooMuchPoints = 0;
            double summa = 0;
        
            for (int i = 0; i < cards.Count; i++)
            {
                summa = summa + cards[i];
            }

            Console.WriteLine("\nСумма карт игрока: " + (Convert.ToInt16(summa)));

            if (summa > 22)
            {
                flagTooMuchPoints = 1;                     
                Console.WriteLine("Перебор");
            }

            return Convert.ToInt16(summa);
        }
        protected static void removeCardFromSuit(List<double> cards, double currentCard)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i] == currentCard)
                {
                    cards.Remove(cards[i]);
                }
            }
        }
        public virtual void specialСombinationsToWin(int marker) {
            switch (marker) {
                case 1: {
                        if ( (cardsInHandFirstPlayer[0] == 11.01 || cardsInHandFirstPlayer[0] == 11.02 || cardsInHandFirstPlayer[0] == 11.03 || cardsInHandFirstPlayer[0] == 11.04) && (cardsInHandFirstPlayer[1] == 11.01 || cardsInHandFirstPlayer[1] == 11.02 || cardsInHandFirstPlayer[1] == 11.03 || cardsInHandFirstPlayer[1] == 11.04 ) )
                        {
                            Console.WriteLine("\nОчки " + (nameFirstPlayer) + ": " + (sumCardsFirstPlayer));
                            Console.WriteLine("\nОчки " + (nameSecondPlayer) + ": " + (sumCardsSecondPlayer));
                            Console.WriteLine("\n" + (nameFirstPlayer) + " has won the party!");
                            billFirstPlayer = billFirstPlayer + bankCurrentSum;
                            bankCurrentSum = 0;
                            return;
                        }
                        break;
                    }
                case 2: {
                        if ((cardsInHandSecondPlayer[0] == 11.01 || cardsInHandSecondPlayer[0] == 11.02 || cardsInHandSecondPlayer[0] == 11.03 || cardsInHandSecondPlayer[0] == 11.04) && (cardsInHandSecondPlayer[1] == 11.01 || cardsInHandSecondPlayer[1] == 11.02 || cardsInHandSecondPlayer[1] == 11.03 || cardsInHandSecondPlayer[1] == 11.04))
                        {
                            Console.WriteLine("\nОчки " + (nameFirstPlayer) + ": " + (sumCardsFirstPlayer));
                            Console.WriteLine("\nОчки " + (nameSecondPlayer) + ": " + (sumCardsSecondPlayer));
                            Console.WriteLine("\n" + (nameSecondPlayer) + " has won the party!");
                            billSecondPlayer = billSecondPlayer + bankCurrentSum;
                            bankCurrentSum = 0;
                            return;
                        }
                        break;
                            
                    }
                    default: break;


            }
           
        }

                                          }
   
    }
