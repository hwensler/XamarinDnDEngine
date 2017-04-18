using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character1
{
    class Program
    {
        static void Main(string[] args)
        {
            Character char1 = new Character(1, 1, 1, 1, 10);
            Monster monst1 = new Monster(1, 1, 1, 1, 10);

            Console.WriteLine("Testing character strength getter = " + char1.Strength);
            Console.WriteLine("Testing character defense getter = " + char1.Defense);
            Console.WriteLine("Testing character speed getter = " + char1.Speed);
            Console.WriteLine("Testing character stackOrder getter = " + char1.StackOrder);
            Console.WriteLine("Testing character hitPoints getter = " + char1.HitPoints +"\n");

            Console.WriteLine("Testing monster strength getter = " + monst1.Strength);
            Console.WriteLine("Testing monster defense getter = " + monst1.Defense);
            Console.WriteLine("Testing monster speed getter = " + monst1.Speed);
            Console.WriteLine("Testing monster stackOrder getter = " + monst1.StackOrder);
            Console.WriteLine("Testing monster hitPoints getter = " + monst1.HitPoints+ "\n");

            Console.WriteLine("Testing character strength setter = " + ++char1.Strength);
            Console.WriteLine("Testing character defense setter = " + ++char1.Defense);
            Console.WriteLine("Testing character speed setter = " + ++char1.Speed);
            Console.WriteLine("Testing character stackOrder setter = " + ++char1.StackOrder);
            Console.WriteLine("Testing character hitPoints setter = " + ++char1.HitPoints + "\n");

            monst1.Level = 2;
            char1.awardExp(200);
            Console.WriteLine("Testing character level setter = " + char1.Level);
            Console.WriteLine("Testing monster level setter = " + monst1.Level + "\n");

            Console.WriteLine("Testing character level up function, adding 100 xp to char, curr level = " +char1.Level);
            char1.awardExp(100);
            Console.WriteLine("New character level  = " + char1.Level + "\n");

            char1.adjustStats(5, 5, 0);
            monst1.adjustStats(5, 5, 0);
            Console.WriteLine("Set monster and character attack and defense to 5 \n");


            Random rand = new Random();
            int die;
            bool turn = true;
            int damage =0;
            //test of basic combat logic and interaction, plus test of isAlive() function and dealDamage 
            //I know how badly designed this section is, it is simply a test of alive functions and an intital test of battle logic.
            while (char1.isAlive() && monst1.isAlive())
            {
                int attackRoll;
                int defenseRoll;
                if (turn)
                {
                    Console.WriteLine("Char1 attacks");
                    die = rand.Next(1, 21);
                    attackRoll = die * (char1.Strength + char1.Level);
                    Console.WriteLine("Char1 rolls " + die);
                    die = rand.Next(1, 21);
                    Console.WriteLine("Monst1 rolls " + die);
                    defenseRoll = die * (monst1.Defense + monst1.Level); 
                    damage = (attackRoll - defenseRoll)/10;
                    
                    if (damage < 1)
                    {
                        Console.WriteLine("Miss!");
                    }
                    else
                    {
                        char1.doDamage(monst1, damage);
                        Console.WriteLine("Char1 does " + damage + " to monst1, lowering hitpoints to " + monst1.HitPoints);
                    }

                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Monst1 attacks");
                    die = rand.Next(1, 21);
                    attackRoll = die * (monst1.Strength + monst1.Level);
                    Console.WriteLine("Monst1 rolls " + die);
                    die = rand.Next(1, 21);
                    defenseRoll = die * (char1.Defense + char1.Level);
                    Console.WriteLine("Char1 rolls " + die);
                    damage = (attackRoll - defenseRoll)/10;

                    if (damage < 1)
                    {
                        Console.WriteLine("Miss!");
                    }
                    else
                    {
                        monst1.doDamage(char1, damage);
                        Console.WriteLine("monst1 does " + damage + " to char1, lowering hitpoints to " + char1.HitPoints);
                    }

                    Console.ReadLine();
                }
                
                turn = !turn;
             
            }

            Console.ReadLine();

            
        }
    }
}
