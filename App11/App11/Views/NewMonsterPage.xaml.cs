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
    public partial class NewMonsterPage : ContentPage
    {

        public Monster Monsters { get; set; }
        DBDataAccess monAccess;
        public NewMonsterPage()
        {
            InitializeComponent();
            monAccess = new DBDataAccess();
            Title = "new entry";
            Monsters = new Monster
            {
                Name = "name",
                Description = "description here"
            };
            BindingContext = this;
        }
        public NewMonsterPage(Monster edit)
        {
            InitializeComponent();
            monAccess = new DBDataAccess();
            Title = "change monster";
            Monsters = edit;
            BindingContext = this;
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            monAccess.SaveOrUpdateMonster(Monsters);
            await Navigation.PopToRootAsync();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}
