using WebApplication1.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApplication1.Models;
using MongoDB.Driver.Core.Operations;

namespace WebApplication1.Repositories
{
    public class GioHangRepos : IGioHangRepos
    {
        private readonly IMongoCollection<GioHang> _giohang;
        public GioHangRepos(IMongoDBSettings settings, IMongoClient mongoClient)
        {
            var db = mongoClient.GetDatabase(settings.DatabaseName);
            _giohang = db.GetCollection<GioHang>(settings.CollectionName3);

        }
        public GioHang AddGH(GioHang gioHang)
        {
            _giohang.InsertOne(gioHang);
            return gioHang;
        }

        public void Remove(string id)
        {
            _giohang.DeleteOne(nv => nv.CustomerID == id);
        }

        public void Update(string id, GioHang gioHang)
        {
            _giohang.ReplaceOne(gioHang => gioHang.CustomerID == id, gioHang);
        }
        public List<GioHang> GetAllNV()
        {
            return _giohang.Find(gh => true).ToList();
        }

        public GioHang Get(string id)
        {
            return _giohang.Find(gh => gh.CustomerID == id).FirstOrDefault();
        }

    }
}