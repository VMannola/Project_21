using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_21
{
    public class SecondRound: ClassBase
    {
        ClassBase baseClass = new ClassBase();

        public void secondRound()
        {

            List<string> choiseListPastDistribution = new List<string>() {
                "Ставка",
                "Пасс",
                                                                         };

            List<string> decisionSecondPlayerPastFirstPlayerList = new List<string>() {
                "Поддержать ставоньку",
                "В аут"
                                                                                      };
            List<string> firstPlayerDecisionPastHighBetSecondPlayerList = new List<string>() {
                "Поддержать ставку 2 игрока",
                "Слиться"
                                                                                             };

            while (true)
            {
                Console.Clear();
                Console.WriteLine((nameFirstPlayer) + " выбирает, что делать после стратовой раздачи\n");
                string choisePastStartDistribution = drawMenu(choiseListPastDistribution);
                switch (choisePastStartDistribution)
                {          
                    case "Ставка":
                        {

                            baseClass.startBet();      
                            Console.WriteLine(nameFirstPlayer + " в игре!");
                            Console.ReadKey();
                          
                            while (true)
                            {                             

                                Console.Clear();
                                Console.WriteLine((nameSecondPlayer) + " поступает опосля ставки " + (nameFirstPlayer) + "\n");

                                string decisionSecondPlayerPastFirstPlayer = drawMenu(decisionSecondPlayerPastFirstPlayerList);
                                switch (decisionSecondPlayerPastFirstPlayer)
                                {
                                    case "Поддержать ставоньку":
                                        {


                                            if (billSecondPlayer < betFirstPlayer)
                                            {
                                                allIn(2);
                                                return;
                                            }

                                            Console.Clear();
                                            Console.WriteLine("Ответим!\n");

                                            betSecondPlayerAnswerInSecondRound();
                                            flagBetanswerSecondPlayerSecondRound = 1;
                                            return;
                                        }
                                    case "В аут":
                                        flagSecondPlayerOutThatswhyBet = 1;
                                        billFirstPlayer = billFirstPlayer + bankCurrentSum;
                                        zeroedBankAndBets();
                                        return;
                                    default: break;
                                }

                            }
                           
                        }
                    case "Пасс":
                        {           

                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine((nameSecondPlayer) + " отвечает на ПАСС " + (nameFirstPlayer) + "\n");

                                string choisePastDistribution = drawMenu(choiseListPastDistribution); 
                                switch (choisePastDistribution)
                                {
                                    case "Пасс":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Раз и " + (nameSecondPlayer) + " пасует, ждем, возьмет ли еще карты " + (nameFirstPlayer) + "\n");
                                            Console.ReadKey();
                                            return;
                                        }
                                    case "Ставка":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Пощекочем " + (nameFirstPlayer) + " нервы" + "\n");
                                            betHighSecondPlayer();         

                                            while (true)
                                            {

                                                Console.Clear();
                                                Console.WriteLine((nameFirstPlayer) + " решает, что делать с повышернием ставки " + (nameSecondPlayer) + "\n");

                                                string firstPlayerDecisionPastHighBetSecondPlayer = drawMenu(firstPlayerDecisionPastHighBetSecondPlayerList);
                                                switch (firstPlayerDecisionPastHighBetSecondPlayer)
                                                {
                                                    case "Поддержать ставку 2 игрока":

                                                        if (billFirstPlayer < betSecondPlayer)
                                                        {
                                                            allIn(1);
                                                            return;
                                                        }

                                                        Console.Clear();
                                                        Console.WriteLine("Узнали и согласны!\n");

                                                        betAgreeFirstPlayer();
                                                        return;

                                                    case "Слиться":
                                                        flagFirstPlayerOutWithoutBet = 1;
                                                        Console.WriteLine((nameFirstPlayer) + " не выдерживает напора!");
                                                        billSecondPlayer = billSecondPlayer + bankCurrentSum;
                                                        zeroedBankAndBets();
                                                        return;
                                                    default: break;
                                                }


                                            }


                                           
                                        }
                                    default: break;
                                }
                            }
                        }
                   
                    default: break;
                }
            }

        }


    }
}
