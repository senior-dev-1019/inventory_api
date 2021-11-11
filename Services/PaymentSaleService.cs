using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class PaymentSaleService{
        private readonly IMongoCollection<PaymentSales> _collection;

        public PaymentSaleService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<PaymentSales>("ProjectCollection");
        }

        public List<PaymentSales> GetPaymentSales()=> _collection.Find(PaymentSales=> true).ToList();

        public PaymentSales GetPaymentSale(string id )=> _collection.Find(PaymentSales=> PaymentSales.id== id).FirstOrDefault();

        public PaymentSales PostPaymentSale (PaymentSales PaymentSales){
            _collection.InsertOne(PaymentSales);
            return PaymentSales;
        }

        public PaymentSales PutPaymentSale (string id, PaymentSales PaymentSales){
            _collection.ReplaceOne(PaymentSales=> PaymentSales.id == id,PaymentSales);
            return PaymentSales;                
        }

        public PaymentSales DeletePaymentSale(string id){
            var PaymentSales = _collection.Find(PaymentSales => PaymentSales.id == id).FirstOrDefault();
            _collection.DeleteOne(PaymentSales=> PaymentSales.id==id);
            return PaymentSales;
        }
    
    }
}