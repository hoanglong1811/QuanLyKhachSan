using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Data;
using back_end.ViewModels;
using back_end.Services;
using System.Security.Cryptography;
using System.Text;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanRepository _taiKhoanRepository;

        public TaiKhoanController(ITaiKhoanRepository taiKhoanRepository)
        {
            _taiKhoanRepository = taiKhoanRepository;
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
                return NotFound();

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
                return NotFound();

            return NoContent();
        }

        // DELETE: api/TaiKhoan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaiKhoan(int id)
        {
            if (!await _taiKhoanRepository.DeleteAsync(id))
                return NotFound();

            return NoContent();
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}