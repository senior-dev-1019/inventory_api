using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class UnitService{
        private readonly IMongoCollection<Units> _collection;

        public UnitService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Units>("ProjectCollection");
        }

        public List<Units> GetUnits()=> _collection.Find(Units=> true).ToList();

        public Units GetUnit(string id )=> _collection.Find(Units=> Units.id== id).FirstOrDefault();

        public Units PostUnit (Units user){
            _collection.InsertOne(user);
            return user;
        }

        public Units PutUnit (string id, Units user){
            _collection.ReplaceOne(user=> user.id == id,user);
            return user;                
        }

        public Units DeleteUnit(string id){
            var user = _collection.Find(user => user.id == id).FirstOrDefault();
            _collection.DeleteOne(Units=> Units.id==id);
            return user;
        }
    
    }
}