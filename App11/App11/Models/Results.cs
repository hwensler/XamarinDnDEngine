using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace App11.Models
{
    public struct Results
    {
        public bool charsWon;
        public int points;
        public Item loot;
        public ObservableCollection<String> battleOutput;
        public ObservableCollection<String> postGame;
        public ObservableCollection<Character> deadChars;
    }
}
