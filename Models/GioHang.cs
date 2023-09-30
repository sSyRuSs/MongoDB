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
        public ObjectId Id { get; set; }
        [BsonElement("cartID")]
        public string? cartID{get;set;}
        [BsonElement("customer")]
        public Customer Customer{get;set;}
        [BsonElement("detail")]
        public CartDetail[] CartDetail{get;set;}
        [BsonElement("total")]
        public int Total{get;set;}
    }
    public class Customer
    {
        [BsonElement("customerID")]
        public string? CustomerID { get; set; }
        [BsonElement("customerName")]
        public string? CustomerName { get; set; }
    }
    public class CartDetail
    {
        [BsonElement("productID")]
        public string? ProductID { get; set; }
        [BsonElement("productName")]
        public string? ProductName { get; set; }
        [BsonElement("quantity")]
        public int Quantity { get; set; }
        [BsonElement("price")]
        public int Price { get; set; }
    }
    
}
