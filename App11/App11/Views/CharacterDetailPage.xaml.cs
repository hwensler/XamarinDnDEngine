using System;
using Xamarin.Forms;
using System.Collections.Generic;

using App11.Models;

namespace App11.Views
{
    public partial class CharacterDetailPage : ContentPage
    {
        public CharacterDetailPage()
        {
            InitializeComponent();
        }

		async void OnSaveClicked(object sender, EventArgs e)
		{
			var character = (Character)BindingContext;
			await App.Database.SaveItemAsync(character);
			await Navigation.PopAsync();
		}

		async void OnDeleteClicked(object sender, EventArgs e)
		{
			var character = (Character)BindingContext;
			await App.Database.DeleteItemAsync(character);
			await Navigation.PopAsync();
		}

		async void OnCancelClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
    }
}






