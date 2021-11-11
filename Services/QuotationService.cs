using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class QuotationService{
        private readonly IMongoCollection<Quotations> _collection;

        public QuotationService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Quotations>("ProjectCollection");
        }

        public List<Quotations> GetQuotations()=> _collection.Find(Quotations=> true).ToList();

        public Quotations GetQuotation(string id )=> _collection.Find(Quotations=> Quotations.id== id).FirstOrDefault();

        public Quotations PostQuotation(Quotations Quotations){
            _collection.InsertOne(Quotations);
            return Quotations;
        }

        public Quotations PutQuotation(string id, Quotations Quotations){
            _collection.ReplaceOne(Quotations=> Quotations.id == id,Quotations);
            return Quotations;                
        }

        public Quotations DeleteQuotation(string id){
            var Quotations = _collection.Find(Quotations => Quotations.id == id).FirstOrDefault();
            _collection.DeleteOne(Quotations=> Quotations.id==id);
            return Quotations;
        }
    
    }
}