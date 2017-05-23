using System;
using System.Collections.Generic;
using System.Text;

namespace App11.Models
{
    public class BattleEffects
    {
        //Name to show in output
        public string Name { get; set; }

        //More information about the effect
        public string Description { get; set; }

        //Amount of Impact Positive or Negative
        public int Tier { get; set; }

        //Who gets impacted HARACTERSINGLE, CHARACTERALL, MONSTERAALL, MONSTERSINGLE, ALL
        public string Target { get; set; }

        //The Attribute Modified {STRENGTH, SPEED, DEFENSE, HP }
        public string AttribMod { get; set; }
    }
}
