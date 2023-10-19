using WebApplication1.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApplication1.Models;
using MongoDB.Driver.Core.Operations;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace WebApplication1.Repositories
{
    public class NhanVienRepos : INhanVienRepos
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMongoCollection<NhanVien> _nhanvien;
        public NhanVienRepos(IMongoDBSettings settings, IMongoClient mongoClient, IHttpContextAccessor httpContextAccessor)
        {
            var db = mongoClient.GetDatabase(settings.DatabaseName);
            _nhanvien = db.GetCollection<NhanVien>(settings.CollectionName1);
            _httpContextAccessor = httpContextAccessor;
        }

        // public string GetInfo()
        // {
        //     var info = string.Empty;
        //     if(_httpContextAccessor.HttpContext is not null)
        //     {
        //         info = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        //     }
        //     return info;
        // }

        public NhanVien AddNV(NhanVien nhanVien)
        {
           _nhanvien.InsertOne(nhanVien);
            return nhanVien;
        }

        public void Remove(string id)
        {
            _nhanvien.DeleteOne(nv => nv.EmployeeID == id);
        }

        public void Update(string id, NhanVien nhanVien)
        {
            var filter = Builders<NhanVien>.Filter.Eq(nv => nv.EmployeeID, id);
            var update = Builders<NhanVien>.Update
                .Set(nv => nv.Name, nhanVien.Name)
                .Set(nv => nv.Age, nhanVien.Age)
                .Set(nv => nv.Email, nhanVien.Email)
                .Set(nv => nv.Gender, nhanVien.Gender)
                .Set(nv => nv.Password, nhanVien.Password)
                .Set(nv=> nv.Role.RoleID, nhanVien.Role.RoleID)
                .Set(nv=> nv.Role.RoleName, nhanVien.Role.RoleName);
            _nhanvien.UpdateOne(filter, update);
        }
        public List<NhanVien> GetAllNV()
        {
            return _nhanvien.Find(nhanvien => true).ToList();
        }

        public NhanVien Get(string id)
        {
            return _nhanvien.Find(nv => nv.EmployeeID == id).FirstOrDefault();
        }
        public NhanVien GetByEmail(string id)
        {
            return _nhanvien.Find(nv => nv.Email == id).FirstOrDefault();
        }

        public List<NhanVien> GetAllByRole(string role)
        {
            return _nhanvien.Find(nv => nv.Role.RoleName == role).ToList();
        }
        
        
    }
}