using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character1
{
    public class Monster : Fighter
    {
        //monster constructor
        public Monster(int strength, int defense, int speed, int stackOrder, int hitPoints, int level)
        {
            this.strength = strength;
            this.defense = defense;
            this.speed = speed;
            this.stackOrder = stackOrder;
            this.hitPoints = hitPoints;
            this.level = level;
        }
    }
}
