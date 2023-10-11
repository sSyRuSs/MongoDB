using WebApplication1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace WebApplication1.Interfaces
{
    public interface IGioHangRepos
    {
        public GioHang AddGH(GioHang gioHang);
        public void Remove(string id);
        public void Update(string id, GioHang gioHang);
        public List<GioHang> GetAllNV();
        public GioHang Get(string id);
        public List<GioHang> GetAllCartByCus(string id);
        public List<GioHang> GetAllCartByDate(DateTime date);
    }
}
