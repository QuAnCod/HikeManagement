using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeManagement
{
    class MySQLiteDatabase
    {
        private SQLiteConnection dbConnection;
        public const string DB_FILENAME = "HikeDB.db";
        public const SQLiteOpenFlags FLAGS = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
        public string dbPath = "";
        // public string currentState;

        public const string TABLE_HIKE = "Hike";
        public const string COL_HIKE_ID = "HikeID";
        public const string COL_HIKE_NAME = "HikeName";
        public const string COL_HIKE_LOCATION = "HikeLocation";
        public const string COL_HIKE_DATE = "HikeDate";
        public const string COL_HIKE_PARKING = "HikeParking";
        public const string COL_HIKE_DISTANCE = "HikeDistance";
        public const string COL_HIKE_DIFFICULTY = "HikeDifficulty";
        public const string COL_HIKE_DESCRIPTION = "HikeDescription";
        public const string COL_HIKE_ACCOMODATION = "HikeAccomodation";

        public MySQLiteDatabase()
        {
            init();
        }

        public void init()
        {
            dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, DB_FILENAME);
            dbConnection = new SQLiteConnection(dbPath, FLAGS);
            dbConnection.CreateTable<Hike>();
        }

        public int AddHike(Hike hike)
        {
            return dbConnection.Insert(hike);
        }

        public ObservableCollection<Hike> GetAllHikes()
        {
            return (new ObservableCollection<Hike>(dbConnection.Table<Hike>().ToList()));
        }
    }
}
