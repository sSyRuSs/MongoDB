using WebApplication1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace WebApplication1.Interfaces
{
    public interface ISanPhamRepos
    {
        public SanPham AddSP(SanPham sanPham);
        public void Remove(int id);
        public void Update(int id, SanPham sanPham);
        public List<SanPham> GetAllSP();
        public SanPham GetByID(int id);
        public SanPham Get(string name);
        public List<SanPham> GetAllBySupplier(string name);
        public List<SanPham> GetAllByCat(string name);
        public bool CheckExist(int productId);
    }
}
