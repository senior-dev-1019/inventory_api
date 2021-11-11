using Swagger.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Swagger.Services{
    public class RelationalSchemaService{
        private readonly IMongoCollection<RelationalSchema> _collection;

        public RelationalSchemaService(IConfiguration configuration){
            var Client  = new MongoClient(configuration.GetConnectionString("DB"));
            var database = Client.GetDatabase("ProjectDB");

            _collection = database.GetCollection<RelationalSchema>("ProjectCollection");
        }

        public List<RelationalSchema> GetRelationalSchemas()=> _collection.Find(RelationalSchema=> true).ToList();

        public RelationalSchema GetRelationalSchema(string id )=> _collection.Find(RelationalSchema=> RelationalSchema.id== id).FirstOrDefault();

        public RelationalSchema PostRelationalSchema (RelationalSchema RelationalSchema){
            _collection.InsertOne(RelationalSchema);
            return RelationalSchema;
        }

        public RelationalSchema PutRelationalSchema (string id, RelationalSchema RelationalSchema){
            _collection.ReplaceOne(RelationalSchema=> RelationalSchema.id == id,RelationalSchema);
            return RelationalSchema;                
        }

        public RelationalSchema DeleteRelationalSchema(string id){
            var RelationalSchema = _collection.Find(RelationalSchema => RelationalSchema.id == id).FirstOrDefault();
            _collection.DeleteOne(RelationalSchema=> RelationalSchema.id==id);
            return RelationalSchema;
        }
    
    }
}