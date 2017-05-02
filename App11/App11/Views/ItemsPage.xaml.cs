using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App11.ViewModels;
using App11.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App11.Views
{

    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        ItemsDBDataAccess DNDDatabase;
        public ItemsPage()
        {
            InitializeComponent();
            this.DNDDatabase = new ItemsDBDataAccess();
           
        }

        //if clicked, go to the item detail page
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = this.DNDDatabase;
            //if (viewModel.Items.Count == 0)
            //{
            //    viewModel.LoadItemsCommand.Execute(null);
            //    BindingContext = viewModel = new ItemsViewModel();
                
            //}
                
        }
    }
}

