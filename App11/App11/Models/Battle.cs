using System;
using System.Collections.Generic;
using System.Text;

namespace App11.Models
{
    public class Battle
    {
        Queue<Fighter> charQueue;
        Queue<Fighter> monstQueue = new Queue<Fighter>();
        
        //Constructor is used to set up the battle
        public Battle(Queue<Fighter> charQueue)
        {
            this.charQueue = charQueue;
            initMonstQueue();
        }

        //run the battle, maybe set this up to return a struct containing battle won/lost, score, and loot 
        public void initBattle()
        {

        }

        private void initMonstQueue()
        {
            //for now, each monster will be initialized with 5 default on all stats. 
            //later we can make this a function based on the stats from the charQueue
            for (int i =0; i <4; i++)
            {
                monstQueue.Enqueue(new Monster(5, 5, 5, i + 1, 5, 0));
            }
        }
        public int monstQueueSize()
        {
            return monstQueue.Count;
        }
    }
}
