using System;

using App11.Models;

using Xamarin.Forms;

namespace App11.Views
{
	public partial class NewItemPage : ContentPage
	{
		public Item Item { get; set; }
        ItemsDBDataAccess itemAccess;
		public NewItemPage()
		{
			InitializeComponent();

			Item = new Item
			{
				Name = "Item name",
				Description = "This is a nice description"
			};

			BindingContext = this;
		}
        public NewItemPage(Item edit)
        {
            InitializeComponent();
            itemAccess = new ItemsDBDataAccess();
            Item = edit;
            BindingContext = this;                      //bind to display the current details
        }
        //this method upon clicking of save will update the item details.
        async void Save_Clicked(object sender, EventArgs e)
        {
            itemAccess.SaveOrUpdateItem(Item);
            await Navigation.PopToRootAsync();
        }
    }
}