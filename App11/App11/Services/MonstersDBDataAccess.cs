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
    public class MonstersDBDataAccess
    {
        private SQLiteConnection database;
        //don't really have an implmentation of a lock yet
        private static object collisionLock = new object();

        public ObservableCollection<Monster> Monsters { get; set; }

        public MonstersDBDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().
                DbConnection();
            database.CreateTable<Monster>();
            this.Monsters = new ObservableCollection<Monster>(database.Table<Monster>());

            if (!database.Table<Monster>().Any())
            {
               
                AddNewMonster();
            }
        }
        //for adding monsters
        public void AddNewMonster(Monster mon)
        {
            this.Monsters.Add(new Monster
            {
                Name="Name of monster",
                Description="Description of monster",
            });
        }
        //for adding monsters
        public void AddNewMonster()
        {
            this.Monsters.Add(new Monster
            {
                Name = "Skeleton",
                Description = "A reanimated calcified being derived from past fallen adventurers.",
            });
            this.Monsters.Add(new Monster
            {
                Name = "Goblin",
                Description = "A small impish beast that relies on numbers rather than strength.",
            });
            this.Monsters.Add(new Monster
            {
                Name = "Orc",
                Description = "A fell beast that relishes in butchering of its foes and allies alike.",
            });
            this.Monsters.Add(new Monster
            {
                Name = "Dragon",
                Description = "A species that contains lizards to the mythical hellfire breather.",
            });
            this.Monsters.Add(new Monster
            {
                Name = "Demon",
                Description = "A hellspawn that attempts to lure adventurers into madness.",
            });
            this.Monsters.Add(new Monster
            {
                Name = "Slime",
                Description = "An amorphous creature that is forever hungry and digests all.",
            });
        }
        //querying monsters
        public IEnumerable<Monster> GetAllMonster()
        {
            //remember this doesn't work yet
            lock (collisionLock)
            {
                //return them all since that is what we want
                return database.Query<Monster>("SELECT * FROM Monsters ").
                    AsEnumerable();
            }
        }
        //retrieve an monster by its id
        public Monster GetMonster(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Monster>().
                  FirstOrDefault(Monster
                  => Monster.ID == id);
            }
        }
        public int SaveOrUpdateMonster(Monster mon)
        {
            //again this does nothing right now
            lock (collisionLock)
            {
                //if item exists
                if(mon.ID != 0)
                {
                    database.Update(mon);
                    return mon.ID;
                }
                //if it does not exist in database yet
                else
                {
                    database.Insert(mon);
                    return mon.ID;
                }
            }
        }

        public int DeleteMonster(Monster mon)
        {
            var id = mon.ID;
            if (id != 0)
            {
                lock(collisionLock)
                {
                    database.Delete<Monster>(id);
                }
            }
            //remove the item and return the id
            this.Monsters.Remove(mon);
            return id;
        }
    }
}
