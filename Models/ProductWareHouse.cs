using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class ProductWareHouse{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public int product_id { get; set; }

        [BsonElement]
        public int warehouse_id { get; set; }
        [BsonElement]
        public int product_variant_id { get; set; }   
        [BsonElement]

        public string password { get; set; }
        [BsonElement]

        public string avatar { get; set; }
        [BsonElement]

        public double qty { get; set; }
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public string updated_at   { get; set; }
        [BsonElement]
        public string deleted_at { get; set; }
    }
}