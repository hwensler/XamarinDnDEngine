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

        protected int experience;
        public int Experience { get { return experience; } set { this.experience = value; } }

        //placholder until item implementation
        //List<DDItem> inventory = new List<DDItem> ();

        //default constructor
        public Character()
        {
            this.strength = 1;
            this.defense = 1;
            this.speed = 1;
            this.stackOrder = 1;
            this.hitPoints = 10;
            this.experience = 0;
        }

        //Character constructor
        //Add name to constructor?
        public Character(int strength, int defense, int speed, int stackOrder, int hitPoints,int level)
        {
            this.strength = strength;
            this.defense = defense;
            this.speed = speed;
            this.stackOrder = stackOrder;
            this.hitPoints = hitPoints;
            this.experience = 0;
            this.level = level;
            this.isHuman = true;
        }

        public void AwardExp(int expAward)
        {
            this.experience += expAward;
            this.LevelUp();
        }
        //placeholder level up logic using a new level every 100 xp points, we can of course revisit
        public void LevelUp()
        {
            if (this.level < experience / 100)
            {
                level = experience / 100;
            }
        }
    }
}
