using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class PosSettings{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public string note_customer { get; set; }

        [BsonElement]
        public int show_note { get; set; }
        [BsonElement]
        public int show_barcode { get; set; }   
        [BsonElement]

        public int show_discount { get; set; }
        [BsonElement]

        public int show_customer { get; set; }
        [BsonElement]

        public int show_email { get; set; }
        [BsonElement]

        public int show_phone { get; set; }
        [BsonElement]

        public int show_address { get; set; }
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public string updated_at   { get; set; }
        [BsonElement]
        public string deleted_at { get; set; }
    }
}