using WebApplication1.Models;
using WebApplication1.ViewModels;
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

        public List<VM_SP_Cat> GetAllCat();
        public VM_SP_Cat AddCat(VM_SP_Cat Cat);
        public void RemoveCat(string id);
        public void UpdateCat(string id, VM_SP_Cat Cat);
        public VM_SP_Cat getCatById(string id);

        public List<VM_SP_Sup> GetAllSup();
        public VM_SP_Sup AddSup(VM_SP_Sup Sup);
        public void RemoveSup(string id);
        public void UpdateSup(string id, VM_SP_Sup Sup);
    }
}
