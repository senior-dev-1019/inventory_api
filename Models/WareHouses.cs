using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class WareHouses{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public string name { get; set; }

        [BsonElement]
        public string city { get; set; }
        [BsonElement]
        public string mobile { get; set; }
        [BsonElement]
        public string zip { get; set; }
        [BsonElement]
        public string email { get; set; }   
        [BsonElement]

        public string country { get; set; }
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public string updated_at   { get; set; }
        [BsonElement]
        public string deleted_at { get; set; }
    }
}