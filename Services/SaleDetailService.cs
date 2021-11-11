using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class SaleDetailService{
        private readonly IMongoCollection<SaleDetails> _collection;

        public SaleDetailService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<SaleDetails>("ProjectCollection");
        }

        public List<SaleDetails> GetSaleDetails()=> _collection.Find(SaleDetails=> true).ToList();

        public SaleDetails GetSaleDetail(string id )=> _collection.Find(SaleDetails=> SaleDetails.id== id).FirstOrDefault();

        public SaleDetails PostSaleDetail (SaleDetails user){
            _collection.InsertOne(user);
            return user;
        }

        public SaleDetails PutSaleDetail (string id, SaleDetails user){
            _collection.ReplaceOne(user=> user.id == id,user);
            return user;                
        }

        public SaleDetails DeleteSaleDetail(string id){
            var user = _collection.Find(user => user.id == id).FirstOrDefault();
            _collection.DeleteOne(SaleDetails=> SaleDetails.id==id);
            return user;
        }
    
    }
}