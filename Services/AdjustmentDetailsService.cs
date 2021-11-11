using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class AdjustmentDetailsService{
        private readonly IMongoCollection<AdjustmentDetails> _collection;

        public AdjustmentDetailsService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<AdjustmentDetails>("ProjectCollection");
        }

        public List<AdjustmentDetails> GetAdjustmentDetails()=> _collection.Find(AdjustmentDetails=> true).ToList();

        public AdjustmentDetails GetAdjustmentDetail(string id )=> _collection.Find(AdjustmentDetails=> AdjustmentDetails.id== id).FirstOrDefault();

        public AdjustmentDetails PostAdjustmentDetails (AdjustmentDetails adjustmentDetails){
            _collection.InsertOne(adjustmentDetails);
            return adjustmentDetails;
        }

        public AdjustmentDetails PutAdjustmentDetails (string id, AdjustmentDetails adjustmentDetails){
            _collection.ReplaceOne(adjustmentDetails=> adjustmentDetails.id == id,adjustmentDetails);
            return adjustmentDetails;                
        }

        public AdjustmentDetails DeleteAdjustmentDetails(string id){
            var adjustmentDetails = _collection.Find(adjustmentDetails => adjustmentDetails.id == id).FirstOrDefault();
            _collection.DeleteOne(AdjustmentDetails=> AdjustmentDetails.id==id);
            return adjustmentDetails;
        }
    
    }
}