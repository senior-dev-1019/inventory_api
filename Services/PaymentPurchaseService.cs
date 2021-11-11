using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class PaymentPurchaseService{
        private readonly IMongoCollection<PaymentPurchases> _collection;

        public PaymentPurchaseService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<PaymentPurchases>("ProjectCollection");
        }

        public List<PaymentPurchases> GetPaymentPurchases()=> _collection.Find(PaymentPurchases=> true).ToList();

        public PaymentPurchases GetPaymentPurchase(string id )=> _collection.Find(PaymentPurchases=> PaymentPurchases.id== id).FirstOrDefault();

        public PaymentPurchases PostPaymentPurchase (PaymentPurchases PaymentPurchases){
            _collection.InsertOne(PaymentPurchases);
            return PaymentPurchases;
        }

        public PaymentPurchases PutPaymentPurchase (string id, PaymentPurchases PaymentPurchases){
            _collection.ReplaceOne(PaymentPurchases=> PaymentPurchases.id == id,PaymentPurchases);
            return PaymentPurchases;                
        }

        public PaymentPurchases DeletePaymentPurchase(string id){
            var PaymentPurchases = _collection.Find(PaymentPurchases => PaymentPurchases.id == id).FirstOrDefault();
            _collection.DeleteOne(PaymentPurchases=> PaymentPurchases.id==id);
            return PaymentPurchases;
        }
    
    }
}