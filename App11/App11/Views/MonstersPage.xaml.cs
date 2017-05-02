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
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MonstersPage : ContentPage
	{
        //to access the database
        DBDataAccess DNDDatabase;
		public MonstersPage ()
		{
			InitializeComponent ();
            //initializing
            this.DNDDatabase = new DBDataAccess();
        }
        //display the Monsters
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //for binding to the database
            this.BindingContext = this.DNDDatabase;
        }
        //this method deals with selecting an item on the list view
        async void OnSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var itemSelected = args.SelectedItem as Monster;
            if (itemSelected == null) return;

            //goes to detail page if no null
            await Navigation.PushAsync(new MonsterDetailPage(
                new MonsterDetailViewModel(itemSelected)));

            //the listview name on the xaml page
            MonstersList.SelectedItem = null;
        }
        //add a new monster
        async void OnAddClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewMonsterPage());
        }


    }
}
