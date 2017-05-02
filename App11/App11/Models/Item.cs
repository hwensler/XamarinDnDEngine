using System;

namespace App11.Models
{
    public class Item : BaseDataObject
	{
        public Guid Id { get; set; }


        //the name of an item
        string name = string.Empty;
        public string Name
		{
			get { return Name; }
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

    }
}
