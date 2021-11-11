using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class oAuthAccessTokens{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public long user_id { get; set; }

        [BsonElement]
        public long client_id { get; set; }
        [BsonElement]
        public string name { get; set; }   
        [BsonElement]
        public string scopes { get; set; }
        [BsonElement]
        public string revoked { get; set; }
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public string updated_at   { get; set; }
        [BsonElement]
        public string deleted_at { get; set; }
    }
}