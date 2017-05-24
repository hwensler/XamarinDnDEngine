using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using SQLite;


namespace App11.Models
{
    public class Fighter    :   INotifyPropertyChanged
    {
		// newly added for character DB ops
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

        protected int strength;
        public int Strength { get { return strength; } set { this.strength = value; } }
        protected int defense;
        public int Defense { get { return defense; } set { this.defense = value; } }
        protected int speed;
        public int Speed { get { return speed; } set { this.speed = value; } }
        protected int stackOrder;
        public int StackOrder { get { return stackOrder; } set { this.stackOrder = value; } }
        protected int hitPoints;
        public int HitPoints { get { return hitPoints; } set { this.hitPoints = value; } }
        protected int level;
        public int Level { get { return level; } set { this.level = value; } }
        public bool isHuman;
        public string Image { get; set; }

        //Should we revisit and limit the number of chars in a name?
        protected string name;
        public string Name { get { return name; }
            set {
                this.name = value;
                OnPropertyChanged(nameof(Name)); }
        }

        public bool isAlive()
        {
            if (hitPoints <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int DoDamage(Fighter defender, int damage)
        {
            //do the damage to the defender
            defender.ChangeHP(-damage);
            return defender.hitPoints;
        }
        public void ChangeHP(int hpChange)
        {
            this.hitPoints += hpChange;
        }
        public void AdjustStats(int strength, int defense, int speed)
        {
            this.strength += strength;
            this.defense += defense;
            this.speed += speed;
        }
        //added this method for crud operations
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
