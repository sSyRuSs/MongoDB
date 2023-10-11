using WebApplication1.Interfaces;
using WebApplication1.Models;
using MongoDB.Bson;
using MongoDB.Driver;
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
        public SanPham AddNV(SanPham sanPham)
        {
            _sanpham.InsertOne(sanPham);
            return sanPham;
        }

        public void Remove(string id)
        {
            _sanpham.DeleteOne(nv => nv.ProductID == id);
        }

        public void Update(string id, SanPham sanPham)
        {
            _sanpham.ReplaceOne(sanPham => sanPham.ProductID == id, sanPham);
        }
        public List<SanPham> GetAllNV()
        {
            return _sanpham.Find(SanPham => true).ToList();
        }

        public SanPham Get(string id)
        {
            return _sanpham.Find(sp => sp.ProductID == id).FirstOrDefault();
        }

        public List<SanPham> GetAllByCat(string name)
        {
            return _sanpham.Find(sp => sp.Category.CategoryName == name).ToList();
        }
        public List<SanPham> GetAllBySupplier(string name)
        {
            return _sanpham.Find(sp => sp.Supplier.SupplierName == name).ToList();
        }
        public bool CheckExist(string productId)
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