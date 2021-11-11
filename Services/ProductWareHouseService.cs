using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class ProductWareHouseService{
        private readonly IMongoCollection<ProductWareHouse> _collection;

        public ProductWareHouseService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<ProductWareHouse>("ProjectCollection");
        }

        public List<ProductWareHouse> GetProductWareHouses()=> _collection.Find(ProductWareHouse=> true).ToList();

        public ProductWareHouse GetProductWareHouse(string id )=> _collection.Find(ProductWareHouse=> ProductWareHouse.id== id).FirstOrDefault();

        public ProductWareHouse PostProductWareHouse (ProductWareHouse ProductWareHouse){
            _collection.InsertOne(ProductWareHouse);
            return ProductWareHouse;
        }

        public ProductWareHouse PutProductWareHouse (string id, ProductWareHouse ProductWareHouse){
            _collection.ReplaceOne(ProductWareHouse=> ProductWareHouse.id == id,ProductWareHouse);
            return ProductWareHouse;                
        }

        public ProductWareHouse DeleteProductWareHouse(string id){
            var ProductWareHouse = _collection.Find(ProductWareHouse => ProductWareHouse.id == id).FirstOrDefault();
            _collection.DeleteOne(ProductWareHouse=> ProductWareHouse.id==id);
            return ProductWareHouse;
        }
    
    }
}