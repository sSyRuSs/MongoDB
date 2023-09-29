using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        private readonly IGioHangRepos _ghRepos;
        public GioHangController(IGioHangRepos _ghRepos)
        {
            this._ghRepos = _ghRepos;
        }

        [HttpGet]
        public ActionResult<List<GioHang>> GetAll()
        {
            return _ghRepos.GetAllNV();
        }
        [HttpGet("{id}")]
        public ActionResult<GioHang> GetGioHangById(string id)
        {
            var nv = _ghRepos.Get(id);
            if (nv == null)
            {
                return NotFound();
            }
            return nv;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<GioHang> Post([FromBody] GioHang nv)
        {
            _ghRepos.AddGH(nv);

            return CreatedAtAction(nameof(GetAll), new { id = nv.Id }, nv);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] GioHang nv)
        {
            var Nv = _ghRepos.Get(id);

            if (Nv == null)
            {
                return NotFound($"Nhan vien with Id = {id} not found");
            }

            _ghRepos.Update(id, nv);

            return NoContent();
            //return ViewResult();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var nv = _ghRepos.Get(id);

            if (nv == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            _ghRepos.Remove(nv.Id);

            return Ok($"Student with Id = {id} deleted");
        }
    }
}