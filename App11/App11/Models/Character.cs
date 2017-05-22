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
        private int timeToLevel = 5;
        public Item hpItem;
        public Item strItem;
        public Item defItem;
        public Item speedItem;

       //items list in action!
        private List<Item> inventory = new List<Item> ();

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

        public Character(int strength, int defense, int speed, int stackOrder, int hitPoints, int level, string name)
        {
            this.strength = strength;
            this.defense = defense;
            this.speed = speed;
            this.stackOrder = stackOrder;
            this.hitPoints = hitPoints;
            this.experience = 0;
            this.level = level;
            this.name = name;
            this.isHuman = true;
        }
        public bool AwardExp(int expAward)
        {
            this.experience += expAward;

            return this.LevelUp();
        }
        //placeholder level up logic using a new level every 100 xp points, we can of course revisit
        public bool LevelUp()
        {
            if (this.level < experience / 10)
            {
                int levelAward = (experience / 10) - this.level;
                for (int i =0; i < levelAward; i++)
                {
                    this.Strength++; ;
                    this.Speed++;
                    this.Defense++;
                    this.HitPoints++;
                    level++;
                    timeToLevel = (int)(timeToLevel *2);
                }
                
                return true;
            }
            return false;
        }
        public void AddItemToInv(Item item)
        {
            inventory.Add(item);
        }
        public List<Item> GetInv()
        {
            return inventory;
        }

		public string getCharInfo()
		{
			string charInfo = "";

			charInfo = "--" + Name + "--" + '\n' +
					   "Lv: " + Level + '\n' +
					   "Strength:" + Strength + '\n' +
					   "Speed: " + Speed + '\n' +
					   "Defense: " + Defense;
			return charInfo;
		}
    }
}
