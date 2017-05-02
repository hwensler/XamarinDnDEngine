
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App11.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App11.ViewModels;


namespace App11.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        ItemsDBDataAccess DNDDatabase;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();
            
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            DNDDatabase = new ItemsDBDataAccess();
            BindingContext = this.viewModel = viewModel;
        }

        //async void OnDeleteClick(object sender, EventArgs args)
        //{
        //    Item ItemToDelete = this;
        //    DNDDatabase.DeleteItem(ItemToDelete);
        //    //bring back to Item page
        //    await Navigation.PushAsync(new ItemsPage());
        //}

        //async void OnUpdateClick(object sender, EventArgs args)
        //{
        //    Item ItemToUpdate = viewModel;
        //    await Navigation.PushAsync(new NewItemPage(ItemToUpdate));
        //}
    }
}
