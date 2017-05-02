/**
 * A view model for the itemsdetail page.
 * **/
using System;
using System.Diagnostics;
using System.Threading.Tasks;

using App11.Helpers;
using App11.Models;
using App11.Views;

using Xamarin.Forms;

namespace App11.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item.Name;
            Item = item;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}