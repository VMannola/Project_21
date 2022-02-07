using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Console_21
{
   public class Introduction: ClassBase
    {     
        public void introductionsMenu() {

            ClassBase displayTextFunkFromClassBase = new ClassBase(); 

            Console.Title = "21 (beta 0.8 marphin)";
            Console.SetWindowSize(100, 30);
            Console.CursorVisible = false;

            List<string> entryChoiseList = new List<string>() {
                "Вперед!",
                "Смотрим правила, и вперед!",
                "Выход"
            }; 

            Console.WriteLine("Вас приветствует игра в очко!\nВыиграй очко, а не проиграй!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Выбран режим: Игрок vs Игрок!(остальное - в разработке)");
            Console.ReadKey();

            while (true)
            {
                Console.Clear();
                string entryChoise = drawMenu(entryChoiseList);
                switch (entryChoise) {
                    case "Вперед!": {
                            Console.Clear();
                            Console.WriteLine("Погнали");
                            return;
                                    }
                    case "Смотрим правила, и вперед!": {
                            Console.Clear();
                            displayTextFunkFromClassBase.displayText("Играют двое, и не абы как, а со ставками!\nУ актора в личном кошельке по N условных единиц. Начинается действие со" + 
                                "ставки первого игрока,\nвторой отвечает, если позволяет счет или all in. Далее компьютер сдает по 2 карты.\nУ 1 игрока выбор: повысить ставку или же не рисковать." + 
                                "Далее очередь за вторым: rise, и\nожидание реакции игрока 2 (аналогия покера) или пас.\nЗатем игрок 1 решает, нужны ли ему еще карты. Если да, то вытягивает" + 
                                "1.\nВ случае перебора - автоматом проигрыш, нет - переход хода, и по аналогии.");
                        return;
                                                       }
                    case "Выход": {
                            Environment.Exit(0);
                            return;
                                  }
                    default: break;
                }
            }      
        }
        public void enterNames() {

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Введите имена\nИгрок 1...\n");

            nameFirstPlayer = Console.ReadLine();
            Console.WriteLine("\nИгрок 2...\n");

            nameSecondPlayer = Console.ReadLine();
            Console.WriteLine("\nКакая сумма у каждого в кошельке?\n");

            checkBillsForCorrectness();

            Console.Clear();
            Console.WriteLine("Сегодня играют: " + (nameFirstPlayer) + " и " + (nameSecondPlayer) + "\nУ каждого на счету: " + (billFirstPlayer) );
            Console.ReadKey();
            Console.Clear();
        }

        static void checkBillsForCorrectness()
        {
            while (true) { 
            try
            {
                billFirstPlayer = Convert.ToInt16(Console.ReadLine());
                billSecondPlayer = billFirstPlayer;
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Введите число!");
            }
        }

        }
        public void announcementCurrentScoreBeforeRound()
        {

            int playedRounds = -1;

            Console.WriteLine("В кармане у " + (nameFirstPlayer) + ": " + (billFirstPlayer) + "\n" + "В кармане у " + (nameSecondPlayer) + ": " + (billSecondPlayer) + "\n");
            playedRounds++;
            Console.WriteLine("Сыграно раундов: " + (playedRounds) + "\n");

            Console.ReadKey();
            Console.Clear();
        }
    }
}
