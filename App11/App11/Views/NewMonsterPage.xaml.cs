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
        
        public Monster Monsters { get; set; }           //to store monster to use on this page
       
        DBDataAccess monAccess;                         //start a database access
        public NewMonsterPage()
        {
            InitializeComponent();
            monAccess = new DBDataAccess();             //intialize the database
            Title = "New Entry";                        //bind from xaml page
            Monsters = new Monster                      //intialize a new monster
            {
                Name = "Name of Monster",
                Description = "I am a gruesome detail of a monster."
            };
            BindingContext = this;                      //bind it to our xaml page
        }
        //this method takes in a monster class that allows editing of its name and description only
        public NewMonsterPage(Monster edit)
        {
            InitializeComponent();
            monAccess = new DBDataAccess();
            Title = "Change Monster details";
            Monsters = edit;
            BindingContext = this;                      //bind to display the current details
        }
        //this method upon clicking of save will update the monster details.
        async void Save_Clicked(object sender, EventArgs e)
        {
            monAccess.SaveOrUpdateMonster(Monsters);
            await Navigation.PopToRootAsync();
        }

    }
}
