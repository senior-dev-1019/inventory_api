using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class oAuthClientService{
        private readonly IMongoCollection<oAuthClients> _collection;

        public oAuthClientService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<oAuthClients>("ProjectCollection");
        }

        public List<oAuthClients> GetoAuthClients()=> _collection.Find(oAuthClients=> true).ToList();

        public oAuthClients GetoAuthClient(string id )=> _collection.Find(oAuthClients=> oAuthClients.id== id).FirstOrDefault();

        public oAuthClients PostoAuthClient (oAuthClients oAuthClient){
            _collection.InsertOne(oAuthClient);
            return oAuthClient;
        }

        public oAuthClients PutoAuthClient (string id, oAuthClients oAuthClient){
            _collection.ReplaceOne(oAuthClient=> oAuthClient.id == id,oAuthClient);
            return oAuthClient;                
        }

        public oAuthClients DeleteoAuthClient(string id){
            var oAuthClient = _collection.Find(oAuthClient => oAuthClient.id == id).FirstOrDefault();
            _collection.DeleteOne(oAuthClients=> oAuthClients.id==id);
            return oAuthClient;
        }
    
    }
}