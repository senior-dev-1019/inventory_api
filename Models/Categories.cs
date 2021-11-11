using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class Categories{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public string code { get; set; }

        [BsonElement]
        public string name { get; set; }
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public string updated_at   { get; set; }
        [BsonElement]
        public string deleted_at { get; set; }
    }
}