using System;
using System.Diagnostics;
using Xamarin.Forms;

using App11.Models;
using App11.Views;

namespace App11.Views
{
	public class CharacterPageCS : ContentPage
	{
		ListView listView;

		public CharacterPageCS()
		{
			Title = "Character List";

			var toolbarItem = new ToolbarItem
			{
				Text = "New Character",
				//Icon = Device.OnPlatform(null, "plus.png", "plus.png")
			};

			toolbarItem.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new CharacterDetailPage
				{
					BindingContext = new Character()
				});
			};

			ToolbarItems.Add(toolbarItem);

			listView = new ListView
			{
				Margin = new Thickness(20),
				ItemTemplate = new DataTemplate(() =>
				{
					var name_label = new Label
					{
						VerticalTextAlignment = TextAlignment.Center,
						HorizontalOptions = LayoutOptions.StartAndExpand
					};
					name_label.SetBinding(Label.TextProperty, "Name");

					var level_label = new Label
					{
						VerticalTextAlignment = TextAlignment.Center,
						HorizontalOptions = LayoutOptions.StartAndExpand
					};
					level_label.SetBinding(Label.TextProperty, "Level");

					var stackLayout = new StackLayout
					{
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Children = { name_label, level_label }
					};

					return new ViewCell { View = stackLayout };
				})
			};


			listView.ItemSelected += async (sender, e) =>
			{
				((App)App.Current).ResumeAtCharacterId = (e.SelectedItem as Character).ID;
				Debug.WriteLine("setting ResumeAtCharacterId = " + (e.SelectedItem as Character).ID);

				await Navigation.PushAsync(new CharacterDetailPage
				{
					BindingContext = e.SelectedItem as Character
				});
			};

			Content = listView;
		}
	}
}


