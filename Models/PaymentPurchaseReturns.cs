using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class PaymentPurchaseReturns{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public int user_id { get; set; }

        [BsonElement]
        public string date { get; set; }
        [BsonElement]
        public string Ref { get; set; }   
        [BsonElement]

        public int purchase_return_id { get; set; }
        [BsonElement]

        public double montant { get; set; }
        [BsonElement]

        public double change { get; set; }
        [BsonElement]

        public string Reglement{ get; set; }
        [BsonElement]

        public string notes { get; set; }
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public int updated_at   { get; set; }
        [BsonElement]
        public int deleted_at { get; set; }
    }
}