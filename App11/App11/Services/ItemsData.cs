/**
 * This is where the items list is populated from... for now.
 * **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App11.Models;

using Xamarin.Forms;

namespace App11.Services
{
    public class ItemsData
    {
        public List<Item> items { get; set; }

        public ItemsData()
        {
            items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Name = "Sword", Description= "A really cool sword. ", Strength = 1},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Shield", Description="A really cool shield. ", Strength = 1},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Shoes", Description="A really cool pair of shoes. ", Strength = 1},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Bow", Description="A realy cool bow.", Strength = 1},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Lance", Description="A really cool lance. ", Strength = 1},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Axe", Description="A really cool axe. " , Strength = 1},
            };

            foreach (Item item in _items)
            {
                items.Add(item);
            }
        }


    }

}
