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
	public partial class GameOver : ContentPage
	{
		public GameOver (ScoreBoard finalScore)
		{
			InitializeComponent ();
		}
        public async void goHome(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

    }
}
