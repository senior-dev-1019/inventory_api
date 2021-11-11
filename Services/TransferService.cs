using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class TransferService{
        private readonly IMongoCollection<Transfers> _collection;

        public TransferService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Transfers>("ProjectCollection");
        }

        public List<Transfers> GetTransfers()=> _collection.Find(Transfers=> true).ToList();

        public Transfers GetTransfer(string id )=> _collection.Find(Transfers=> Transfers.id== id).FirstOrDefault();

        public Transfers PostTransfer (Transfers transfers){
            _collection.InsertOne(transfers);
            return transfers;
        }

        public Transfers PutTransfer (string id, Transfers transfers){
            _collection.ReplaceOne(transfers=> transfers.id == id,transfers);
            return transfers;                
        }

        public Transfers DeleteTransfer(string id){
            var transfers = _collection.Find(transfers => transfers.id == id).FirstOrDefault();
            _collection.DeleteOne(Transfers=> Transfers.id==id);
            return transfers;
        }
    
    }
}