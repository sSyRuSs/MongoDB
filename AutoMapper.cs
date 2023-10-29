using AutoMapper;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<NhanVien, VM_NhanVien>();
            CreateMap<SanPham, VM_SanPham>();
        }
    }
}