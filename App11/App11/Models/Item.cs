using System;
using SQLite;
using System.ComponentModel;

namespace App11.Models
{
    [Table("Items")]
    public class Item : BaseDataObject
    {

        public String itemId { get; set; }

        //the name of an item
        string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        //the description of an item
        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        //the strength of the item
        public int Strength { get; set; }

        //tells what attribute (strength, defense, speed, hp) the item modifies
        public string Attribute { get; set; }

        //item usage set to 100 uses
        private int _itemCounter;
        public int ItemCounter
        {
            get
            {
                return _itemCounter;
            }
            set
            {
                _itemCounter = 100;
            }
        }
    }
        
}
