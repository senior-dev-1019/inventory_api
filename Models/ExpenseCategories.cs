using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class ExpenseCategories{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public int user_id { get; set; }

        [BsonElement]
        public string name { get; set; }
        [BsonElement]
        public string description { get; set; }   
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public string updated_at   { get; set; }
        [BsonElement]
                public string deleted_at { get; set; }
    }
}