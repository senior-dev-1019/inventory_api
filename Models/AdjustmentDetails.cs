using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class AdjustmentDetails{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public int product_id { get; set; }

        [BsonElement]
        public int adjustment_id { get; set; }
        [BsonElement]
        public int product_variant { get; set; }   
        [BsonElement]

        public double quantity { get; set; }
        [BsonElement]

        public string type { get; set; }
        [BsonElement]

        public string created_at { get; set; }
        [BsonElement]
        public string updated_at   { get; set; }
    }
}