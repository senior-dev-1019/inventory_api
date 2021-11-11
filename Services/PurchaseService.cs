using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class PurchaseService{
        private readonly IMongoCollection<Purchases> _collection;

        public PurchaseService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Purchases>("ProjectCollection");
        }

        public List<Purchases> GetPurchases()=> _collection.Find(Purchases=> true).ToList();

        public Purchases GetPurchase(string id )=> _collection.Find(Purchases=> Purchases.id== id).FirstOrDefault();

        public Purchases PostPurchase (Purchases Purchases){
            _collection.InsertOne(Purchases);
            return Purchases;
        }

        public Purchases PutPurchase (string id, Purchases Purchases){
            _collection.ReplaceOne(Purchases=> Purchases.id == id,Purchases);
            return Purchases;                
        }

        public Purchases DeletePurchase(string id){
            var Purchases = _collection.Find(Purchases => Purchases.id == id).FirstOrDefault();
            _collection.DeleteOne(Purchases=> Purchases.id==id);
            return Purchases;
        }
    
    }
}