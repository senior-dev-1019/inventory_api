using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class UserService{
        private readonly IMongoCollection<User> _user;

        public UserService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _user = database.GetCollection<User>("ProjectCollection");
        }

        public List<User> GetUsers()=> _user.Find(User=> true).ToList();

        public User GetUser(string id )=> _user.Find(User=> User.id== id).FirstOrDefault();

        public User PostUser (User user){
            _user.InsertOne(user);
            return user;
        }

        public User PutUser (string id, User user){
            _user.ReplaceOne(user=> user.id == id,user);
            return user;                
        }

        public User DeleteUser(string id){
            var user = _user.Find(user => user.id == id).FirstOrDefault();
            _user.DeleteOne(User=> User.id==id);
            return user;
        }
    
    }
}