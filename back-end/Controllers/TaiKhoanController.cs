using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Data;
using back_end.ViewModels;
using back_end.Services; // Thêm dòng này
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
                MatKhau = tk.MatKhau,
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
            // Mã hóa mật khẩu trước khi lưu
            string hashedPassword = "";
            if (!string.IsNullOrEmpty(addTaiKhoan.MatKhau))
            {
                using (var sha256 = SHA256.Create())
                {
                    var bytes = Encoding.UTF8.GetBytes(addTaiKhoan.MatKhau);
                    var hash = sha256.ComputeHash(bytes);
                    hashedPassword = BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
            }

            var taiKhoan = new TaiKhoan
            {
                TenDangNhap = addTaiKhoan.TenDangNhap,
                Email = addTaiKhoan.Email,
                IdVaiTro = 2, // Gắn mặc định
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


        // ...existing code...

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaiKhoan(int id, [FromBody] UpdateTaiKhoan taiKhoanVM)
        {
            if (id != taiKhoanVM.IdTaiKhoan)
                return BadRequest();

            // Lấy tài khoản hiện tại từ DB
            var existingTaiKhoan = await _taiKhoanRepository.GetByIdAsync(id);
            if (existingTaiKhoan == null)
                return NotFound();

            // Cập nhật các trường cần thiết
            if (!string.IsNullOrEmpty(taiKhoanVM.TenDangNhap))
                existingTaiKhoan.TenDangNhap = taiKhoanVM.TenDangNhap;
            if (!string.IsNullOrEmpty(taiKhoanVM.Email))
                existingTaiKhoan.Email = taiKhoanVM.Email;

            // Nếu muốn cập nhật mật khẩu, hãy mã hóa lại:
            if (!string.IsNullOrEmpty(taiKhoanVM.MatKhau))
            {
                using (var sha256 = SHA256.Create())
                {
                    var bytes = Encoding.UTF8.GetBytes(taiKhoanVM.MatKhau);
                    var hash = sha256.ComputeHash(bytes);
                    existingTaiKhoan.MatKhau = BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
            }

            var updated = await _taiKhoanRepository.UpdateAsync(existingTaiKhoan);
            if (!updated)
                return NotFound();

            return NoContent();
        }
        // ...existing code...
        // DELETE: api/TaiKhoan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaiKhoan(int id)
        {
            var deleted = await _taiKhoanRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }



        // POST: api/TaiKhoan/login
        [HttpPost("login")]
        public async Task<ActionResult<TaiKhoanVM>> Login([FromBody] LoginModel loginInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(loginInfo.TenDangNhap) || string.IsNullOrEmpty(loginInfo.MatKhau))
            {
                return BadRequest("Tên đăng nhập và mật khẩu không được để trống");
            }

            // Mã hóa mật khẩu nhập vào để so sánh
            string hashedPassword;
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(loginInfo.MatKhau);
                var hash = sha256.ComputeHash(bytes);
                hashedPassword = BitConverter.ToString(hash).Replace("-", "").ToLower();
            }

            // Tìm tài khoản theo tên đăng nhập
            var taiKhoan = (await _taiKhoanRepository.GetAllAsync())
                .FirstOrDefault(t => t.TenDangNhap.ToLower() == loginInfo.TenDangNhap.ToLower());

            if (taiKhoan == null)
            {
                return NotFound("Tài khoản không tồn tại");
            }

            // Kiểm tra mật khẩu
            if (taiKhoan.MatKhau != hashedPassword)
            {
                return Unauthorized("Mật khẩu không chính xác");
            }

            var result = new TaiKhoanVM
            {
                IdTaiKhoan = taiKhoan.IdTaiKhoan,
                TenDangNhap = taiKhoan.TenDangNhap,
                Email = taiKhoan.Email,
                IdVaiTro = taiKhoan.IdVaiTro,
                TenVaiTro = taiKhoan.IdVaiTroNavigation?.TenVaiTro
            };

            return Ok(result);
        }
        // ...existing code...
    }
}