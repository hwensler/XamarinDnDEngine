using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;


namespace App11.Models
{
    [Table("Monsters")]
    public class Monster : Fighter
    {
        //to set up for ??? appearance later
        //private bool hasEncountered = false;
      

        //default constructor for testing now
        public Monster()
        {
            this.strength = 1;
            this.defense = 1;
            this.speed = 1;
            this.stackOrder = 1;
            this.hitPoints = 1;
            this.level = 1;
            //hasEncountered = true;
        }
        //Constructor for adding in a monster
        public Monster(string name, string description)
        {
            this.name = name;
            this._description = description;
            this.strength = 1;
            this.defense = 1;
            this.speed = 1;
            this.stackOrder = 1;
            this.hitPoints = 1;
            this.level = 1;
            //hasEncountered = true;
        }
        //monster constructor
        public Monster(int strength, int defense, int speed, int stackOrder, int hitPoints, int level)
        {

            this.strength = strength;
            this.defense = defense;
            this.speed = speed;
            this.stackOrder = stackOrder;
            this.hitPoints = hitPoints;
            this.level = level;
            this.isHuman = false;
        }
        public Monster(int strength, int defense, int speed, int stackOrder, int hitPoints, int level, string name)
        {

            this.strength = strength;
            this.defense = defense;
            this.speed = speed;
            this.stackOrder = stackOrder;
            this.hitPoints = hitPoints;
            this.level = level;
            this.name = name;
            this.isHuman = false;
        }

        //adding crud features below

        //monster description
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                this._description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

    }
}
