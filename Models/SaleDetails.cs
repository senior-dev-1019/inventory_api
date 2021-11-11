using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Swagger.Models{
    public class SaleDetails{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id {get;set;}

        [BsonElement]
        public int sale_id { get; set; }
        [BsonElement]
        public int product_id { get; set; }
        [BsonElement]
        public int product_variant_id { get; set; }
        [BsonElement]
        public double price { get; set; }
        [BsonElement]

        public int sale_unit_id { get; set; }
        [BsonElement]

        public double TaxNet { get; set; }
        [BsonElement]

        public string tax_methods { get; set; }
        [BsonElement]

        public double discount { get; set; }
        [BsonElement]

        public string discount_method { get; set; }
        [BsonElement]

        public double total { get; set; }
        [BsonElement]

        public double quantitys { get; set; }
        [BsonElement]
        public string created_at { get; set; }
        [BsonElement]
        public string updated_at   { get; set; }
        [BsonElement]
        public string deleted_at { get; set; }
    }
}