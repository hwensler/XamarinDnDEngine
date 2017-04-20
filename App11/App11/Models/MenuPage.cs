/**
 * the MenuPage class is used on the Main Menu - or the "Games" tab.
 * */

namespace App11.Models
{
    public class MenuPage : BaseDataObject
    {
        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        //the description isn't really used, but it's here if I want it!
        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
    }
}
