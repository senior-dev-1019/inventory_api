using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class oAuthAccessTokenService{
        private readonly IMongoCollection<oAuthAccessTokens> _collection;

        public oAuthAccessTokenService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<oAuthAccessTokens>("ProjectCollection");
        }

        public List<oAuthAccessTokens> GetoAuthAccessTokens()=> _collection.Find(oAuthAccessTokens=> true).ToList();

        public oAuthAccessTokens GetoAuthAccessToken(string id )=> _collection.Find(oAuthAccessTokens=> oAuthAccessTokens.id== id).FirstOrDefault();

        public oAuthAccessTokens PostoAuthAccessToken (oAuthAccessTokens oAuthAccessToken){
            _collection.InsertOne(oAuthAccessToken);
            return oAuthAccessToken;
        }

        public oAuthAccessTokens PutoAuthAccessToken (string id, oAuthAccessTokens oAuthAccessToken){
            _collection.ReplaceOne(oAuthAccessToken=> oAuthAccessToken.id == id,oAuthAccessToken);
            return oAuthAccessToken;                
        }

        public oAuthAccessTokens DeleteoAuthAccessToken(string id){
            var oAuthAccessToken = _collection.Find(oAuthAccessToken => oAuthAccessToken.id == id).FirstOrDefault();
            _collection.DeleteOne(oAuthAccessTokens=> oAuthAccessTokens.id==id);
            return oAuthAccessToken;
        }
    
    }
}