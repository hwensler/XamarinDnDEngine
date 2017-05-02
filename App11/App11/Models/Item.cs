namespace App11.Models
{
    public class Item : BaseDataObject
	{
		string text = string.Empty;

        //the name of an item
		public string Name
		{
			get { return Name; }
			set { SetProperty(ref text, value); }
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
