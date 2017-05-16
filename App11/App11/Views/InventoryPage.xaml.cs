using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using App11.Models;

namespace App11.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InventoryPage : ContentPage
	{
        
		public InventoryPage ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtCharacterId = -1;

            // always insert if the db is empty
            await App.Database.Initialize();

            listView.ItemsSource = await App.Database.GetCharactersAsync();
        }

        async void OnListCharacterSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var character = e.SelectedItem as Character;
            if (character == null)
                return;

            await Navigation.PushAsync(new InventoryDetailPage(character));

            listView.SelectedItem = null;
        }
    }
}
