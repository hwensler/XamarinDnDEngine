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
	public partial class BattleDetailPage : ContentPage
	{
        public Results battleResults;
        Queue<Fighter> charQueue;
        ScoreBoard gameScore;
        public BattleDetailPage (Results results, Queue<Fighter> _charQueue, ScoreBoard _gameScore)
		{
            
            InitializeComponent ();
            this.charQueue = _charQueue;
            this.gameScore = _gameScore;
            
            ItemsListView.ItemsSource = results.battleOutput;
            PostView.ItemsSource = results.postGame;
            
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
                if (battleResults.deadChars.Count != 0)
                {
                    foreach (Character deadChar in battleResults.deadChars)
                    {
                        gameScore.deadChars.Add(deadChar);
                    }
                }
                if (charQueue.Count != 0)
                {
                    Random itemDist = new Random();
                    int charAwarded = itemDist.Next(0, charQueue.Count);
                    gameScore.currScore += battleResults.points;
                    for (int i = 0; i < charQueue.Count; i++)
                    {
                        Character currChar = (Character)charQueue.Dequeue();
                        charQueue.Enqueue(currChar);
                        if (currChar.AwardExp((int)battleResults.points / 4))
                        {
                            battleResults.postGame.Add(currChar.Name + " leveled up to level " + currChar.Level);
                        }
                        if (i == charAwarded)
                        {
                            battleResults.postGame.Add(currChar.Name + " looted a " + battleResults.loot.Name + " which increases "
                                + battleResults.loot.Attribute + " by " + battleResults.loot.Strength);
                            if (battleResults.loot.Attribute == "Strength")
                            {
                                currChar.Strength += battleResults.loot.Strength;
                            }
                            else if (battleResults.loot.Attribute == "Defense")
                            {
                                currChar.Defense += battleResults.loot.Strength;
                            }
                            else if (battleResults.loot.Attribute == "Speed")
                            {
                                currChar.Speed += battleResults.loot.Strength;
                            }
                            else
                            {
                                currChar.HitPoints+= battleResults.loot.Strength;
                            }
                        }
                    }
                }
                await Navigation.PushAsync(new BattleDetailPage(battleResults, charQueue, gameScore));
            }
            
            

        }
    }
}
