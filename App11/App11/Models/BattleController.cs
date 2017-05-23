﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App11.ViewModels;

namespace App11.Models
{
    public class BattleController
    {
        ItemsDBDataAccess DNDDatabase;
        Battle newBattle;
        public BattleController(Queue<Fighter> charQueue)
        {
            newBattle = new Battle(charQueue);
        }
        public BattleController()
        {
            newBattle = new Battle();
        }
        public Results initBattle()
        {
            if (newBattle.charQueue.Count == 0)
            {
                Results defaultRes = new Results();
                defaultRes.charsWon = false;
                return defaultRes;
            }
            //create battle order using speed
            Queue<Fighter> fightOrder = setOrder();

            //Now, FIGHT TO THE DEATH!
            while (newBattle.charQueue.Count != 0 && newBattle.monstQueue.Count != 0)
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
                        int damage = attackDamage(fightOrder.Peek(), newBattle.monstQueue.Peek());
                        newBattle.monstQueue.Peek().HitPoints -= damage;
                        newBattle.battleResult.battleOutput.Add("Monster Tank, " + newBattle.monstQueue.Peek().Name + ", took " + damage + " damage, now at " + newBattle.monstQueue.Peek().HitPoints);
                        if (!newBattle.monstQueue.Peek().isAlive())
                        {
                            newBattle.battleResult.battleOutput.Add("Monster Tank, " + newBattle.monstQueue.Peek().Name + ", Died");
                            newBattle.monstQueue.Dequeue();
                        }
                        fightOrder.Enqueue(fightOrder.Dequeue());
                    }
                    //Monster attack
                    else
                    {
                        int damage = attackDamage(fightOrder.Peek(), newBattle.charQueue.Peek());

                        newBattle.charQueue.Peek().HitPoints -= damage;
                        newBattle.battleResult.battleOutput.Add("Char Tank, " + newBattle.charQueue.Peek().Name + ", took " + damage + " damage, now at " + newBattle.charQueue.Peek().HitPoints);
                        if (!newBattle.charQueue.Peek().isAlive())
                        {
                            newBattle.battleResult.battleOutput.Add("Char Tank, " + newBattle.charQueue.Peek().Name + ", Died");
                            newBattle.battleResult.deadChars.Add((Character)newBattle.charQueue.Dequeue());
                            
                        }
                        fightOrder.Enqueue(fightOrder.Dequeue());
                    }
                }
            }
            //We can assign the items and exp here or in the game class.
            if (newBattle.charQueue.Count == 0)
            {
                newBattle.battleResult.postGame.Add("Monsters Win...");
                newBattle.battleResult.charsWon = false;
            }
            else
            {
                this.DNDDatabase = new ItemsDBDataAccess();
                int itemIntRand = newBattle.rand.Next(0, DNDDatabase.Items.Count);
                newBattle.battleResult.loot = DNDDatabase.Items[itemIntRand];

                //could add grammar here to have more variance with loot
                /*newBattle.battleResult.loot.Strength = 
                    (int)(newBattle.battleResult.points/5) * ((newBattle.rand.Next(0,21))/10);*/
                newBattle.battleResult.loot.Strength = newBattle.rand.Next(1, 11);
                newBattle.battleResult.postGame.Add("Characters Win!!!");
                newBattle.battleResult.charsWon = true;
            }
            return newBattle.battleResult;
        }

        private int attackDamage(Fighter attacker, Fighter defender)
        {
            newBattle.die = newBattle.rand.Next(1, 21);
            //for critical miss since items break before calculating damage
            if (newBattle.die == 1)
            {
                newBattle.battleResult.battleOutput.Add("Oh no! a critical miss!");
                //item breaking logic here
                //adjust character stats next
            }
            int attackRoll = newBattle.die * (attacker.Strength + attacker.Level);
            newBattle.battleResult.battleOutput.Add("Attacker, " + attacker.Name +", rolls " + newBattle.die);

            //for critical damage
            if (newBattle.die == 20)
            {
                attackRoll=attackRoll*2;
                newBattle.battleResult.battleOutput.Add("It's a critical! Damage x2!");
            }
            
            newBattle.die = newBattle.rand.Next(1, 21);
            newBattle.battleResult.battleOutput.Add("Defender, " + defender.Name + ", rolls " + newBattle.die);
            int defenseRoll = newBattle.die * (defender.Defense + defender.Level);
            
            int damage = (attackRoll - defenseRoll) / 10;
            
            //miss logic
            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }

        private Queue<Fighter> setOrder()
        {
            Queue<Fighter> fightOrder = new Queue<Fighter>();
            Fighter[] fightOrderArr = new Fighter[8];

            for (int i = 0; i < newBattle.charQueue.Count; i++)
            {
                Character loader = (Character)newBattle.charQueue.Dequeue();
                fightOrderArr[i] = loader;
                newBattle.charQueue.Enqueue(loader);
            }

            for (int i = 0; i < newBattle.monstQueue.Count; i++)
            {
                Monster loader = (Monster)newBattle.monstQueue.Dequeue();
                fightOrderArr[i + newBattle.charQueue.Count] = loader;
                newBattle.monstQueue.Enqueue(loader);
            }
            for (int i = 0; i < (newBattle.charQueue.Count + newBattle.monstQueue.Count); i++)
            {
                for (int j = 0; j < (newBattle.charQueue.Count + newBattle.monstQueue.Count); j++)
                {
                    if (fightOrderArr[j].Speed < fightOrderArr[i].Speed)
                    {
                        Fighter temp = fightOrderArr[i];
                        fightOrderArr[i] = fightOrderArr[j];
                        fightOrderArr[j] = temp;
                    }
                }
            }

            //UNIT TEST HERE TO MAKE SURE THAT ARR IS SORTED
            //Create the Queue for the fight order
            for (int i = 0; i < (newBattle.charQueue.Count + newBattle.monstQueue.Count); i++)
            {
                fightOrder.Enqueue(fightOrderArr[i]);
            }
            return fightOrder;


        }
        public bool testBattleLogic(Fighter x, Fighter y)
        {
            int dam = attackDamage(x, y);
            if (dam >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool testSetOrder()
        {
            Queue<Fighter> fightOrder = setOrder();
            Fighter prevFighter = fightOrder.Dequeue();
            for (int i = 0; i < fightOrder.Count; i++)
            {
                if (fightOrder.Peek().Speed > prevFighter.Speed)
                {
                    return false;
                }
                fightOrder.Dequeue();
            }
            return true;

        }
        public int monstQueueSize()
        {
            return newBattle.monstQueue.Count;
        }
        public int charQueueSize()
        {
            return newBattle.charQueue.Count;
        }
    }
}
