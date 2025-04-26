using back_end.ViewModels;
using System.Threading.Tasks;

namespace back_end.Services
{
    public interface IAuthService
    {
        Task<UserViewModel?> AuthenticateAsync(string email, string password);
        Task<RegisterResult> RegisterAsync(UserViewModel userViewModel);
    }

    public class RegisterResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}