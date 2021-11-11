using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class RoleService{
        private readonly IMongoCollection<Roles> _collection;

        public RoleService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Roles>("ProjectCollection");
        }

        public List<Roles> GetRoles()=> _collection.Find(Roles=> true).ToList();

        public Roles GetRole(string id )=> _collection.Find(Roles=> Roles.id== id).FirstOrDefault();

        public Roles PostRole (Roles roles){
            _collection.InsertOne(roles);
            return roles;
        }

        public Roles PutRole (string id, Roles roles){
            _collection.ReplaceOne(roles=> roles.id == id,roles);
            return roles;                
        }

        public Roles DeleteRole(string id){
            var roles = _collection.Find(roles => roles.id == id).FirstOrDefault();
            _collection.DeleteOne(Roles=> Roles.id==id);
            return roles;
        }
    
    }
}