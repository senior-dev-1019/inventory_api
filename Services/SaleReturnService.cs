using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class SaleReturnService{
        private readonly IMongoCollection<SaleReturns> _collection;

        public SaleReturnService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<SaleReturns>("ProjectCollection");
        }

        public List<SaleReturns> GetSaleReturns()=> _collection.Find(SaleReturns=> true).ToList();

        public SaleReturns GetSaleReturn(string id )=> _collection.Find(SaleReturns=> SaleReturns.id== id).FirstOrDefault();

        public SaleReturns PostSaleReturn (SaleReturns saleReturns){
            _collection.InsertOne(saleReturns);
            return saleReturns;
        }

        public SaleReturns PutSaleReturn (string id, SaleReturns saleReturns){
            _collection.ReplaceOne(saleReturns=> saleReturns.id == id,saleReturns);
            return saleReturns;                
        }

        public SaleReturns DeleteSaleReturn(string id){
            var saleReturns = _collection.Find(saleReturns => saleReturns.id == id).FirstOrDefault();
            _collection.DeleteOne(SaleReturns=> SaleReturns.id==id);
            return saleReturns;
        }
    
    }
}