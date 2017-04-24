using System;
using Xamarin.Forms;

using App11.Models;

namespace App11.Views
{
    public class CharacterDetailPageCS
    {
        public CharacterDetailPageCS()
        {

			Title = "Character Details";

			var nameEntry = new Entry();
			nameEntry.SetBinding(Entry.TextProperty, "Name");

			var orderEntry = new Entry();
			orderEntry.SetBinding(Entry.TextProperty, "StackOrder");

			var lvEntry = new Entry();
			lvEntry.SetBinding(Entry.TextProperty, "Level");

			var hpEntry = new Entry();
			hpEntry.SetBinding(Entry.TextProperty, "HitPoints");

			var strEntry = new Entry();
			strEntry.SetBinding(Entry.TextProperty, "Strength");

			var defEntry = new Entry();
			defEntry.SetBinding(Entry.TextProperty, "Defense");

			var spdEntry = new Entry();
			spdEntry.SetBinding(Entry.TextProperty, "Speed");


			var saveButton = new Button { Text = "Save" };
			saveButton.Clicked += async (sender, e) =>
			{
				var character = (Character)BindingContext;
				await App.Database.SaveCharacterAsync(character);
				await Navigation.PopAsync();
			};

			var deleteButton = new Button { Text = "Delete" };
			deleteButton.Clicked += async (sender, e) =>
			{
				var character = (Character)BindingContext;
				await App.Database.DeleteCharacterAsync(character);
				await Navigation.PopAsync();
			};

			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += async (sender, e) =>
			{
				await Navigation.PopAsync();
			};

			Content = new StackLayout
			{
				Margin = new Thickness(20),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children =
				{
					new Label { Text = "Character Name:" },
					nameEntry,
					new Label { Text = "Stack Order:" },
					orderEntry,
					new Label { Text = "Character Level:" },
					lvEntry,
					new Label { Text = "HP:" },
					hpEntry,
					new Label { Text = "Strength:" },
					strEntry,
					new Label { Text = "Defense:" },
					defEntry,
					new Label { Text = "Speed:" },
					spdEntry,
					saveButton,
					deleteButton,
					cancelButton
				}
			};
        }
    }
}


