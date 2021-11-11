using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class Expense{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public string date { get; set; }

        [BsonElement]
        public string Ref { get; set; }
        [BsonElement]
        public int user_id { get; set; }   
        [BsonElement]

        public int expense_category_id { get; set; }
        [BsonElement]

        public int warehouse_id { get; set; }
        [BsonElement]

        public string details { get; set; }
        [BsonElement]

        public double amount { get; set; }
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public string updated_at   { get; set; }
        [BsonElement]
        public string deleted_at { get; set; }
    }
}