using System;

using App11.Models;
using App11.ViewModels;

using Xamarin.Forms;

namespace App11.Views
{
    public partial class MainMenuPage : ContentPage
    {
        MenuPageViewModel viewModel;

        public MainMenuPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MenuPageViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var page = args.SelectedItem as App11.Models.MenuPage;
            if (page == null)
                return;

            //this is where we direct button clicks the the actual pages
            if (page.Text == "Score")
            {
                await Navigation.PushAsync(new ScorePage());
            }

            else if (page.Text == "Character")
            {
                await Navigation.PushAsync(new CharacterPage());

            }
            else if (page.Text == "Inventory")
            {
                await Navigation.PushAsync(new InventoryPage());
            }

            else if (page.Text == "Monsters")
            {
                await Navigation.PushAsync(new MonstersPage());
            }

            else if (page.Text == "Items")
            {
                await Navigation.PushAsync(new ItemsPage());
            }

            else if (page.Text == "Battle")
            {
                await Navigation.PushAsync(new BattlePage());
            }
            else
            {
                return;
            }


            // Manually deselect item
            MainMenuListView.SelectedItem = null;
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
