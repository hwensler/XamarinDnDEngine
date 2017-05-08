using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace App11.Models
{
    public class ScoreBoard
    {
        public int currScore { get; set; }
        public int round { get; set; }
        public ObservableCollection<Character> deadChars;
    }
}
