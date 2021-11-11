using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class QuotationDetailService{
        private readonly IMongoCollection<QuotationDetails> _collection;

        public QuotationDetailService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<QuotationDetails>("ProjectCollection");
        }

        public List<QuotationDetails> GetQuotationDetails()=> _collection.Find(QuotationDetails=> true).ToList();

        public QuotationDetails GetQuotationDetail(string id )=> _collection.Find(QuotationDetails=> QuotationDetails.id== id).FirstOrDefault();

        public QuotationDetails PostQuotationDetail (QuotationDetails QuotationDetails){
            _collection.InsertOne(QuotationDetails);
            return QuotationDetails;
        }

        public QuotationDetails PutQuotationDetail(string id, QuotationDetails QuotationDetails){
            _collection.ReplaceOne(QuotationDetails=> QuotationDetails.id == id,QuotationDetails);
            return QuotationDetails;                
        }

        public QuotationDetails DeleteQuotationDetail(string id){
            var QuotationDetails = _collection.Find(QuotationDetails => QuotationDetails.id == id).FirstOrDefault();
            _collection.DeleteOne(QuotationDetails=> QuotationDetails.id==id);
            return QuotationDetails;
        }
    
    }
}