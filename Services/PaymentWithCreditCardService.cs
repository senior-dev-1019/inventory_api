using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class PaymentWithCreditCardService{
        private readonly IMongoCollection<PaymentWithCreditCard> _collection;

        public PaymentWithCreditCardService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<PaymentWithCreditCard>("ProjectCollection");
        }

        public List<PaymentWithCreditCard> GetPaymentWithCreditCards()=> _collection.Find(PaymentWithCreditCard=> true).ToList();

        public PaymentWithCreditCard GetPaymentWithCreditCard(string id )=> _collection.Find(PaymentWithCreditCard=> PaymentWithCreditCard.id== id).FirstOrDefault();

        public PaymentWithCreditCard PostPaymentWithCreditCard (PaymentWithCreditCard PaymentWithCreditCard){
            _collection.InsertOne(PaymentWithCreditCard);
            return PaymentWithCreditCard;
        }

        public PaymentWithCreditCard PutPaymentWithCreditCard (string id, PaymentWithCreditCard PaymentWithCreditCard){
            _collection.ReplaceOne(PaymentWithCreditCard=> PaymentWithCreditCard.id == id,PaymentWithCreditCard);
            return PaymentWithCreditCard;                
        }

        public PaymentWithCreditCard DeletePaymentWithCreditCard(string id){
            var PaymentWithCreditCard = _collection.Find(PaymentWithCreditCard => PaymentWithCreditCard.id == id).FirstOrDefault();
            _collection.DeleteOne(PaymentWithCreditCard=> PaymentWithCreditCard.id==id);
            return PaymentWithCreditCard;
        }
    
    }
}