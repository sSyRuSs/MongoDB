using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

            return NoContent();
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
    }
}