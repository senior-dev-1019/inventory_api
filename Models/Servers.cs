using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class Servers{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public string host { get; set; }

        [BsonElement]
        public int port { get; set; }
        [BsonElement]
        public string username { get; set; }   
        [BsonElement]

        public string password { get; set; }
        [BsonElement]

        public string encryption { get; set; }
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public string updated_at   { get; set; }
        [BsonElement]
        public string deleted_at { get; set; }
    }
}