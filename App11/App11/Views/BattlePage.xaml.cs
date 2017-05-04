using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App11.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace App11.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BattlePage : ContentPage
	{
        public Results battleResults;
        Queue<Fighter> charQueue = new Queue<Fighter>();
        ScoreBoard gameScore = new ScoreBoard();
        public BattlePage ()
		{
			InitializeComponent ();
            for(int i =0; i<4; i++)
            {
                charQueue.Enqueue(new Character(2, 2, 2, i + 1, 10, 0, "Character " + (i+1)));
            }
		}

        /*protected override async void OnAppearing()
        {
            base.OnAppearing();
            battleStart();
            
        }
        */

        public async void battleStart(object sender, EventArgs e)
        {
            if (charQueue.Count != 0)
            {
                BattleController newBattle = new BattleController(charQueue);
                battleResults = newBattle.initBattle();
                gameScore.currScore += battleResults.points;
              
                await Navigation.PushAsync(new NewBattlePage(battleResults, charQueue, gameScore));
            }
            else
            {
                await Navigation.PushAsync(new GameOver());
            }
            
        }

	}
}
