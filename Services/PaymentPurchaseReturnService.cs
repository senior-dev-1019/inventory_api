using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class PaymentPurchaseReturnService{
        private readonly IMongoCollection<PaymentPurchaseReturns> _collection;

        public PaymentPurchaseReturnService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<PaymentPurchaseReturns>("ProjectCollection");
        }

        public List<PaymentPurchaseReturns> GetPaymentPurchaseReturns()=> _collection.Find(PaymentPurchaseReturns=> true).ToList();

        public PaymentPurchaseReturns GetPaymentPurchaseReturn(string id )=> _collection.Find(PaymentPurchaseReturns=> PaymentPurchaseReturns.id== id).FirstOrDefault();

        public PaymentPurchaseReturns PostPaymentPurchaseReturn (PaymentPurchaseReturns PaymentPurchaseReturns){
            _collection.InsertOne(PaymentPurchaseReturns);
            return PaymentPurchaseReturns;
        }

        public PaymentPurchaseReturns PutPaymentPurchaseReturn (string id, PaymentPurchaseReturns PaymentPurchaseReturns){
            _collection.ReplaceOne(PaymentPurchaseReturns=> PaymentPurchaseReturns.id == id,PaymentPurchaseReturns);
            return PaymentPurchaseReturns;                
        }

        public PaymentPurchaseReturns DeletePaymentPurchaseReturn(string id){
            var PaymentPurchaseReturns = _collection.Find(PaymentPurchaseReturns => PaymentPurchaseReturns.id == id).FirstOrDefault();
            _collection.DeleteOne(PaymentPurchaseReturns=> PaymentPurchaseReturns.id==id);
            return PaymentPurchaseReturns;
        }
    
    }
}