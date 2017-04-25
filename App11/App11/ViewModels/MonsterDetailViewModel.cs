using System;
using System.Collections.Generic;
using System.Text;
using App11.Models;


namespace App11.ViewModels
{
    public class MonsterDetailViewModel : BaseViewModel
    {
        public Monster Mon { get; set; }
       
        public MonsterDetailViewModel (Monster mon = null)
        {
            Title = mon.Name;
            Mon = mon;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    
        public Monster GetMonsterModel()
        {
            return this.Mon;
        }

    }
}
