using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Hike.Model
{
    public class ObservationModel
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String name { get; set; }
        public DateTime time { get; set; }
        public String comment { get; set; }
        public int HikeFk { get; set; }
    }
}
