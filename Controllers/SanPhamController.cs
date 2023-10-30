using WebApplication1.Models;
using WebApplication1.ViewModels;
using WebApplication1.Repositories;
using WebApplication1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using AutoMapper;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamRepos _spRepos;
        public SanPhamController(ISanPhamRepos _spRepos)
        {
            this._spRepos = _spRepos;
        }

        [HttpGet]
        public ActionResult<List<SanPham>> GetAll()
        {
            return _spRepos.GetAllSP();
        }
        [HttpGet("{id}")]
        public ActionResult<SanPham> GetSanPhamById(string id)
        {
            var sp = _spRepos.Get(id);
            if (sp == null)
            {
                return NotFound();
            }
            return sp;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<SanPham> Post([FromBody] SanPham sp)
        {

            _spRepos.AddSP(sp);
            return CreatedAtAction(nameof(GetAll), new { id = sp.ProductID }, sp);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SanPham sp)
        {
            var Sp = _spRepos.GetByID(id);

            if (Sp == null)
            {
                return NotFound($"San pham with Id = {id} not found");
            }

            _spRepos.Update(id, sp);

            return Ok($"San pham with Id = {id} update");
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var sp = _spRepos.GetByID(id);

            if (sp == null)
            {
                return NotFound($"San pham with Id = {id} not found");
            }

            _spRepos.Remove(sp.ProductID);

            return Ok($"San pham with Id = {id} deleted");
        }

        [HttpGet("GetAllByCat")]
        public ActionResult<List<SanPham>> GetAllByCat(string name)
        {
            return _spRepos.GetAllByCat(name);
        }
        [HttpGet("GetAllBySupplier")]
        public ActionResult<List<SanPham>> GetAllBySupplier(string name)
        {
            return _spRepos.GetAllBySupplier(name);
        }

        [HttpGet("CheckExist")]
        public ActionResult<bool> CheckExist(int id)
        {
            bool sp = _spRepos.CheckExist(id);
            return Ok(sp);
        }

        [HttpGet("GetAllCategory")]
        public ActionResult<List<VM_SP_Cat>> GetAllCat()
        {
            return _spRepos.GetAllCat();
        }

        // [HttpPost]
        // public ActionResult<VM_SP_Cat> PostCat([FromBody] VM_SP_Cat cat)
        // {
        //     _spRepos.AddCat(cat);
        //     return CreatedAtAction(nameof(GetAll), new { id = cat.CategoryID }, cat);
        // }

        // [HttpPut("{id}")]
        // public ActionResult PutCat(string id, [FromBody] VM_SP_Cat cat)
        // {
        //     var Cat = _spRepos.getCatById(id);

        //     if (Cat == null)
        //     {
        //         return NotFound($"Category with Id = {id} not found");
        //     }

        //     _spRepos.UpdateCat(id, cat);

        //     return Ok($"Category with Id = {id} update");
        
        // }

        [HttpGet("GetAllSupplier")]
        public ActionResult<List<VM_SP_Sup>> GetAllSupplier()
        {
            return _spRepos.GetAllSup();
        }

        [HttpGet("GetCatById")]
        public ActionResult<VM_SP_Cat> GetCatById(string id)
        {
            var cat = _spRepos.getCatById(id);
            if (cat == null)
            {
                return NotFound();
            }
            return cat;
        }

    }
}