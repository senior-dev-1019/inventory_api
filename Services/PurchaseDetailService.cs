using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class PurchaseDetailService{
        private readonly IMongoCollection<PurchaseDetails> _collection;

        public PurchaseDetailService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<PurchaseDetails>("ProjectCollection");
        }

        public List<PurchaseDetails> GetPurchaseDetails()=> _collection.Find(PurchaseDetails=> true).ToList();

        public PurchaseDetails GetPurchaseDetail(string id )=> _collection.Find(PurchaseDetails=> PurchaseDetails.id== id).FirstOrDefault();

        public PurchaseDetails PostPurchaseDetail (PurchaseDetails PurchaseDetails){
            _collection.InsertOne(PurchaseDetails);
            return PurchaseDetails;
        }

        public PurchaseDetails PutPurchaseDetail (string id, PurchaseDetails PurchaseDetails){
            _collection.ReplaceOne(PurchaseDetails=> PurchaseDetails.id == id,PurchaseDetails);
            return PurchaseDetails;                
        }

        public PurchaseDetails DeletePurchaseDetail(string id){
            var PurchaseDetails = _collection.Find(PurchaseDetails => PurchaseDetails.id == id).FirstOrDefault();
            _collection.DeleteOne(PurchaseDetails=> PurchaseDetails.id==id);
            return PurchaseDetails;
        }
    
    }
}