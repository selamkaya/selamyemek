using SelamYemek.Data.Base;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelamYemek.Data
{
    public class Product : EntityBase
    {
        [BsonElement("categoryId")]
        public string CategoryId { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("currency")]
        public string Currency { get; set; }
    }
}
