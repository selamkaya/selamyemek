using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelamYemek.Data.Base
{
    public abstract class EntityBase
    {
        #region Property
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }
        #endregion
    }
}
