using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Data;
using back_end.ViewModels;
using back_end.Services;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanRepository _taiKhoanRepository;
        private readonly IVaiTroRepository _vaiTroRepository;
        private readonly IConfiguration _configuration;

        public TaiKhoanController(ITaiKhoanRepository taiKhoanRepository, IVaiTroRepository vaiTroRepository, IConfiguration configuration)
        {
            _taiKhoanRepository = taiKhoanRepository;
            _vaiTroRepository = vaiTroRepository;
            _configuration = configuration;
        }

        // GET: api/TaiKhoan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiKhoanVM>>> GetTaiKhoans()
        {
            var taiKhoans = await _taiKhoanRepository.GetAllAsync();
            var result = taiKhoans.Select(tk => new TaiKhoanVM
            {
                IdTaiKhoan = tk.IdTaiKhoan,
                TenDangNhap = tk.TenDangNhap,
                Email = tk.Email,
                IdVaiTro = tk.IdVaiTro,
                TenVaiTro = tk.IdVaiTroNavigation?.TenVaiTro
            }).ToList();

            return Ok(result);
        }

        // GET: api/TaiKhoan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiKhoanVM>> GetTaiKhoan(int id)
        {
            var tk = await _taiKhoanRepository.GetByIdAsync(id);
            if (tk == null)
                return NotFound(new { message = $"Không tìm thấy tài khoản với ID: {id}" });

            var result = new TaiKhoanVM
            {
                IdTaiKhoan = tk.IdTaiKhoan,
                TenDangNhap = tk.TenDangNhap,
                Email = tk.Email,
                IdVaiTro = tk.IdVaiTro,
                TenVaiTro = tk.IdVaiTroNavigation?.TenVaiTro
            };
            return Ok(result);
        }

        // POST: api/TaiKhoan
        [HttpPost]
        public async Task<ActionResult<TaiKhoanVM>> PostTaiKhoan([FromBody] AddTaiKhoan addTaiKhoan)
        {
            // Kiểm tra tính duy nhất của tên đăng nhập và email
            if (!await _taiKhoanRepository.IsUsernameUniqueAsync(addTaiKhoan.TenDangNhap))
                return BadRequest(new { message = "Tên đăng nhập đã tồn tại" });

            if (!await _taiKhoanRepository.IsEmailUniqueAsync(addTaiKhoan.Email))
                return BadRequest(new { message = "Email đã tồn tại" });

            // Mã hóa mật khẩu
            string hashedPassword = HashPassword(addTaiKhoan.MatKhau);

            var taiKhoan = new TaiKhoan
            {
                TenDangNhap = addTaiKhoan.TenDangNhap,
                Email = addTaiKhoan.Email,
                IdVaiTro = 2, // Gắn mặc định là vai trò người dùng
                MatKhau = hashedPassword
            };

            var tk = await _taiKhoanRepository.AddAsync(taiKhoan);

            var result = new TaiKhoanVM
            {
                IdTaiKhoan = tk.IdTaiKhoan,
                TenDangNhap = tk.TenDangNhap,
                Email = tk.Email,
                IdVaiTro = tk.IdVaiTro,
                TenVaiTro = tk.IdVaiTroNavigation?.TenVaiTro
            };

            return CreatedAtAction(nameof(GetTaiKhoan), new { id = tk.IdTaiKhoan }, result);
        }

        // PUT: api/TaiKhoan/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaiKhoan(int id, [FromBody] UpdateTaiKhoan updateModel)
        {
            var existingTaiKhoan = await _taiKhoanRepository.GetByIdAsync(id);
            if (existingTaiKhoan == null)
                return NotFound();

            // Kiểm tra tính duy nhất của tên đăng nhập và email nếu được cập nhật
            if (!string.IsNullOrEmpty(updateModel.TenDangNhap) && 
                updateModel.TenDangNhap != existingTaiKhoan.TenDangNhap)
            {
                if (!await _taiKhoanRepository.IsUsernameUniqueAsync(updateModel.TenDangNhap, id))
                    return BadRequest(new { message = "Tên đăng nhập đã tồn tại" });
                existingTaiKhoan.TenDangNhap = updateModel.TenDangNhap;
            }

            if (!string.IsNullOrEmpty(updateModel.Email) && 
                updateModel.Email != existingTaiKhoan.Email)
            {
                if (!await _taiKhoanRepository.IsEmailUniqueAsync(updateModel.Email, id))
                    return BadRequest(new { message = "Email đã tồn tại" });
                existingTaiKhoan.Email = updateModel.Email;
            }

            // Cập nhật mật khẩu nếu được cung cấp
            if (!string.IsNullOrEmpty(updateModel.MatKhau))
            {
                existingTaiKhoan.MatKhau = HashPassword(updateModel.MatKhau);
            }

            if (!await _taiKhoanRepository.UpdateAsync(existingTaiKhoan))
                return NotFound($"Không tìm thấy tài khoản với ID: {id}");

            return Ok($"Cập nhật tài khoản thành công");
        }

        // DELETE: api/TaiKhoan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaiKhoan(int id)
        {
            if (!await _taiKhoanRepository.DeleteAsync(id))
                return NotFound($"Không tìm thấy tài khoản với ID: {id}");

            return Ok($"Xóa tài khoản thành công");
        }

        // POST: api/TaiKhoan/login
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginModel loginModel)
        {
            if (string.IsNullOrEmpty(loginModel.TenDangNhap) || string.IsNullOrEmpty(loginModel.MatKhau))
            {
                return BadRequest(new { message = "Tên đăng nhập và mật khẩu không được để trống" });
            }

            var hashedPassword = HashPassword(loginModel.MatKhau);
            var taiKhoan = await _taiKhoanRepository.GetByUsernameAndPasswordAsync(loginModel.TenDangNhap, hashedPassword);

            if (taiKhoan == null)
            {
                return Unauthorized(new { message = "Tên đăng nhập hoặc mật khẩu không đúng" });
            }

            var response = new LoginResponse
            {
                IdTaiKhoan = taiKhoan.IdTaiKhoan,
                TenDangNhap = taiKhoan.TenDangNhap ?? string.Empty,
                Email = taiKhoan.Email ?? string.Empty,
                IdVaiTro = taiKhoan.IdVaiTro,
                TenVaiTro = taiKhoan.IdVaiTroNavigation?.TenVaiTro ?? string.Empty,
                Token = GenerateJwtToken(taiKhoan)
            };

            return Ok(response);
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        private string GenerateJwtToken(TaiKhoan taiKhoan)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, taiKhoan.IdTaiKhoan.ToString()),
                new Claim(ClaimTypes.Name, taiKhoan.TenDangNhap ?? string.Empty),
                new Claim(ClaimTypes.Email, taiKhoan.Email ?? string.Empty),
                new Claim(ClaimTypes.Role, taiKhoan.IdVaiTro.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}