using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class PosSettingService{
        private readonly IMongoCollection<PosSettings> _collection;

        public PosSettingService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<PosSettings>("ProjectCollection");
        }

        public List<PosSettings> GetPosSettings()=> _collection.Find(PosSettings=> true).ToList();

        public PosSettings GetPosSetting(string id )=> _collection.Find(PosSettings=> PosSettings.id== id).FirstOrDefault();

        public PosSettings PostPosSetting (PosSettings PosSettings){
            _collection.InsertOne(PosSettings);
            return PosSettings;
        }

        public PosSettings PutPosSetting (string id, PosSettings PosSettings){
            _collection.ReplaceOne(PosSettings=> PosSettings.id == id,PosSettings);
            return PosSettings;                
        }

        public PosSettings DeletePosSetting(string id){
            var PosSettings = _collection.Find(PosSettings => PosSettings.id == id).FirstOrDefault();
            _collection.DeleteOne(PosSettings=> PosSettings.id==id);
            return PosSettings;
        }
    
    }
}