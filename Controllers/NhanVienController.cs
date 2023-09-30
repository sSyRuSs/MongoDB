using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienRepos _nvRepos;
        public NhanVienController(INhanVienRepos _nvRepos)
        {
            this._nvRepos = _nvRepos;
        }

        [HttpGet]
        public ActionResult<List<NhanVien>> GetAll()
        {
            return _nvRepos.GetAllNV();
        }
        [HttpGet("{id}")]
        public ActionResult<NhanVien> GetNhanVienById(string id)
        {
            var nv = _nvRepos.Get(id);
            if (nv == null)
            {
                return NotFound();
            }
            return nv;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<NhanVien> Post([FromBody] NhanVien nv)
        {
            _nvRepos.AddNV(nv);

            return CreatedAtAction(nameof(GetAll), new { id = nv.Id }, nv);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] NhanVien nv)
        {
            var Nv = _nvRepos.Get(id);

            if (Nv == null)
            {
                return NotFound($"Nhan vien with Id = {id} not found");
            }

            _nvRepos.Update(id, nv);

            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var nv = _nvRepos.Get(id);

            if (nv == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            _nvRepos.Remove(nv.EmployeeID);

            return Ok($"Student with Id = {id} deleted");
        }
    }
}