using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    [BsonIgnoreExtraElements]
    public class NhanVien
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("employeeID")]
        public string? EmployeeID { get; set; }
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("email")]
        public string? Email { get; set;}

        [BsonElement("gender")]
        public string Gender { get; set; } = String.Empty;

        [BsonElement("age")]
        public int Age { get; set; }
        [BsonElement("password")]
        public string Password { get; set; } = String.Empty;
        [BsonElement("role")]
        public Role Role{get;set;}
    }
    public class Role
    {
        [BsonElement("roleID")]
        public string? RoleID { get; set; }
        [BsonElement("roleName")]
        public string? RoleName { get; set; }
    }
}