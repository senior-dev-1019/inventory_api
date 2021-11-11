using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class CategoryService{
        private readonly IMongoCollection<Categories> _collection;

        public CategoryService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Categories>("ProjectCollection");
        }

        public List<Categories> GetCategories()=> _collection.Find(Categories=> true).ToList();

        public Categories GetCategory(string id )=> _collection.Find(Categories=> Categories.id== id).FirstOrDefault();

        public Categories PostCategory (Categories brands){
            _collection.InsertOne(brands);
            return brands;
        }

        public Categories PutCategory (string id, Categories brands){
            _collection.ReplaceOne(brands=> brands.id == id,brands);
            return brands;                
        }

        public Categories DeleteCategory(string id){
            var brands = _collection.Find(brands => brands.id == id).FirstOrDefault();
            _collection.DeleteOne(Categories=> Categories.id==id);
            return brands;
        }
    
    }
}