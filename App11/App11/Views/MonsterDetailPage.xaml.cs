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
        MonstersDBDataAccess DNDDatabase;
		public MonsterDetailPage (MonsterDetailViewModel monModel)
		{
			InitializeComponent ();
            DNDDatabase = new MonstersDBDataAccess();
            BindingContext = this.MonsterModel = monModel;
        }
        async void OnDeleteClick(object sender, EventArgs args)
        {
            Monster monToDelete = MonsterModel.GetMonsterModel();
            DNDDatabase.DeleteMonster(monToDelete);
            //bring back to Monster page
            await Navigation.PushAsync(new MonstersPage());
        }

        async void OnUpdateClick(object sender, EventArgs args)
        {
            Monster MonToUpdate = MonsterModel.GetMonsterModel();
            await Navigation.PushAsync(new NewMonsterPage(MonToUpdate));
        }

    }
}
