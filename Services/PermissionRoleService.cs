using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class PermissionRoleService{
        private readonly IMongoCollection<PermissionRole> _collection;

        public PermissionRoleService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<PermissionRole>("ProjectCollection");
        }

        public List<PermissionRole> GetPermissionRoles()=> _collection.Find(PermissionRole=> true).ToList();

        public PermissionRole GetPermissionRole(string id )=> _collection.Find(PermissionRole=> PermissionRole.id== id).FirstOrDefault();

        public PermissionRole PostPermissionRole (PermissionRole PermissionRole){
            _collection.InsertOne(PermissionRole);
            return PermissionRole;
        }

        public PermissionRole PutPermissionRole (string id, PermissionRole PermissionRole){
            _collection.ReplaceOne(PermissionRole=> PermissionRole.id == id,PermissionRole);
            return PermissionRole;                
        }

        public PermissionRole DeletePermissionRole(string id){
            var PermissionRole = _collection.Find(PermissionRole => PermissionRole.id == id).FirstOrDefault();
            _collection.DeleteOne(PermissionRole=> PermissionRole.id==id);
            return PermissionRole;
        }
    
    }
}