﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App11.Models;
using App11.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App11.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScorePage : ContentPage
	{
        ScoreViewModel ScoreModel;
		public ScorePage (ScoreViewModel Score)
		{

			InitializeComponent ();
            BindingContext = this.ScoreModel = Score;
		}
        public ScorePage()
        {
            InitializeComponent();
        }
	}
}
