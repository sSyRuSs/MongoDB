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
            _sanpham.DeleteOne(nv => nv.MaSP == id);
        }

        public void Update(string id, SanPham sanPham)
        {
            _sanpham.ReplaceOne(sanPham => sanPham.MaSP == id, sanPham);
        }
        public List<SanPham> GetAllNV()
        {
            return _sanpham.Find(SanPham => true).ToList();
        }

        public SanPham Get(string id)
        {
            return _sanpham.Find(sp => sp.MaSP == id).FirstOrDefault();
        }
    }
}