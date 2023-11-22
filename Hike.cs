using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableAttribute = SQLite.TableAttribute;

namespace HikeManagement
{
    [Table("Hike")]
    public class Hike
    {
        [PrimaryKey, AutoIncrement]
        public int HikeID { get; set; }
        public string HikeName { get; set; }
        public string HikeLocation { get; set; }
        public DateTime HikeDate { get; set; }
        public bool HikeParking { get; set; }
        public string HikeDistance { get; set; }
        public string HikeDifficulty { get; set; }
        public string HikeDescription { get; set; }
        public string HikeAccomodation { get; set; }
        public Hike() { }

        public Hike(int hikeID, string hikeName, string hikeLocation, DateTime hikeDate, bool hikeParking, string hikeDistance, string hikeDifficulty, string hikeDescription, string hikeAccomodation)
        {
            HikeID = hikeID;
            HikeName = hikeName;
            HikeLocation = hikeLocation;
            HikeDate = hikeDate;
            HikeParking = hikeParking;
            HikeDistance = hikeDistance;
            HikeDifficulty = hikeDifficulty;
            HikeDescription = hikeDescription;
            HikeAccomodation = hikeAccomodation;
        }
    }
}
