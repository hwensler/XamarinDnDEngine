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
                                if (currChar.strItem == null)
                                {
                                    currChar.strItem = battleResults.loot;
                                    currChar.Strength += battleResults.loot.Strength;
                                }
                                else
                                {
                                    if (battleResults.loot.Strength > currChar.strItem.Strength)
                                    {
                                        battleResults.postGame.Add("The " + battleResults.loot.Name + " was an upgrade! " + currChar.Name +
                                            " takes it and discards their " + currChar.strItem.Name +".");
                                        currChar.Strength -= currChar.strItem.Strength;
                                        currChar.Strength += battleResults.loot.Strength;
                                        currChar.strItem = battleResults.loot;
                                        
                                    }
                                    else
                                    {
                                        battleResults.postGame.Add("The " + battleResults.loot.Name + " was too weak. " + currChar.Name + 
                                            " shakes their head in disgust and leaves it on the floor.");
                                    }
                                }
                            }
                            else if (battleResults.loot.Attribute == "Defense")
                            {
                                if (currChar.defItem == null)
                                {
                                    currChar.defItem = battleResults.loot;
                                    currChar.Defense += battleResults.loot.Strength;
                                }
                                else
                                {
                                    if (battleResults.loot.Strength > currChar.defItem.Strength)
                                    {
                                        battleResults.postGame.Add("The " + battleResults.loot.Name + " was an upgrade! " + currChar.Name +
                                            " takes it and discards their " + currChar.defItem.Name + ".");
                                        currChar.Defense -= currChar.defItem.Strength;
                                        currChar.Defense += battleResults.loot.Strength;
                                        currChar.defItem = battleResults.loot;

                                    }
                                    else
                                    {
                                        battleResults.postGame.Add("The " + battleResults.loot.Name + " was too weak. " + currChar.Name +
                                            " shakes their head in disgust and leaves it on the floor.");
                                    }
                                }
                            }
                            else if (battleResults.loot.Attribute == "Speed")
                            {
                                if (currChar.speedItem == null)
                                {
                                    currChar.speedItem = battleResults.loot;
                                    currChar.Speed += battleResults.loot.Strength;
                                }
                                else
                                {
                                    if (battleResults.loot.Strength > currChar.speedItem.Strength)
                                    {
                                        battleResults.postGame.Add("The " + battleResults.loot.Name + " was an upgrade! " + currChar.Name +
                                            " takes it and discards their " + currChar.speedItem.Name + ".");
                                        currChar.Speed -= currChar.speedItem.Strength;
                                        currChar.Speed += battleResults.loot.Strength;
                                        currChar.speedItem = battleResults.loot;

                                    }
                                    else
                                    {
                                        battleResults.postGame.Add("The " + battleResults.loot.Name + " was too weak. " + currChar.Name +
                                            " shakes their head in disgust and leaves it on the floor.");
                                    }
                                }
                            }
                            else
                            {
                                if (currChar.hpItem == null)
                                {
                                    currChar.hpItem = battleResults.loot;
                                    currChar.HitPoints += battleResults.loot.Strength;
                                }
                                else
                                {
                                    if (battleResults.loot.Strength > currChar.hpItem.Strength)
                                    {
                                        battleResults.postGame.Add("The " + battleResults.loot.Name + " was an upgrade! " + currChar.Name +
                                            " takes it and discards their " + currChar.hpItem.Name + ".");
                                        currChar.HitPoints += battleResults.loot.Strength;
                                        currChar.HitPoints -= currChar.hpItem.Strength;
                                        currChar.hpItem = battleResults.loot;

                                    }
                                    else
                                    {
                                        battleResults.postGame.Add("The " + battleResults.loot.Name + " was too weak. " + currChar.Name +
                                            " shakes their head in disgust and leaves it on the floor.");
                                    }
                                }
                            }
                        }
                    }
                }
                await Navigation.PushAsync(new BattleDetailPage(battleResults, charQueue, gameScore));
            }
            
            

        }
    }
}
