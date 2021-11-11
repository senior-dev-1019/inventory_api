using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class ServerService{
        private readonly IMongoCollection<Servers> _collection;

        public ServerService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Servers>("ProjectCollection");
        }

        public List<Servers> GetServers()=> _collection.Find(Servers=> true).ToList();

        public Servers GetServer(string id )=> _collection.Find(Servers=> Servers.id== id).FirstOrDefault();

        public Servers PostServer (Servers servers){
            _collection.InsertOne(servers);
            return servers;
        }

        public Servers PutServer (string id, Servers servers){
            _collection.ReplaceOne(servers=> servers.id == id,servers);
            return servers;                
        }

        public Servers DeleteServer(string id){
            var servers = _collection.Find(servers => servers.id == id).FirstOrDefault();
            _collection.DeleteOne(Servers=> Servers.id==id);
            return servers;
        }
    
    }
}