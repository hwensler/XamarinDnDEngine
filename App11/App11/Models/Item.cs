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

        public string image { get; set; }
        public string creator { get; set; }
        public string bodyPart { get; set; }
        public Item(string _name, string _desc, int _tier, string _attrib, int _usage, string _image, string _creator,string bp)
        {
            this.bodyPart = bp;
            this.name = _name;
            this.description = _desc;
            this.Strength = _tier;
            
            switch (_attrib)
            {
                case ("STRENGTH"):
                    this.Attribute = "Strength";
                    break;
                case ("SPEED"):
                    this.Attribute = "Speed";
                    break;
                case ("DEFENSE"):
                    this.Attribute = "Defense";
                    break;
                case ("HP"):
                    this.Attribute = "HP";
                    break;
                case ("MAGICALL"):
                    this.Attribute = "MagicAll";
                    break;
                case ("MAGICDIRECT"):
                    this.Attribute = "MagicDirect";
                    break;

            }
            this._itemCounter = _usage;
            this.image = _image;
            this.creator = _creator;
        }
        public Item() { }
    }
        
}
