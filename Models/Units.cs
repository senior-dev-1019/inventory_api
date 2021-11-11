using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class Units{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public string name { get; set; }

        [BsonElement]
        public string ShortName { get; set; }
        [BsonElement]
        public int base_unit { get; set; }   
        [BsonElement]

        public string Operator { get; set; }
        [BsonElement]

        public double operator_value { get; set; }
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public string updated_at   { get; set; }
        [BsonElement]
        public string deleted_at { get; set; }
    }
}