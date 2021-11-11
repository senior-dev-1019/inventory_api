using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class PurchaseReturnDetailService{
        private readonly IMongoCollection<PurchaseReturnDetails> _collection;

        public PurchaseReturnDetailService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<PurchaseReturnDetails>("ProjectCollection");
        }

        public List<PurchaseReturnDetails> GetPurchaseReturnDetails()=> _collection.Find(PurchaseReturnDetails=> true).ToList();

        public PurchaseReturnDetails GetPurchaseReturnDetail(string id )=> _collection.Find(PurchaseReturnDetails=> PurchaseReturnDetails.id== id).FirstOrDefault();

        public PurchaseReturnDetails PostPurchaseReturnDetail (PurchaseReturnDetails PurchaseReturnDetails){
            _collection.InsertOne(PurchaseReturnDetails);
            return PurchaseReturnDetails;
        }

        public PurchaseReturnDetails PutPurchaseReturnDetail (string id, PurchaseReturnDetails PurchaseReturnDetails){
            _collection.ReplaceOne(PurchaseReturnDetails=> PurchaseReturnDetails.id == id,PurchaseReturnDetails);
            return PurchaseReturnDetails;                
        }

        public PurchaseReturnDetails DeletePurchaseReturnDetail(string id){
            var PurchaseReturnDetails = _collection.Find(PurchaseReturnDetails => PurchaseReturnDetails.id == id).FirstOrDefault();
            _collection.DeleteOne(PurchaseReturnDetails=> PurchaseReturnDetails.id==id);
            return PurchaseReturnDetails;
        }
    
    }
}