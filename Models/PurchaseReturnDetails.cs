using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class PurchaseReturnDetails{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public string cost { get; set; }

        [BsonElement]
        public int purchase_unit_id { get; set; }
        [BsonElement]
        public double TaxNet { get; set; }   
        [BsonElement]

        public string tax_method { get; set; }
        [BsonElement]

        public double discount { get; set; }
        [BsonElement]

        public string discount_method { get; set; }
        [BsonElement]

        public double total { get; set; }
        [BsonElement]

        public double quantity { get; set; }
        [BsonElement]

        public int purchase_return_id { get; set; }
        [BsonElement]

        public int product_id { get; set; }
        [BsonElement]

        public int product_variant_id { get; set; }
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public int updated_at   { get; set; }
        [BsonElement]
        public int deleted_at { get; set; }
    }
}