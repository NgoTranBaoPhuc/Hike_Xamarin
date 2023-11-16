using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Hike.Model;

namespace Hike.Database
{
    public class SQLiteHelper

    {
        private readonly SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<HikeModel>();
           // db.CreateTableAsync<ObservationModel>();

        }

        public Task<int> CreateHike(HikeModel hike)
        {
            return db.InsertAsync(hike);
        }



        public Task<List<HikeModel>> ReadHike()
        {
            return db.Table<HikeModel>().ToListAsync();
        }


        //---------------Edit
        public Task<int> UpdateHike(HikeModel hike)
        {
            return db.UpdateAsync(hike);
        }
        //-------------Delete
        public Task<int> DeleteHike(HikeModel hike)
        {
            return db.DeleteAsync(hike);
        }

        //--------------Search
        public Task<List<HikeModel>> Search(string search)
        {
            return db.Table<HikeModel>().Where(p => p.name.StartsWith(search)).ToListAsync();
        }


        public Task<int> CreateObservation(ObservationModel observation)
        {
            return db.InsertAsync(observation);
        }
        public Task<List<ObservationModel>> ReadObservation(int HikeId)
        {
            return db.Table<ObservationModel>().Where(p => p.HikeFk.Equals(HikeId)).ToListAsync();
        }
    }
}
