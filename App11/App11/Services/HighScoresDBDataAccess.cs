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
    public class HighScoresDBDataAccess
    {
        private SQLiteConnection database;
        //don't really have an implmentation of a lock yet
        private static object collisionLock = new object();

        public ObservableCollection<ScoreBoard> HighScores { get; set; }

        public HighScoresDBDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().
                DbConnection();
            database.CreateTable<ScoreBoard>();
            this.HighScores = new ObservableCollection<ScoreBoard>(database.Table<ScoreBoard>());
        }
        //for adding scores
        public void AddNewScore(ScoreBoard newScore)
        {
            database.Insert(newScore);
            this.HighScores.Add(newScore);
        }
       
        //querying scores
        public IEnumerable<ScoreBoard> GetAllScores()
        {
            //remember this doesn't work yet
            lock (collisionLock)
            {
                //return them all since that is what we want
                return database.Query<ScoreBoard>("SELECT * FROM HighScores ").
                    AsEnumerable();
            }
        }
        //retrieve anscore by its id
        public ScoreBoard GetScore(int id)
        {
            lock (collisionLock)
            {
                return database.Table<ScoreBoard>().
                  FirstOrDefault(ScoreBoard
                  => ScoreBoard.ID == id);
            }
        }
        public int SaveOrUpdateScore(ScoreBoard newScore)
        {
            //again this does nothing right now
            lock (collisionLock)
            {
                //if item exists
                if(newScore.ID != 0)
                {
                    database.Update(newScore);
                    return newScore.ID;
                }
                //if it does not exist in database yet
                else
                {
                    database.Insert(newScore);
                    return newScore.ID;
                }
            }
        }

        public void clearHS()
        {
			this.HighScores = new ObservableCollection<ScoreBoard>(database.Table<ScoreBoard>());
			for (int i =0; i < this.HighScores.Count; i++)
			{
			    this.DeleteScore(HighScores[i]);
			}
		}

        public int DeleteScore(ScoreBoard delScore)
        {
            var id = delScore.ID;
            if (id != 0)
            {
                lock(collisionLock)
                {
                    database.Delete<ScoreBoard>(id);
                }
            }
            //remove the item and return the id
            this.HighScores.Remove(delScore);
            return id;
        }
    }
}
