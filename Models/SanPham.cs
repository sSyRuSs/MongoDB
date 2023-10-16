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
        [BsonIgnoreIfDefault]
        [BsonElement("productID")]
        public int ProductID { get; set; }
        [BsonElement("productName")]
        public string? ProductName { get; set; }
        [BsonElement("image")]
        public string? ProductImage{get; set;}
        [BsonElement("unitPrice")]
        public int UnitPrice { get; set; }
        [BsonElement("quantity")]
        public int Quantity { get; set; }
        [BsonElement("discount")]
        public int Discount { get; set; }
        [BsonElement("category")]
        public Category Category { get; set; }
        [BsonElement("supplier")]
        public Supplier Supplier { get; set; }
    }
    public class Category
    {
        [BsonElement("categoryID")]
        public string? CategoryID { get; set; }
        [BsonElement("categoryName")]
        public string? CategoryName { get; set; }
    }
    public class Supplier
    {
        [BsonElement("supplierID")]
        public string? SupplierID { get; set; }
        [BsonElement("supplierName")]
        public string? SupplierName { get; set; }
    }
}