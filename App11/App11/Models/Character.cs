using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App11.Models
{

    public class Character : Fighter
    {
        //DISCUSSION NEEDED: Should level be made into a private variable, accesible only by experience? The problem we can run
        //into with public level variables is that if a level is added, experience is not necessarily adjusted alongside it.
        private int experience =0;
        public int Experience { get { return experience; } set { experience = value; } }
        //placholder until item implementation
        //List<DDItem> inventory = new List<DDItem> ();

        //Character constructor
        public Character(int strength, int defense, int speed, int stackOrder, int hitPoints)
        {
            this.strength = strength;
            this.defense = defense;
            this.speed = speed;
            this.stackOrder = stackOrder;
            this.hitPoints = hitPoints;
        }

        public void awardExp(int expAward)
        {
            this.experience += expAward;
            this.levelUp();
        }
        //placeholder level up logic using a new level every 100 xp points, we can of course revisit
        public void levelUp()
        {
            if (this.level < experience / 100)
            {
                level = experience / 100;
            }
        }
    }
}
