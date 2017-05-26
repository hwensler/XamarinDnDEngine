using System;
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
            if (Setting.battleEvents)
            {
                Random rand = new Random();
                ServerEvent currEvent = Setting.eventList[rand.Next(0, Setting.eventList.Count)];
                newBattle.battleResult.postGame.Add(currEvent.Description);
                switch (currEvent.Target)
                {
                    case ("ALL"):
                        foreach (Fighter fighter1 in fightOrder)
                        {
                            switch (currEvent.AttribMod)
                            {
                                case ("STRENGTH"):
                                    fighter1.Strength += currEvent.Tier;
                                    break;
                                case ("SPEED"):
                                    fighter1.Speed += currEvent.Tier;
                                    break;
                                case ("DEFENSE"):
                                    fighter1.Defense += currEvent.Tier;
                                    break;
                                case ("HP"):
                                    fighter1.HitPoints += currEvent.Tier;
                                    
                                    break;
                            }
                        }
                        break;
                    case ("CHARACTERALL"):
                        foreach (Fighter fighter2 in newBattle.charQueue)
                        {
                            switch (currEvent.AttribMod)
                            {
                                case ("STRENGTH"):
                                    fighter2.Strength += currEvent.Tier;
                                    break;
                                case ("SPEED"):
                                    fighter2.Speed += currEvent.Tier;
                                    break;
                                case ("DEFENSE"):
                                    fighter2.Defense += currEvent.Tier;
                                    break;
                                case ("HP"):
                                    fighter2.HitPoints += currEvent.Tier;

                                    break;
                            }
                        }
                        break;
                    case ("CHARACTERSINGLE"):
                        Fighter fighter3 = newBattle.charQueue.Peek();
                        switch (currEvent.AttribMod)
                        {
                            case ("STRENGTH"):
                                fighter3.Strength += currEvent.Tier;
                                break;
                            case ("SPEED"):
                                fighter3.Speed += currEvent.Tier;
                                break;
                            case ("DEFENSE"):
                                fighter3.Defense += currEvent.Tier;
                                break;
                            case ("HP"):
                                fighter3.HitPoints += currEvent.Tier;

                                break;
                        }
                        break;
                    case ("MONSTERAALL"):
                        foreach (Fighter fighter4 in newBattle.monstQueue)
                        {
                            switch (currEvent.AttribMod)
                            {
                                case ("STRENGTH"):
                                    fighter4.Strength += currEvent.Tier;
                                    break;
                                case ("SPEED"):
                                    fighter4.Speed += currEvent.Tier;
                                    break;
                                case ("DEFENSE"):
                                    fighter4.Defense += currEvent.Tier;
                                    break;
                                case ("HP"):
                                    fighter4.HitPoints += currEvent.Tier;

                                    break;
                            }
                        }
                        break;
                    case ("MONSTERSINGLE"):
                        Fighter fighter5 = newBattle.monstQueue.Peek();
                        switch (currEvent.AttribMod)
                        {
                            case ("STRENGTH"):
                                fighter5.Strength += currEvent.Tier;
                                break;
                            case ("SPEED"):
                                fighter5.Speed += currEvent.Tier;
                                break;
                            case ("DEFENSE"):
                                fighter5.Defense += currEvent.Tier;
                                break;
                            case ("HP"):
                                fighter5.HitPoints += currEvent.Tier;
                                break;
                        }
                        break;

                }
            }
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
                    //if isHuman, attack Monster Tank
                    if (fightOrder.Peek().isHuman)
                    {
                        Character HumanAttacker = (Character)fightOrder.Peek();
                        //if magic setting is on
                        if (Setting.magicUsage)
                        {
                            //check for magic
                            if (HumanAttacker.magicItem != null)
                            {
                                Item tome = HumanAttacker.magicItem;
                                //if affect all monster
                                if (tome.bodyPart == "MAGICALL")
                                {
                                    newBattle.battleResult.battleOutput.Add(HumanAttacker.Name + " uses " + tome.Name + "which affects all monsters!");
                                    foreach (Monster monster in newBattle.monstQueue)
                                    {
                                        switch (tome.Attribute)
                                        {
                                            case ("STRENGTH"):
                                                monster.Strength -= tome.Strength;
                                                newBattle.battleResult.battleOutput.Add(newBattle.monstQueue.Peek().Name + " loses " + tome.Strength + " " + tome.Attribute);
                                                break;
                                            case ("SPEED"):
                                                monster.Speed -= tome.Strength;
                                                newBattle.battleResult.battleOutput.Add(newBattle.monstQueue.Peek().Name + " loses " + tome.Strength + " " + tome.Attribute);
                                                break;
                                            case ("DEFENSE"):
                                                monster.Defense -= tome.Strength;
                                                newBattle.battleResult.battleOutput.Add(newBattle.monstQueue.Peek().Name + " loses " + tome.Strength + " " + tome.Attribute);
                                                break;
                                            case ("HP"):
                                                monster.HitPoints -= tome.Strength;
                                                newBattle.battleResult.battleOutput.Add(newBattle.monstQueue.Peek().Name + " loses " + tome.Strength + " " + tome.Attribute);
                                                break;

                                        }
                                    }
                                }
                                //for just direct to tank
                                else if (tome.bodyPart == "MAGICDIRECT")
                                {
                                    newBattle.battleResult.battleOutput.Add(HumanAttacker.Name + " uses " + tome.Name + "which affects " + newBattle.monstQueue.Peek().Name);
                                    switch (tome.Attribute)
                                    {
                                        case ("STRENGTH"):
                                            newBattle.monstQueue.Peek().Strength -= tome.Strength;
                                            break;
                                        case ("SPEED"):
                                            newBattle.monstQueue.Peek().Speed -= tome.Strength;
                                            break;
                                        case ("DEFENSE"):
                                            newBattle.monstQueue.Peek().Defense -= tome.Strength;
                                            break;
                                        case ("HP"):
                                            newBattle.monstQueue.Peek().HitPoints -= tome.Strength;
                                            break;
                                    }
                                    newBattle.battleResult.battleOutput.Add(newBattle.monstQueue.Peek().Name + " loses " + tome.Strength + " " + tome.Attribute);
                                }
                                //for decrementing usage
                                if (Setting.itemUsage)
                                {
                                    tome.ItemCounter--;
                                    //breaking mechanic
                                    if (tome.ItemCounter==0)
                                    {
                                        HumanAttacker.magicItem = null;
                                        newBattle.battleResult.postGame.Add(HumanAttacker.Name + " " + tome.Name + " has broke!");
                                    }
                                }
                            }
                            //do regular damage if no magic item
                            else
                            {
                                int damage = attackDamage(fightOrder.Peek(), newBattle.monstQueue.Peek());
                                newBattle.monstQueue.Peek().HitPoints -= damage;
                                newBattle.battleResult.battleOutput.Add("Monster Tank " + newBattle.monstQueue.Peek().Name + " took "
                                    + damage + " damage. They're now at " + newBattle.monstQueue.Peek().HitPoints + " HP.");
                            }
                        } 
                        //do regular damage logic if setting is off
                        else
                        {
                            int damage = attackDamage(fightOrder.Peek(), newBattle.monstQueue.Peek());
                            newBattle.monstQueue.Peek().HitPoints -= damage;
                            newBattle.battleResult.battleOutput.Add("Monster Tank " + newBattle.monstQueue.Peek().Name + " took " 
                                + damage + " damage. They're now at " + newBattle.monstQueue.Peek().HitPoints + " HP.");
                        }

                        if (Setting.itemUsage)
                        {
                            //logic for decrement item usage
                            HumanAttacker = (Character)fightOrder.Peek();
                            Item Weapon = HumanAttacker.strItem;
                            if (Weapon != null)
                            {
                                Weapon.ItemCounter--;
                                if (Weapon.ItemCounter == 0)
                                {
                                    newBattle.battleResult.postGame.Add(HumanAttacker.strItem.Name + " has broke from overuse!");
                                    HumanAttacker.strItem = null;
                                    
                                }
                            } 
                        }
                        if (!newBattle.monstQueue.Peek().isAlive())
                        {
                            newBattle.battleResult.battleOutput.Add("Monster Tank " + newBattle.monstQueue.Peek().Name + " Died");
                            newBattle.monstQueue.Dequeue();
                        }
                        fightOrder.Enqueue(fightOrder.Dequeue());
                    }
                    //Monster attack
                    else
                    {
                        //decrements all defense items for the current character
                        int damage = attackDamage(fightOrder.Peek(), newBattle.charQueue.Peek());

                        newBattle.charQueue.Peek().HitPoints -= damage;
                        newBattle.battleResult.battleOutput.Add("Character Tank " + newBattle.charQueue.Peek().Name + " took " + damage + " damage. They're now at " + newBattle.charQueue.Peek().HitPoints +" HP.");
                        
                        //logic for decrement item usage
                        if (Setting.itemUsage)
                        {
                            Character HumanDefender = (Character)newBattle.charQueue.Peek();
                            //since speed and armor are used for defence, decrement those
                            Item BodyArmor = HumanDefender.defItem;
                            Item SpeedItem = HumanDefender.speedItem;
                            //if there is a body item
                            if (BodyArmor != null)
                            {
                                BodyArmor.ItemCounter--;
                                if (BodyArmor.ItemCounter == 0)
                                {

                                    newBattle.battleResult.postGame.Add(HumanDefender.defItem.Name + " has broke from overuse!");
                                    BodyArmor = null;
                                }
                            }

                            //if there is an item
                            if (SpeedItem != null)
                            {
                                SpeedItem.ItemCounter--;
                                if (SpeedItem.ItemCounter == 0)
                                {
                                    newBattle.battleResult.postGame.Add(HumanDefender.speedItem.Name + " has broke from overuse!");
                                    SpeedItem = null;
                                    
                                }
                            } 
                        }
                        if (!newBattle.charQueue.Peek().isAlive())
                        {
                            newBattle.battleResult.battleOutput.Add("Chararacter Tank " + newBattle.charQueue.Peek().Name + " died. :(");
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

            //add if tree to alter if critical miss/hit is on
            
            if (Setting.critMiss && attacker.isHuman)
            {
                newBattle.die = 1;
            }
            else if (Setting.critHit)
            {
                newBattle.die = 20;
            }

            //for critical miss since items break before calculating damage
            if (newBattle.die == 1)
            {
                newBattle.battleResult.battleOutput.Add("Oh no! a critical miss!");

                //Drop an item

                //first store the character
                Character attackingChar = (Character)newBattle.charQueue.Peek();

                //first check if there are items
                Item DefenseItem = attackingChar.defItem;
                Item SpeedItem = attackingChar.speedItem;
                Item AttackItem = attackingChar.strItem;
                //TODO: ADD MAGIC ITEMS HERE

                //If the character has an item
                //TODO ADD MAGIC ITEM TO THIS 
                if (DefenseItem != null || SpeedItem != null || AttackItem != null)
                {
                    //pick a random item
                    int critInt = newBattle.rand.Next(0, 3);

                    //if magic int is 0, try and drop the defense item then the speed item then the attack item
                    if (critInt == 0)
                    {
                        //and it has a defense item
                        if (DefenseItem != null)
                        {
                            newBattle.battleResult.battleOutput.Add(newBattle.charQueue.Peek().Name + " drops " + attackingChar.defItem.Name + ".");
                            attackingChar.defItem = null;
                        }
                        //else if it has a speed item
                        else if (SpeedItem != null)
                        {
                            newBattle.battleResult.battleOutput.Add(newBattle.charQueue.Peek().Name + " drops " + attackingChar.speedItem.Name + ".");
                            attackingChar.speedItem = null;
                        }
                        //else if it has an attack item
                        else if (AttackItem != null)
                        {
                            newBattle.battleResult.battleOutput.Add(newBattle.charQueue.Peek().Name + " drops " + attackingChar.strItem.Name + ".");
                            attackingChar.strItem = null;
                        }
                    }

                    //else if critint is one, drop order is speed, attack defense
                    else if (critInt == 1)
                    {
                        //and it has a speed item
                        if (SpeedItem != null)
                        {
                            newBattle.battleResult.battleOutput.Add(newBattle.charQueue.Peek().Name + " drops " + attackingChar.speedItem.Name + ".");
                            attackingChar.speedItem = null;
                        }

                        //else if it has an attack item
                        else if (AttackItem != null)
                        {
                            newBattle.battleResult.battleOutput.Add(newBattle.charQueue.Peek().Name + " drops " + attackingChar.strItem.Name + ".");
                            attackingChar.strItem = null;
                        }

                        //else if it has a defense item
                        else if (DefenseItem != null)
                        {
                            newBattle.battleResult.battleOutput.Add(newBattle.charQueue.Peek().Name + " drops " + attackingChar.defItem.Name + ".");
                            attackingChar.defItem = null;
                        }

                    }

                    //else if magicInt = 2, drop order is attack, defense, speed
                    else
                    {
                        //and it has an attack item
                        if (AttackItem != null)
                        {
                            newBattle.battleResult.battleOutput.Add(newBattle.charQueue.Peek().Name + " drops " + attackingChar.strItem.Name + ".");

                            attackingChar.strItem = null;
                        }

                        //else if it has a defense item
                        else if (DefenseItem != null)
                        {
                            newBattle.battleResult.battleOutput.Add(newBattle.charQueue.Peek().Name + " drops " + attackingChar.defItem.Name + ".");

                            attackingChar.defItem = null;
                        }

                        ///else if it has a speed item
                        if (SpeedItem != null)
                        {
                            newBattle.battleResult.battleOutput.Add(newBattle.charQueue.Peek().Name + " drops " + attackingChar.speedItem.Name + ".");

                            attackingChar.speedItem = null;
                        }

                    }
                }

                //return 0 for the critical miss
                return 0;
            }



            //this is for  critical hit
            else if (newBattle.die == 20)
            {
                //do double damage
                int criticalHit = (attacker.Strength + attacker.Level) * 2;

                //critical hit output
                newBattle.battleResult.battleOutput.Add("Finally! A critical hit!");


                //return attackroll as the damage done
                return criticalHit;
            }
            
            //else, return damage according to the default battle logic
            else
            {
                //this converts your roll into the strength of the attack
                int attackRoll = newBattle.die * (attacker.Strength + attacker.Level);
                newBattle.battleResult.battleOutput.Add("Attacker " + attacker.Name + " rolls " + newBattle.die);

                newBattle.die = newBattle.rand.Next(1, 21);
                newBattle.battleResult.battleOutput.Add("Defender " + defender.Name + " rolls " + newBattle.die);
                int defenseRoll = newBattle.die * (defender.Defense + defender.Level);

                int damage = (attackRoll - defenseRoll) / 10;
                //fist fighting logic
                if (attacker.isHuman)
                {
                    Character humanFist = (Character)attacker;
                    //limit damage to 2
                    if (humanFist.strItem == null && damage > 2)
                    {
                        damage = 2;
                        newBattle.battleResult.battleOutput.Add(humanFist.Name + " doesn't have a weapon so they resort to using their fist. They do " + damage + ".");
                    }
                    else if (humanFist.strItem == null)
                    {
                        newBattle.battleResult.battleOutput.Add(humanFist.Name + " doesn't have a weapon so they resort to using their fist. They do " + damage + ".");
                    }
                }
                //miss logic
                if (damage < 0)
                {
                    damage = 0;
                }
                return damage;

            }

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
