using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class PasswordResetService{
        private readonly IMongoCollection<PasswordResets> _collection;
        public PasswordResetService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<PasswordResets>("ProjectCollection");
        }

        public List<PasswordResets> GetPasswordResets()=> _collection.Find(PasswordResets=> true).ToList();

        public PasswordResets GetPasswordReset(string id )=> _collection.Find(PasswordResets=> PasswordResets.id== id).FirstOrDefault();

        public PasswordResets PostPasswordReset (PasswordResets passwordResets){
            _collection.InsertOne(passwordResets);
            return passwordResets;
        }

        public PasswordResets PutPasswordReset (string id, PasswordResets passwordResets){
            _collection.ReplaceOne(passwordResets=> passwordResets.id == id,passwordResets);
            return passwordResets;                
        }

        public PasswordResets DeletePasswordReset(string id){
            var passwordResets = _collection.Find(passwordResets => passwordResets.id == id).FirstOrDefault();
            _collection.DeleteOne(PasswordResets=> PasswordResets.id==id);
            return passwordResets;
        }
    
    }
}