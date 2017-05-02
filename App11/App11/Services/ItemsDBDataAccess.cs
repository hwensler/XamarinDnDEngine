using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using SQLite;
using App11.Models;
using App11.Services;
using App11.ViewModels;

namespace App11
{

    public class ItemsDBDataAccess
    {
        //a list for all the initial items (use for now
        public List<Item> initialItems { get; set; }

        private SQLiteConnection database;

        //don't have an implmentation of a lock yet
        private static object collisionLock = new object();

        public ObservableCollection<Item> Items { get; set; }

        public ItemsDBDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().
                DbConnection();
            database.CreateTable<Item>();
            this.Items = new ObservableCollection<Item>(database.Table<Item>());

            //if the database is empty
            if (!database.Table<Item>().Any())
            {
                //populate with these default items
                PopulateItems();
            }
        }

        //to populate the DB with base items for now
        public void PopulateItems()
        {
            initialItems = new List<Item>();

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
                this.Items.Add(item);
            }
   
        }

        //querying items
        public IEnumerable<Item> GetAllItems()
        {
            //remember this doesn't work yet
            lock (collisionLock)
            {
                //return them all since that is what we want
                return database.Query<Item>("SELECT * FROM Items ").
                    AsEnumerable();
            }
        }
        //retrieve an item by its id
        public Item GetItem(String id)
        {
            lock (collisionLock)
            {
                return database.Table<Item>().
                  FirstOrDefault(Item
                  => Item.itemId == id);
            }
        }
    }
}
