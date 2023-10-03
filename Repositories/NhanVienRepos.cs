using WebApplication1.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApplication1.Models;
using MongoDB.Driver.Core.Operations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Repositories
{
    public class NhanVienRepos : INhanVienRepos
    {
        private readonly IMongoCollection<NhanVien> _nhanvien;
        public NhanVienRepos(IMongoDBSettings settings, IMongoClient mongoClient)
        {
            var db = mongoClient.GetDatabase(settings.DatabaseName);
            _nhanvien = db.GetCollection<NhanVien>(settings.CollectionName1);

        }
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
            _nhanvien.ReplaceOne(nhanVien => nhanVien.EmployeeID == id, nhanVien);
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
    }
}