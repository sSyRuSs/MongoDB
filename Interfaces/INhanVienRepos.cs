using WebApplication1.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using WebApplication1.ViewModels;

namespace WebApplication1.Interfaces
{
    public interface INhanVienRepos
    {
        // public string GetInfo();
        public NhanVien AddNV(NhanVien nhanVien);
        public void Remove(string id);
        public void Update(string id, NhanVien nhanVien);
        public List<NhanVien> GetAllNV();
        public NhanVien Get(string id);
        public VM_NhanVien GetByEmail(string id);
        public List<NhanVien> GetAllByRole(string role);
    }
}
