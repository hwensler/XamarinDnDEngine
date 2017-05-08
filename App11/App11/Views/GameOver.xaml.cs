﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App11.Models;
using App11.ViewModels;
namespace App11.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GameOver : ContentPage
	{
        //ScoreViewModel ViewScore;
        public ScoreBoard gameScore { get; set; }

		public GameOver (ScoreBoard finalScore)
		{
			InitializeComponent ();
            gameScore = finalScore;
            //display the score
            BindingContext = this.gameScore;
        }
        public async void goHome(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
        public async void goScore(object sender, EventArgs e)
        {

            //work in progress
            //await Navigation.PopToRootAsync(new ScorePage(ViewScore));
            await Navigation.PopToRootAsync();
        }
    }
}
