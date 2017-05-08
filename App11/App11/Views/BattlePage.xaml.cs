using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App11.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using SQLite;

namespace App11.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BattlePage : ContentPage
	{
        public Results battleResults;
        Queue<Fighter> charQueue = new Queue<Fighter>();
        ScoreBoard gameScore = new ScoreBoard();

        public BattlePage()
		{
			InitializeComponent();

			initializeCharQ();

            //for(int i =0; i<4; i++)
            //{
            //    charQueue.Enqueue(new Character(2, 2, 2, i + 1, 10, 0, "Character " + (i+1)));
            //}
		}

		/*protected override async void OnAppearing()
        {
            base.OnAppearing();
            battleStart();
            
        }
        */

		private async Task initializeCharQ()
		{
			List<Character> charItems = await App.Database.GetCharactersAsync();

			foreach (Character charItem in charItems)
			{
				//public Character(int strength, int defense, int speed, int stackOrder, int hitPoints,int level)
				int str = charItem.Strength;
				int def = charItem.Defense;
				int spd = charItem.Speed;
				int stkod = charItem.StackOrder;
				int hp = charItem.HitPoints;
				int lv = charItem.Level;
				string name = charItem.Name;

				//charQueue.Enqueue(new Character(2, 2, 2, charItem.ID, 10, 0, "Character " + charItem.ID));
				charQueue.Enqueue(new Character(str, def, spd, stkod, hp, lv, name));
			}
		}

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
