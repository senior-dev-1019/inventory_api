using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class AdjustmentService{
        private readonly IMongoCollection<Adjustments> _collection;

        public AdjustmentService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<Adjustments>("ProjectCollection");
        }

        public List<Adjustments> GetAdjustments()=> _collection.Find(Adjustments=> true).ToList();

        public Adjustments GetAdjustment(string id )=> _collection.Find(Adjustments=> Adjustments.id== id).FirstOrDefault();

        public Adjustments PostAdjustments (Adjustments adjustmentDetails){
            _collection.InsertOne(adjustmentDetails);
            return adjustmentDetails;
        }

        public Adjustments PutAdjustments (string id, Adjustments adjustmentDetails){
            _collection.ReplaceOne(adjustmentDetails=> adjustmentDetails.id == id,adjustmentDetails);
            return adjustmentDetails;                
        }

        public Adjustments DeleteAdjustments(string id){
            var adjustmentDetails = _collection.Find(adjustmentDetails => adjustmentDetails.id == id).FirstOrDefault();
            _collection.DeleteOne(Adjustments=> Adjustments.id==id);
            return adjustmentDetails;
        }
    
    }
}