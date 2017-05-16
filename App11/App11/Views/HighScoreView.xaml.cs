using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App11.Models;
namespace App11.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HighScoreView : ContentPage
	{
        public ScoreBoard gameScore { get; set; }
        public HighScoreView (ScoreBoard displayScore)
		{
			InitializeComponent ();
            gameScore = displayScore;
            BindingContext = this.gameScore;
            //listView.ItemsSource = displayScore.deadChars;
        }

        public async void goHome(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
