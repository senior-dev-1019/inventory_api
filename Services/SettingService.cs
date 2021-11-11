using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class SettingService{
        private readonly IMongoCollection<Settings> _collection;

        public SettingService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Settings>("ProjectCollection");
        }

        public List<Settings> GetSettings()=> _collection.Find(Settings=> true).ToList();

        public Settings GetSetting(string id )=> _collection.Find(Settings=> Settings.id== id).FirstOrDefault();

        public Settings PostSetting (Settings settings){
            _collection.InsertOne(settings);
            return settings;
        }

        public Settings PutSetting (string id, Settings settings){
            _collection.ReplaceOne(settings=> settings.id == id,settings);
            return settings;                
        }

        public Settings DeleteSetting(string id){
            var settings = _collection.Find(settings => settings.id == id).FirstOrDefault();
            _collection.DeleteOne(Settings=> Settings.id==id);
            return settings;
        }
    
    }
}