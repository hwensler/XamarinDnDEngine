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
            Monster monst1 = new Monster(1, 1, 1, 1, 10, 1);


            Random rand = new Random();
            int die;
            bool turn = true;
            int damage =0;
            //test of basic combat logic and interaction, plus test of isAlive() function and dealDamage 
            //I know how badly designed this section is, it is simply a test of alive functions and an intital test of battle logic.
            while (char1.IsAlive() && monst1.IsAlive())
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
                        char1.DoDamage(monst1, damage);
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
                        monst1.DoDamage(char1, damage);
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
