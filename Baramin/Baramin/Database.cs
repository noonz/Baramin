using Baramin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace Baramin
{
    public class Database
    {
        SQLiteConnection database = null;

        public Database()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Baramin.db3");
            database = new SQLiteConnection(dbPath);
            database.CreateTable<Favourite>();
        }

        public void InsertFavourite(Favourite favourite)
        {
            database.InsertOrReplace(favourite);
        }

        public void DeleteFavourite(string favouriteId)
        {
            database.Delete<Favourite>(favouriteId);
        }

        public bool CheckIsFavourite(string favouriteId)
        {
            return database.Query<Favourite>("select * from Items where _id=?", favouriteId).Count > 0;
        }

        public List<Favourite> GetFavourite()
        {
            return database.Table<Favourite>().ToList();
        }
    }
}
