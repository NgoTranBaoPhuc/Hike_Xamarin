using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Hike.Model
{
    public class HikeModel
    {
        [PrimaryKey, AutoIncrement]
        public String id { get; set; }
        public String name { get; set; }
        public String location { get; set; }
        public DateTime date { get; set; }
        public int isParking { get; set; }
        public float length { get; set; }
        public String level { get; set; }
        public String vehicle { get; set; }
        public int member { get; set; }
        public String description { get; set; }
    }
}
