using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class SaleService{
        private readonly IMongoCollection<Sales> _collection;

        public SaleService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Sales>("ProjectCollection");
        }

        public List<Sales> GetSales()=> _collection.Find(Sales=> true).ToList();

        public Sales GetSale(string id )=> _collection.Find(Sales=> Sales.id== id).FirstOrDefault();

        public Sales PostSale (Sales sales){
            _collection.InsertOne(sales);
            return sales;
        }

        public Sales PutSale (string id, Sales sales){
            _collection.ReplaceOne(sales=> sales.id == id,sales);
            return sales;                
        }

        public Sales DeleteSale(string id){
            var sales = _collection.Find(sales => sales.id == id).FirstOrDefault();
            _collection.DeleteOne(Sales=> Sales.id==id);
            return sales;
        }
    
    }
}