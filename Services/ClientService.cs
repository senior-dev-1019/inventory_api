using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class ClientService{
        private readonly IMongoCollection<Clients> _collection;

        public ClientService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Clients>("ProjectCollection");
        }

        public List<Clients> GetClients()=> _collection.Find(Clients=> true).ToList();

        public Clients GetClient(string id )=> _collection.Find(Clients=> Clients.id== id).FirstOrDefault();

        public Clients PostClient (Clients Client){
            _collection.InsertOne(Client);
            return Client;
        }

        public Clients PutClient (string id, Clients Client){
            _collection.ReplaceOne(Client=> Client.id == id,Client);
            return Client;                
        }

        public Clients DeleteClient(string id){
            var Client = _collection.Find(Client => Client.id == id).FirstOrDefault();
            _collection.DeleteOne(Clients=> Clients.id==id);
            return Client;
        }
    
    }
}