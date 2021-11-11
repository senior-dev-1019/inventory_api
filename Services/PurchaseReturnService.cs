using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class PurchaseReturnService{
        private readonly IMongoCollection<PurchaseReturn> _collection;

        public PurchaseReturnService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<PurchaseReturn>("ProjectCollection");
        }

        public List<PurchaseReturn> GetPurchaseReturns()=> _collection.Find(PurchaseReturn=> true).ToList();

        public PurchaseReturn GetPurchaseReturn(string id )=> _collection.Find(PurchaseReturn=> PurchaseReturn.id== id).FirstOrDefault();

        public PurchaseReturn PostPurchaseReturn (PurchaseReturn PurchaseReturn){
            _collection.InsertOne(PurchaseReturn);
            return PurchaseReturn;
        }

        public PurchaseReturn PutPurchaseReturn (string id, PurchaseReturn PurchaseReturn){
            _collection.ReplaceOne(PurchaseReturn=> PurchaseReturn.id == id,PurchaseReturn);
            return PurchaseReturn;                
        }

        public PurchaseReturn DeletePurchaseReturn(string id){
            var PurchaseReturn = _collection.Find(PurchaseReturn => PurchaseReturn.id == id).FirstOrDefault();
            _collection.DeleteOne(PurchaseReturn=> PurchaseReturn.id==id);
            return PurchaseReturn;
        }
    
    }
}