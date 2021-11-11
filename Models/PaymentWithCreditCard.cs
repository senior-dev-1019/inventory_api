using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class PaymentWithCreditCard{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public int payment_id { get; set; }

        [BsonElement]
        public int customer_id { get; set; }
        [BsonElement]
        public string customer_stripe_id { get; set; }   
        [BsonElement]

        public string change_id { get; set; }
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public string updated_at   { get; set; }
        [BsonElement]
        public string deleted_at { get; set; }
    }
}