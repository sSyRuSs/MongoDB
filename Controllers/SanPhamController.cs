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
            return _spRepos.GetAllNV();
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
            _spRepos.AddNV(sp);

            return CreatedAtAction(nameof(GetAll), new { id = sp.ProductID }, sp);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] SanPham sp)
        {
            var Sp = _spRepos.Get(id);

            if (Sp == null)
            {
                return NotFound($"San pham with Id = {id} not found");
            }

            _spRepos.Update(id, sp);

            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var sp = _spRepos.Get(id);

            if (sp == null)
            {
                return NotFound($"San pham with Id = {id} not found");
            }

            _spRepos.Remove(sp.ProductID);

            return Ok($"San pham with Id = {id} deleted");
        }
    }
}