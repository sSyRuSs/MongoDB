using WebApplication1.Interfaces;
using WebApplication1.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.AspNetCore.Http.HttpResults;
namespace WebApplication1.Repositories
{
    public class SanPhamRepos:ISanPhamRepos
    {
        private readonly IMongoCollection<SanPham> _sanpham;
        public SanPhamRepos(IMongoDBSettings settings, IMongoClient mongoClient)
        {
            var db = mongoClient.GetDatabase(settings.DatabaseName);
            _sanpham = db.GetCollection<SanPham>(settings.CollectionName2);

        }
        public SanPham AddSP(SanPham sanPham)
        {
            if(!CheckExist(sanPham.ProductID))
            {
                _sanpham.InsertOne(sanPham);
                return sanPham;
            }
            throw new Exception("San pham trung");
        }

        public void Remove(int id)
        {
            _sanpham.DeleteOne(sp => sp.ProductID == id);
        }

        public void Update(int id, SanPham sanPham)
        {
            var filter = Builders<SanPham>.Filter.Eq(sp => sp.ProductID, id);
            var update = Builders<SanPham>.Update
                .Set(sp => sp.ProductName, sanPham.ProductName)
                .Set(sp => sp.ProductImage, sanPham.ProductImage)
                .Set(sp => sp.UnitPrice, sanPham.UnitPrice)
                .Set(sp => sp.Quantity, sanPham.Quantity)
                .Set(sp => sp.Discount, sanPham.Discount)
                .Set(sp=> sp.Category.CategoryID, sanPham.Category.CategoryID)
                .Set(sp=> sp.Category.CategoryName, sanPham.Category.CategoryName)
                .Set(sp => sp.Supplier.SupplierID, sanPham.Supplier.SupplierID)
                .Set(sp => sp.Supplier.SupplierName, sanPham.Supplier.SupplierName);
            _sanpham.UpdateOne(filter, update);
        }

        public List<SanPham> GetAllSP()
        {
            return _sanpham.Find(sp => true).ToList();
        }

        public SanPham GetByID(int id)
        {
            return _sanpham.Find(sp => sp.ProductID == id).FirstOrDefault();
        }

        public SanPham Get(string name)
        {
            return _sanpham.Find(sp => sp.ProductName == name).FirstOrDefault();
        }

        public List<SanPham> GetAllByCat(string name)
        {
            return _sanpham.Find(sp => sp.Category.CategoryName == name).ToList();
        }
        public List<SanPham> GetAllBySupplier(string name)
        {
            return _sanpham.Find(sp => sp.Supplier.SupplierName == name).ToList();
        }
        public bool CheckExist(int productId)
        {
            var sp = _sanpham.Find(sp => sp.ProductID == productId).FirstOrDefault();
            if (sp == null)
            {
                return false;
            }
            return true;
        }
    }
}