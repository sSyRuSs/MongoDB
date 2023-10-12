using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BCrypt.Net;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        //public static NhanVien NhanVien = new NhanVien();
        private IConfiguration _configuration;
        private readonly INhanVienRepos _nvRepos;
        public NhanVienController(INhanVienRepos _nvRepos, IConfiguration configuration)
        {
            this._nvRepos = _nvRepos;
            _configuration = configuration;
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
            string PasswordHash = BCrypt.Net.BCrypt.HashPassword(nv.Password);
            nv.Password = PasswordHash;
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

        [HttpPost("register")]
        public ActionResult<NhanVien> Register(NhanVien nhanVien)
        {
            string PasswordHash = BCrypt.Net.BCrypt.HashPassword(nhanVien.Password);
            nhanVien.Email = nhanVien.Email;
            nhanVien.Password = PasswordHash;
            _nvRepos.AddNV(nhanVien);
            return CreatedAtAction(nameof(GetAll), new { id = nhanVien.Id }, nhanVien);

        }

        [HttpPost("login")]
        public ActionResult<NhanVien> Login(NhanVien nhanVien)
        {
            var nv = _nvRepos.GetByEmail(nhanVien.Email);
            if (nv == null)
            {
                return BadRequest("User Not Found");
            }
            if (BCrypt.Net.BCrypt.EnhancedVerify(nhanVien.Password, nv.Password))
            {
                return BadRequest("Email or Password wrong");
            }
            return nv;
        }

        [HttpGet("GetAllByRole")]
        public ActionResult<List<NhanVien>> GetAllByRole(string role)
        {
            return _nvRepos.GetAllByRole(role);
        }
    }
}