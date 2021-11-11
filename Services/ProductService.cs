using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class ProductService{
        private readonly IMongoCollection<Products> _collection;

        public ProductService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Products>("ProjectCollection");
        }

        public List<Products> GetProducts()=> _collection.Find(Products=> true).ToList();

        public Products GetProduct(string id )=> _collection.Find(Products=> Products.id== id).FirstOrDefault();

        public Products PostProduct(Products Products){
            _collection.InsertOne(Products);
            return Products;
        }

        public Products PutProduct (string id, Products Products){
            _collection.ReplaceOne(Products=> Products.id == id,Products);
            return Products;                
        }

        public Products DeleteProduct(string id){
            var Products = _collection.Find(Products => Products.id == id).FirstOrDefault();
            _collection.DeleteOne(Products=> Products.id==id);
            return Products;
        }
    
    }
}