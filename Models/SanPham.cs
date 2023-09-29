using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    [BsonIgnoreExtraElements]
    public class SanPham
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("id")]
        public string MaSP { get; set; } = String.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("price")]
        public int Price { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }=String.Empty;
        [BsonElement("image")]
        public string Image { get; set; } = String.Empty;
        [BsonElement("category")]
        public string Category { get; set; } = String.Empty;
        [BsonElement("supplier")]
        public string Supplier { get; set; } = String.Empty;
    }
}