using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class TransferDetailService{
        private readonly IMongoCollection<TransferDetails> _collection;

        public TransferDetailService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<TransferDetails>("ProjectCollection");
        }

        public List<TransferDetails> GetTransferDetails()=> _collection.Find(TransferDetails=> true).ToList();

        public TransferDetails GetTransferDetail(string id )=> _collection.Find(TransferDetails=> TransferDetails.id== id).FirstOrDefault();

        public TransferDetails PostTransferDetail (TransferDetails transferDetails){
            _collection.InsertOne(transferDetails);
            return transferDetails;
        }

        public TransferDetails PutTransferDetail (string id, TransferDetails transferDetails){
            _collection.ReplaceOne(transferDetails=> transferDetails.id == id,transferDetails);
            return transferDetails;                
        }

        public TransferDetails DeleteTransferDetail(string id){
            var transferDetails = _collection.Find(transferDetails => transferDetails.id == id).FirstOrDefault();
            _collection.DeleteOne(TransferDetails=> TransferDetails.id==id);
            return transferDetails;
        }
    
    }
}