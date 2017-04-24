using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using SQLite;
using App11.Models;
using App11.Services;

namespace App11
{
    class DBDataAccess
    {
        private SQLiteConnection database;
        //don't really have an implmentation of a lock yet
        private static object collisionLock = new object();

        public ObservableCollection<Monster> Monsters { get; set; }

        public DBDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().
                DbConnection();
            database.CreateTable<Monster>();
            this.Monsters = new ObservableCollection<Monster>();
            if (!database.Table<Monster>().Any())
            {
                AddNewMonster(new Monster());
            }
        }
        //for adding monsters
        public void AddNewMonster(Monster mon)
        {
            this.Monsters.Add(new Monster
            {
                Name="Name of monster",
                Description="Description of monster"
            });
        }
        //querying monsters
        public IEnumerable<Monster> GetAllMonster()
        {
            //remember this doesn't work yet
            lock (collisionLock)
            {
                //return them all since that is what we want
                //remember to change in group project
                return database.Query<Monster>("SELECT * FROM Item ").
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
                  => Monster.Id == id);
            }
        }
        public int SaveOrUpdateMonster(Monster mon)
        {
            //again this does nothing right now
            lock (collisionLock)
            {
                //if item exists
                if(mon.Id != 0)
                {
                    database.Update(mon);
                    return mon.Id;
                }
                //if it does not exist in database yet
                else
                {
                    database.Insert(mon);
                    return mon.Id;
                }
            }
        }

        public int DeleteMonster(Monster mon)
        {
            var id = mon.Id;
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
