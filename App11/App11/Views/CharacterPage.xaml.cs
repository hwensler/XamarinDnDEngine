using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using App11.Models;

namespace App11.Views
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterPage : ContentPage
	{
		public CharacterPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Reset the 'resume' id, since we just want to re-start here
			((App)App.Current).ResumeAtCharacterId = -1;

			// always insert if the db is empty
			//await App.Database.Initialize();

			listView.CharactersSource = await App.Database.GetCharactersAsync();
		}

		async void OnCharacterAdded(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CharacterDetailPage
			{
				BindingContext = new Character()
			});
		}

		async void OnListCharacterSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((App)App.Current).ResumeAtCharacterId = (e.SelectedItem as Character).ID;
			Debug.WriteLine("setting ResumeAtCharacterId = " + (e.SelectedItem as Character).ID);

			await Navigation.PushAsync(new CharacterDetailPage
			{
				BindingContext = e.SelectedItem as Character
			});
		}
	}
}

