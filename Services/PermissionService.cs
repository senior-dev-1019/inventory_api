using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class PermissionService{
        private readonly IMongoCollection<Permissions> _collection;

        public PermissionService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Permissions>("ProjectCollection");
        }

        public List<Permissions> GetPermissions()=> _collection.Find(Permissions=> true).ToList();

        public Permissions GetPermission(string id )=> _collection.Find(Permissions=> Permissions.id== id).FirstOrDefault();

        public Permissions PostPermission (Permissions Permissions){
            _collection.InsertOne(Permissions);
            return Permissions;
        }

        public Permissions PutPermission (string id, Permissions Permissions){
            _collection.ReplaceOne(Permissions=> Permissions.id == id,Permissions);
            return Permissions;                
        }

        public Permissions DeletePermission(string id){
            var Permissions = _collection.Find(Permissions => Permissions.id == id).FirstOrDefault();
            _collection.DeleteOne(Permissions=> Permissions.id==id);
            return Permissions;
        }
    
    }
}