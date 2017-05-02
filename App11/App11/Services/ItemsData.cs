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
                new Item { itemId = Guid.NewGuid().ToString(), Name = "Small Sword", Description= "A really cool sword. ", Strength = 1, Attribute = "Strength" },
                new Item { itemId = Guid.NewGuid().ToString(), Name = "Cool Shield", Description="A really cool shield. ", Strength = 1, Attribute = "Defense" },
                new Item { itemId = Guid.NewGuid().ToString(), Name = "Used Basketball Shoes", Description="Some used basketball shoes. Run fast!", Strength = 1, Attribute = "Speed" },
                new Item { itemId = Guid.NewGuid().ToString(), Name = "Bow", Description="A realy cool bow.", Strength = 1, Attribute = "Strength" },
                new Item { itemId = Guid.NewGuid().ToString(), Name = "Ring of Life", Description = "A really cool ring that increases HP. ", Strength = 1, Attribute = "HP"},
                new Item { itemId = Guid.NewGuid().ToString(), Name = "Baby Oil", Description="Slicken up for top speed! " , Strength = 1, Attribute = "Speed"},
            };

            foreach (Item item in _items)
            {
                items.Add(item);
            }
        }


    }

}
