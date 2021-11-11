using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class oAuthAccessCodeService{
        private readonly IMongoCollection<oAuthAccessTokens> _collection;

        public oAuthAccessCodeService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<oAuthAccessTokens>("ProjectCollection");
        }

        public List<oAuthAccessTokens> GetoAuthAccessTokens()=> _collection.Find(oAuthAccessTokens=> true).ToList();

        public oAuthAccessTokens GetoAuthAccessToken(string id )=> _collection.Find(oAuthAccessTokens=> oAuthAccessTokens.id== id).FirstOrDefault();

        public oAuthAccessTokens PostoAuthAccessToken (oAuthAccessTokens oauthAccessTokens){
            _collection.InsertOne(oauthAccessTokens);
            return oauthAccessTokens;
        }

        public oAuthAccessTokens PutoAuthAccessToken (string id, oAuthAccessTokens oauthAccessTokens){
            _collection.ReplaceOne(oauthAccessTokens=> oauthAccessTokens.id == id,oauthAccessTokens);
            return oauthAccessTokens;                
        }

        public oAuthAccessTokens DeleteoAuthAccessToken(string id){
            var oauthAccessTokens = _collection.Find(oauthAccessTokens => oauthAccessTokens.id == id).FirstOrDefault();
            _collection.DeleteOne(oAuthAccessTokens=> oAuthAccessTokens.id==id);
            return oauthAccessTokens;
        }
    
    }
}