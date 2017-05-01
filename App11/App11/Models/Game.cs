using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App11.Models
{
    class Game
    {
        Queue<Fighter> charQueue;
        //constructor takes in the chars that are created in char creation screen
        public Game(Queue<Fighter> charQueue)
        {
            this.charQueue = charQueue;
            gameEngine();
        }

        ScoreBoard roundScore;
        
        //game engine runs to completion, calling new battles as needed, will be adjusting to return a
        //scoreboard struct
        private void gameEngine()
        {
            roundScore.currScore = 0;
            Battle currentRound;
            Results currResults;
            do
            {
                currentRound = new Battle(charQueue);
                currResults = currentRound.initBattle();
                //Readline was to stop after each round. Good place to display a round update
                //Console.ReadLine();
            } while (currResults.charsWon);
        }
        

       

    }
}
