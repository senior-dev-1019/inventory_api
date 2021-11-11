using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class Settings{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public int currency_id { get; set; }

        [BsonElement]
        public string CompanyName { get; set; }
        [BsonElement]
        public string email { get; set; }   
        [BsonElement]

        public string CompanyPhone { get; set; }
        [BsonElement]

        public string CompanyAddress { get; set; }
        [BsonElement]

        public string logo { get; set; }
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public string updated_at   { get; set; }
        [BsonElement]
        public string deleted_at { get; set; }
    }
}