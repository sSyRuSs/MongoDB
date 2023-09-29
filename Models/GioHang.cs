using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    [BsonIgnoreExtraElements]
    public class GioHang
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = String.Empty;
        #nullable disable
        [BsonElement("id")]
        public string MaSP { get; set; } = String.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("price")]
        public int Price { get; set; }
#nullable enable
        [BsonElement("description")]
        public string? Description { get; set; }
        [BsonElement("image")]
        public string? Image { get; set; }
        [BsonElement("category")]
        public string? Category { get; set; }
        [BsonElement("supplier")]
        public string? Supplier { get; set; }
        [BsonElement("quantity")]
        public int Quantity { get; set; }
    }
}
