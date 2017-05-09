using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using SQLite;
namespace App11.Models
{
    public class ScoreBoard
    {
        // newly added for character DB ops
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int currScore { get; set; }
        public int round { get; set; }
        public ObservableCollection<Character> deadChars;
    }
}
