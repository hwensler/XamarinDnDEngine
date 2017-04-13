using System;

using App11.Models;
using App11.ViewModels;

using Xamarin.Forms;

namespace App11.Views
{
	public partial class MenuPage : ContentPage
	{
		MenuPageViewModel viewModel;

		public MenuPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new MenuPageViewModel();
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
			if (item == null)
				return;

            //this is where we direct button clicks the the actual pages
            if(item.Text == "Score")
            {
                await Navigation.PushAsync(new ScorePage());
            }

            else if(item.Text =="Character")
            {
                await Navigation.PushAsync(new CharacterPage());

            }
            else if(item.Text == "Inventory")
            {
                await Navigation.PushAsync(new InventoryPage());
            }

            else if (item.Text == "Monsters")
            {
                await Navigation.PushAsync(new MonstersPage());
            }

            else if (item.Text == "Items")
            {
                await Navigation.PushAsync(new ItemsPage());
            }

            else if (item.Text == "Battle")
            {
                await Navigation.PushAsync(new BattlePage());
            }
            else
            {
                return;
            }
			

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewItemPage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0)
				viewModel.LoadItemsCommand.Execute(null);
		}
	}
}
