using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class RoleUserService{
        private readonly IMongoCollection<RoleUser> _collection;

        public RoleUserService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<RoleUser>("ProjectCollection");
        }

        public List<RoleUser> GetRoleUsers()=> _collection.Find(RoleUser=> true).ToList();

        public RoleUser GetRoleUser(string id )=> _collection.Find(RoleUser=> RoleUser.id== id).FirstOrDefault();

        public RoleUser PostRoleUser (RoleUser user){
            _collection.InsertOne(user);
            return user;
        }

        public RoleUser PutRoleUser (string id, RoleUser user){
            _collection.ReplaceOne(user=> user.id == id,user);
            return user;                
        }

        public RoleUser DeleteRoleUser(string id){
            var user = _collection.Find(user => user.id == id).FirstOrDefault();
            _collection.DeleteOne(RoleUser=> RoleUser.id==id);
            return user;
        }
    
    }
}