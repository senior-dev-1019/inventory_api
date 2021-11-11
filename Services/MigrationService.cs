using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class MigrationService{
        private readonly IMongoCollection<Migrations> _collection;

        public MigrationService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Migrations>("ProjectCollection");
        }

        public List<Migrations> GetMigrations()=> _collection.Find(Migrations=> true).ToList();

        public Migrations GetMigration(string id )=> _collection.Find(Migrations=> Migrations.id== id).FirstOrDefault();

        public Migrations PostMigration (Migrations migrations){
            _collection.InsertOne(migrations);
            return migrations;
        }

        public Migrations PutMigration (string id, Migrations migrations){
            _collection.ReplaceOne(migrations=> migrations.id == id,migrations);
            return migrations;                
        }

        public Migrations DeleteMigration(string id){
            var migrations = _collection.Find(migrations => migrations.id == id).FirstOrDefault();
            _collection.DeleteOne(Migrations=> Migrations.id==id);
            return migrations;
        }
    
    }
}