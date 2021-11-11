using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class Migrations{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public string migrations { get; set; }

        [BsonElement]
        public int batch { get; set; }
        [BsonElement]
        public string email { get; set; }   
    }
}