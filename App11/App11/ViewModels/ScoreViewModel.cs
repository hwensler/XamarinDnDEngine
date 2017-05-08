using System;
using System.Collections.Generic;
using System.Text;
using App11.Models;

namespace App11.ViewModels
{
    public class ScoreViewModel : BaseViewModel
    {
        public ScoreBoard Score { get; set; }

        public ScoreViewModel(ScoreBoard score)
        {
            Title = "ScoreBoard";
            Score =score;
        }
        public int scoreVal
        {
            get { return Score.currScore; }
        }
    }
}
