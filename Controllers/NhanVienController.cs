using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BCrypt.Net;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        //public static NhanVien NhanVien = new NhanVien();
        private readonly IConfiguration _configuration;
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
            string PasswordHash = BCrypt.Net.BCrypt.HashPassword(nv.Password);
            nv.Password = PasswordHash;
            _nvRepos.Update(id, nv);

            return CreatedAtAction(nameof(GetAll), new { id = nv.Id }, nv);
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
            if (!BCrypt.Net.BCrypt.Verify(nhanVien.Password, nv.Password))
            {
                return BadRequest("Email or Password wrong");
            }
            string token = CreateToken(nhanVien);

            return Ok(token);
            
        }

        private string CreateToken(NhanVien nhanVien)
        {
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.Name, nhanVien.Email ),
                new Claim(ClaimTypes.Role, nhanVien.Role.RoleName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
            }
        

        [HttpGet("GetAllByRole")]
        public ActionResult<List<NhanVien>> GetAllByRole(string role)
        {
            return _nvRepos.GetAllByRole(role); 
        }


    }
}