using System;
using System.Collections.Generic;
using System.Text;
using App11.Models;
namespace App11.Models
{
    public class Battle
    {
        Queue<Fighter> charQueue;
        Queue<Fighter> monstQueue = new Queue<Fighter>();
        Random rand = new Random();
        int die;
        Results battleResult = new Results();

        //Constructor is used to set up the battle
        public Battle(Queue<Fighter> charQueue)
        {
            this.charQueue = charQueue;
            initMonstQueue();
        }

        //run the battle, maybe set this up to return a struct containing battle won/lost, score, and loot 
        public Results initBattle()
        {
            //create battle order using speed
            Queue<Fighter> fightOrder = new Queue<Fighter>();
            Fighter[] fightOrderArr = new Fighter[8];

            for (int i = 0; i < charQueue.Count; i++)
            {
                Character loader = (Character)charQueue.Dequeue();
                fightOrderArr[i] = loader;
                charQueue.Enqueue(loader);
            }

            for (int i = 0; i < monstQueue.Count; i++)
            {
                Monster loader = (Monster)monstQueue.Dequeue();
                fightOrderArr[i + charQueue.Count] = loader;
                monstQueue.Enqueue(loader);
            }
            for (int i = 0; i < fightOrderArr.Length; i++)
            {
                for (int j = 0; j < fightOrderArr.Length; j++)
                {
                    if (fightOrderArr[j].Speed > fightOrderArr[i].Speed)
                    {
                        Fighter temp = fightOrderArr[i];
                        fightOrderArr[i] = fightOrderArr[j];
                        fightOrderArr[j] = temp;
                    }
                }
            }

            //UNIT TEST HERE TO MAKE SURE THAT ARR IS SORTED
            //Create the Queue for the fight order
            for (int i = 0; i < 8; i++)
            {
                fightOrder.Enqueue(fightOrderArr[i]);
            }

            //Now, FIGHT TO THE DEATH!
            while (charQueue.Count != 0 && monstQueue.Count != 0)
            {
                //if the fighter is dead, it does not get to attack and is removed from the fight order
                if (!fightOrder.Peek().isAlive())
                {
                    fightOrder.Dequeue();
                }
                //otherwise, attack the other teams tank
                else
                {
                    //if isHuman, attach Monster Tank
                    if (fightOrder.Peek().isHuman)
                    {
                        die = rand.Next(1, 21);
                        int attackRoll = die * (fightOrder.Peek().Strength + fightOrder.Peek().Level);
                        Console.WriteLine("Char rolls " + die);
                        die = rand.Next(1, 21);
                        Console.WriteLine("Monst rolls " + die);
                        int defenseRoll = die * (monstQueue.Peek().Defense + monstQueue.Peek().Level);
                        int damage = (attackRoll - defenseRoll) / 10;

                        //miss logic
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        //deal damage
                        monstQueue.Peek().HitPoints -= damage;
                        Console.WriteLine("Monster Tank took " + damage + " damage, now at " + monstQueue.Peek().HitPoints);
                        if (!monstQueue.Peek().isAlive())
                        {
                            Console.WriteLine("Monster Tank Died");
                            battleResult.points += monstQueue.Peek().Level;
                            monstQueue.Dequeue();
                        }
                        fightOrder.Enqueue(fightOrder.Dequeue());
                    }
                    //Monster attack
                    else
                    {
                        die = rand.Next(1, 21);
                        int attackRoll = die * (fightOrder.Peek().Strength + fightOrder.Peek().Level);
                        Console.WriteLine("Monst rolls " + die);
                        die = rand.Next(1, 21);
                        Console.WriteLine("Char rolls " + die);
                        int defenseRoll = die * (charQueue.Peek().Defense + charQueue.Peek().Level);
                        int damage = (attackRoll - defenseRoll) / 10;

                        //miss logic
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        //deal damage
                        charQueue.Peek().HitPoints -= damage;
                        Console.WriteLine("Char Tank took " + damage + " damage, now at " + charQueue.Peek().HitPoints);
                        if (!charQueue.Peek().isAlive())
                        {
                            Console.WriteLine("Char Tank Died");
                            charQueue.Dequeue();
                        }
                        fightOrder.Enqueue(fightOrder.Dequeue());
                    }
                }
            }
            //We can assign the items and exp here or in the game class.
            if (charQueue.Count == 0)
            {
                battleResult.charsWon = false;
            }
            else
            {
                battleResult.charsWon = true;
            }
            return battleResult;
        }

        private void initMonstQueue()
        {
            //for now, each monster will be initialized with 5 default on all stats. 
            //later we can make this a function based on the stats from the charQueue
            for (int i = 0; i < 4; i++)
            {
                monstQueue.Enqueue(new Monster(5, 5, 5, i + 1, 5, 0));
            }
        }
        public int monstQueueSize()
        {
            return monstQueue.Count;
        }
        public int charQueueSize()
        {
            return charQueue.Count;
        }
    }
}
