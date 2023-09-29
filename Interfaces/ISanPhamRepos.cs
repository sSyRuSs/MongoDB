using WebApplication1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace WebApplication1.Interfaces
{
    public interface ISanPhamRepos
    {
        public SanPham AddNV(SanPham sanPham);
        public void Remove(string id);
        public void Update(string id, SanPham sanPham);
        public List<SanPham> GetAllNV();
        public SanPham Get(string id);
    }
}
