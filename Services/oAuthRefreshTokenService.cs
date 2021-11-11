using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class oAuthRefreshTokenService{
        private readonly IMongoCollection<oAuthRefreshTokens> _collection;

        public oAuthRefreshTokenService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<oAuthRefreshTokens>("ProjectCollection");
        }

        public List<oAuthRefreshTokens> GetoAuthRefreshTokens()=> _collection.Find(oAuthRefreshTokens=> true).ToList();

        public oAuthRefreshTokens GetoAuthRefreshToken(string id )=> _collection.Find(oAuthRefreshTokens=> oAuthRefreshTokens.id== id).FirstOrDefault();

        public oAuthRefreshTokens PostoAuthRefreshToken (oAuthRefreshTokens oAuthRefreshToken){
            _collection.InsertOne(oAuthRefreshToken);
            return oAuthRefreshToken;
        }

        public oAuthRefreshTokens PutoAuthRefreshToken (string id, oAuthRefreshTokens oAuthRefreshToken){
            _collection.ReplaceOne(oAuthRefreshToken=> oAuthRefreshToken.id == id,oAuthRefreshToken);
            return oAuthRefreshToken;                
        }

        public oAuthRefreshTokens DeleteoAuthRefreshToken(string id){
            var oAuthRefreshToken = _collection.Find(oAuthRefreshToken => oAuthRefreshToken.id == id).FirstOrDefault();
            _collection.DeleteOne(oAuthRefreshTokens=> oAuthRefreshTokens.id==id);
            return oAuthRefreshToken;
        }
    
    }
}