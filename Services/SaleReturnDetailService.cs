using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class SaleReturnDetailService{
        private readonly IMongoCollection<SaleReturnDetails> _collection;

        public SaleReturnDetailService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<SaleReturnDetails>("ProjectCollection");
        }

        public List<SaleReturnDetails> GetSaleReturnDetails()=> _collection.Find(SaleReturnDetails=> true).ToList();

        public SaleReturnDetails GetSaleReturnDetail(string id )=> _collection.Find(SaleReturnDetails=> SaleReturnDetails.id== id).FirstOrDefault();

        public SaleReturnDetails PostSaleReturnDetail (SaleReturnDetails saleReturnDetail){
            _collection.InsertOne(saleReturnDetail);
            return saleReturnDetail;
        }

        public SaleReturnDetails PutSaleReturnDetail (string id, SaleReturnDetails saleReturnDetail){
            _collection.ReplaceOne(saleReturnDetail=> saleReturnDetail.id == id,saleReturnDetail);
            return saleReturnDetail;                
        }

        public SaleReturnDetails DeleteSaleReturnDetail(string id){
            var saleReturnDetail = _collection.Find(saleReturnDetail => saleReturnDetail.id == id).FirstOrDefault();
            _collection.DeleteOne(SaleReturnDetails=> SaleReturnDetails.id==id);
            return saleReturnDetail;
        }
    
    }
}