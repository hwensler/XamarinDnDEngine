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
	public partial class NewBattlePage : ContentPage
	{
        public Results battleResults;
        Queue<Fighter> charQueue;
        ScoreBoard gameScore;
        public NewBattlePage (Results results, Queue<Fighter> _charQueue, ScoreBoard _gameScore)
		{
            
            InitializeComponent ();
            this.charQueue = _charQueue;
            this.gameScore = _gameScore;
            
            ItemsListView.ItemsSource = results.battleOutput;
            
        }
        /*protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = this.prevResults.battleOutput;

        }*/
        public async void battleStart(object sender, EventArgs e)
        {
            if (charQueue.Count == 0)
            {
                await Navigation.PushAsync(new GameOver(gameScore));
            }
            else
            {
                gameScore.round += 1;
                BattleController newBattle = new BattleController(charQueue);
                battleResults = newBattle.initBattle();

                if (charQueue.Count != 0)
                {
                    gameScore.currScore += battleResults.points;
                    for (int i = 0; i < charQueue.Count; i++)
                    {
                        Character currChar = (Character)charQueue.Dequeue();
                        charQueue.Enqueue(currChar);
                        if (currChar.AwardExp((int)battleResults.points / charQueue.Count))
                        {
                            battleResults.battleOutput.Add(currChar.Name + " leveled up to level " + currChar.Level);
                        }
                    }
                }
                await Navigation.PushAsync(new NewBattlePage(battleResults, charQueue, gameScore));
            }
            
            

        }
    }
}
