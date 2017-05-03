using System;
using System.Collections.Generic;
using System.Text;
using App11.Models;
namespace App11.Models
{
    public class Battle
    {
        public Queue<Fighter> charQueue;
        public Queue<Fighter> monstQueue = new Queue<Fighter>();
        public Random rand = new Random();
        public int die;
        public Results battleResult = new Results();

        public Battle()
        {

        }

        //Constructor is used to set up the battle
        public Battle(Queue<Fighter> charQueue)
        {
            double difficulty = .01;
            this.charQueue = charQueue;
            int battleValue = 0;
            int hpValue = 0;
            this.battleResult.battleOutput = new System.Collections.ObjectModel.ObservableCollection<string>();
           
            for (int i = 0; i < charQueue.Count; i++)
            {
                battleValue += charQueue.Peek().Strength + charQueue.Peek().Defense +
                     charQueue.Peek().Speed;
                hpValue += charQueue.Peek().HitPoints;

            }
            if (charQueue.Count != 0)
            {
                initMonstQueue((int)(((battleValue / charQueue.Count) * 4) * difficulty),
                    (hpValue / charQueue.Count));
            }
            this.battleResult.points = (int)(((battleValue / charQueue.Count) * 4));
        }
        

        
        private void initMonstQueue(int battleValue, int hpValue)
        {
            Monster[] statDistrib = new Monster[4];
            Random statRand = new Random();
            int applyStat;
            int statNum;
            for (int i = 0; i < 4; i++)
            {
                statDistrib[i] = new Monster(0, 0, 0, i, hpValue, 0, "Monster " + (i + 1));
            }
            for (int i = 0; i < battleValue; i++)
            {
                applyStat = statRand.Next(0, 4);
                statNum = statRand.Next(0, 3);
                if (statNum == 0)
                {
                    statDistrib[applyStat % 4].Strength += 1;
                }
                else if (statNum == 1)
                {
                    statDistrib[applyStat % 4].Defense += 1;
                }
                else
                {
                    statDistrib[applyStat % 4].Speed += 1;
                }
            }
            //for now, each monster will be initialized with 5 default on all stats. 
            //later we can make this a function based on the stats from the charQueue
            for (int i = 0; i < 4; i++)
            {
                monstQueue.Enqueue(statDistrib[i]);
            }
        }
        
    }
}
