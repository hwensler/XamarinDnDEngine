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
    public class Monster : Fighter, INotifyPropertyChanged
    {
        //to set up for ??? appearance later
        private bool hasEncountered = false;

       
        //default constructor for testing now
        public Monster()
        {
            this.strength = 1;
            this.defense = 1;
            this.speed = 1;
            this.stackOrder = 1;
            this.hitPoints = 1;
            this.level = 1;
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
       

        //adding crud features below

        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return Id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
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
