using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [BsonIgnoreExtraElements]
    public class GioHang
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("customerID")]
        public string? CustomerID { get; set; }
        [BsonElement("customerName")]
        public string? CustomerName { get; set; }
        [BsonElement("cart")]
        public Cart[] Cart{get;set;}
        
    }
    public class Cart
    {
        [BsonElement("cartID")]
        public string? cartID{get;set;}

        [BsonElement("DateCreate")]
        public DateTime Date{get; set;}
        
        [BsonElement("detail")]
        public CartDetail[] CartDetail{get;set;}
        [BsonElement("total")]
        public int Total{get;set;}
    }
    public class CartDetail 
    {
        public IList<VM_SanPham> sanPhams{get; set;}
    } 
}
