/**
 * A view model for the items page.
 * **/
using System;
using System.Diagnostics;
using System.Threading.Tasks;

using App11.Helpers;
using App11.Models;
using App11.Views;
using App11.Services;

using Xamarin.Forms;

namespace App11.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        //data will come from ItemsPage
        App11.Services.ItemsData data;


        public ItemsViewModel()
        {
            Title = "Look at all the items!";
            Items = new ObservableRangeCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();

                //load the data
                data = new App11.Services.ItemsData();

                //take the loaded data and put it where we can render it
                var items = data.items;
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}