using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class BrandService{
        private readonly IMongoCollection<Brands> _collection;

        public BrandService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Brands>("ProjectCollection");
        }

        public List<Brands> GetBrands()=> _collection.Find(Brands=> true).ToList();

        public Brands GetBrand(string id )=> _collection.Find(Brands=> Brands.id== id).FirstOrDefault();

        public Brands PostBrand (Brands brands){
            _collection.InsertOne(brands);
            return brands;
        }

        public Brands PutBrand (string id, Brands brands){
            _collection.ReplaceOne(brands=> brands.id == id,brands);
            return brands;                
        }

        public Brands DeleteBrand(string id){
            var brands = _collection.Find(brands => brands.id == id).FirstOrDefault();
            _collection.DeleteOne(Brands=> Brands.id==id);
            return brands;
        }
    
    }
}