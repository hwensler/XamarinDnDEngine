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
	public partial class MonsterDetailPage : ContentPage
	{
        MonsterDetailViewModel MonsterModel;
        DBDataAccess DNDDatabase;
		public MonsterDetailPage (MonsterDetailViewModel monModel)
		{
			InitializeComponent ();
            DNDDatabase = new DBDataAccess();
            BindingContext = this.MonsterModel = monModel;
        }
        async void OnDeleteClick(object sender, EventArgs args)
        {
            Monster monToDelete = MonsterModel.GetMonsterModel();
            DNDDatabase.DeleteMonster(monToDelete);
            //bring back to item page
            await Navigation.PushAsync(new MonstersPage());
        }

        async void OnUpdateClick(object sender, EventArgs args)
        {
            Monster MonToUpdate = MonsterModel.GetMonsterModel();
            //await Navigation.PushAsync(new NewMonsterPage(MonToUpdate));
        }

    }
}
