using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Console_21
{
    class Program: ClassBase
    {
        static void Main(string[] args)
        {
            Introduction intro        = new Introduction();             
            FirstPlayer firstPlayer   = new FirstPlayer();
            SecondPlayer secondPlayer = new SecondPlayer();
            SecondRound secondRound   = new SecondRound();
            ThirdRound thirdRound     = new ThirdRound();
            PastRound pastRound       = new PastRound();
          
            intro.introductionsMenu();
            intro.enterNames();
                
            while ((billSecondPlayer != 0 && billFirstPlayer > 0) || (billFirstPlayer != 0 && billSecondPlayer > 0)) {

                intro.announcementCurrentScoreBeforeRound();

                firstPlayer.startBet();
                secondPlayer.startBet();

                firstPlayer.addCardsFromSuit();
                secondPlayer.addCardsFromSuit();  

                secondRound.secondRound(); 
                
                thirdRound.thirdRound();
                secondPlayer.answerRoundThirdSecondPlayer(); 

                pastRound.summingUp();
                pastRound.removeCardsInHand(cardsInHandFirstPlayer);
                pastRound.removeCardsInHand(cardsInHandSecondPlayer);
                pastRound.restorationSuit(suitCardsList);

                Console.ReadKey();
                Console.Clear();                                                                                                          }
                pastRound.announcementOfRoundResult();

                Console.ReadKey();
        }

    }
}
