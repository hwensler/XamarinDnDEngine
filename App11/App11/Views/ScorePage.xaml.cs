using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App11.Models;
using App11.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
namespace App11.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScorePage : ContentPage
	{
        ScoreViewModel ScoreModel;
        HighScoresDBDataAccess HSDB;
        ObservableCollection<ScoreBoard> dispScores;
        ObservableCollection<ScoreBoard> orderedScores;
        public ScorePage ()
		{

			InitializeComponent ();
            HSDB = new HighScoresDBDataAccess();
            PostView.ItemsSource = HSDB.HighScores.OrderByDescending(i => i.currScore);
		}
        public void clearHighScores(object sender, EventArgs e)
        {
            HSDB = new HighScoresDBDataAccess();
            //This does not work perfectly, but functions well enough for testing purposes
            HSDB.clearHS();
            PostView.ItemsSource = HSDB.HighScores.OrderByDescending(i => i.currScore);
        }
        public async void goHome(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
        async void onSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var itemSelected = args.SelectedItem as ScoreBoard;
            if (itemSelected == null) return;

            //goes to detail page if no null
            await Navigation.PushAsync(new HighScoreView(itemSelected));
        }
    }
}
