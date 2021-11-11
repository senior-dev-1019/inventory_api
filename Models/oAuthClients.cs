using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class oAuthClients{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public long user_id { get; set; }

        [BsonElement]
        public string name { get; set; }
        [BsonElement]
        public string secret { get; set; }   
        [BsonElement]

        public string provider { get; set; }
        [BsonElement]

        public string redirect { get; set; }
        [BsonElement]

        public int personal_access_client { get; set; }
        [BsonElement]

        public int password_client { get; set; }
        [BsonElement]
        public int revoked { get; set; }
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public string updated_at   { get; set; }
    }
}