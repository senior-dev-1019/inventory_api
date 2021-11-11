using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class ProductVariantService{
        private readonly IMongoCollection<ProductVariants> _collection;

        public ProductVariantService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<ProductVariants>("ProjectCollection");
        }

        public List<ProductVariants> GetProductVariants()=> _collection.Find(ProductVariants=> true).ToList();

        public ProductVariants GetProductVariant(string id )=> _collection.Find(ProductVariants=> ProductVariants.id== id).FirstOrDefault();

        public ProductVariants PostProductVariant (ProductVariants ProductVariants){
            _collection.InsertOne(ProductVariants);
            return ProductVariants;
        }

        public ProductVariants PutProductVariant (string id, ProductVariants ProductVariants){
            _collection.ReplaceOne(ProductVariants=> ProductVariants.id == id,ProductVariants);
            return ProductVariants;                
        }

        public ProductVariants DeleteProductVariant(string id){
            var ProductVariants = _collection.Find(ProductVariants => ProductVariants.id == id).FirstOrDefault();
            _collection.DeleteOne(ProductVariants=> ProductVariants.id==id);
            return ProductVariants;
        }
    
    }
}