using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App11.Models
{
    public class Monster : Fighter
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
}
