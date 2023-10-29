using MongoDB.Bson;
using MongoDB.Driver;
namespace WebApplication1.Models
{
    public class MongoDBSettings:IMongoDBSettings
    {
        //public string ConnectionURI { get; set; } = "mongodb://localhost:27017";
        public string ConnectionURI{get;set;}="mongodb+srv://thanhlong1393:hOpy1u3Q6jNyG7Fr@cluster0.39onbpq.mongodb.net/?retryWrites=true&w=majority";
        public string DatabaseName { get; set; } = "DoAn";
        public string CollectionName1 { get; set; } = "NhanVien";
        public string CollectionName2 { get; set; } = "SanPham";
        public string CollectionName3 { get; set; } = "GioHang";

    }
}