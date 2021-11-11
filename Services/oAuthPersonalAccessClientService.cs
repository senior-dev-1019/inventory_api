using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class oAuthPersonalAccessClientService{
        private readonly IMongoCollection<oAuthPersonalAccessClients> _collection;

        public oAuthPersonalAccessClientService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<oAuthPersonalAccessClients>("ProjectCollection");
        }

        public List<oAuthPersonalAccessClients> GetoAuthPersonalAccessClients()=> _collection.Find(oAuthPersonalAccessClients=> true).ToList();

        public oAuthPersonalAccessClients GetoAuthPersonalAccessClient(string id )=> _collection.Find(oAuthPersonalAccessClients=> oAuthPersonalAccessClients.id== id).FirstOrDefault();

        public oAuthPersonalAccessClients PostoAuthPersonalAccessClient (oAuthPersonalAccessClients oAuthPersonalAccessClient){
            _collection.InsertOne(oAuthPersonalAccessClient);
            return oAuthPersonalAccessClient;
        }

        public oAuthPersonalAccessClients PutoAuthPersonalAccessClient (string id, oAuthPersonalAccessClients oAuthPersonalAccessClient){
            _collection.ReplaceOne(oAuthPersonalAccessClient=> oAuthPersonalAccessClient.id == id,oAuthPersonalAccessClient);
            return oAuthPersonalAccessClient;                
        }

        public oAuthPersonalAccessClients DeleteoAuthPersonalAccessClient(string id){
            var oAuthPersonalAccessClient = _collection.Find(oAuthPersonalAccessClient => oAuthPersonalAccessClient.id == id).FirstOrDefault();
            _collection.DeleteOne(oAuthPersonalAccessClients=> oAuthPersonalAccessClients.id==id);
            return oAuthPersonalAccessClient;
        }
    
    }
}