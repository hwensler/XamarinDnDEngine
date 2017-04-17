using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Character1
{
    public abstract class Fighter
    {
        protected int strength;
        public int Strength { get { return strength; } set { this.strength = value; } }
        protected int defense;
        public int Defense { get { return defense; } set { this.defense = value; } }
        protected int speed;
        public int Speed { get { return speed; } set { this.speed = value; } }
        protected int stackOrder;
        public int StackOrder { get { return stackOrder; } set { this.stackOrder = value; } }
        protected int hitPoints;
        public int HitPoints { get { return hitPoints; } set { this.hitPoints = value; } }
        protected int level;
        public int Level { get { return level; } set { this.level = value; } }

        public bool isAlive() {
            if (hitPoints <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int doDamage(Fighter defender, int damage)
        {
            //do the damage to the defender
            defender.changeHP(-damage);
            return defender.hitPoints;
        }
        public void changeHP(int hpChange)
        {
            this.hitPoints += hpChange;
        }
        public void adjustStats(int strength, int defense, int speed)
        {
            this.strength += strength;
            this.defense += defense;
            this.speed += speed;
        }


    }

    

    public class Monster:Fighter
    {
        //monster constructor
        public Monster(int strength, int defense, int speed, int stackOrder, int hitPoints)
        {
            this.strength = strength;
            this.defense = defense;
            this.speed = speed;
            this.stackOrder = stackOrder;
            this.hitPoints = hitPoints;
        }
    }

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
