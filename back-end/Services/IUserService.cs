using back_end.Data;
using back_end.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;

namespace back_end.Services
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAllUsersAsync();
        Task<UserViewModel> GetUserByIdAsync(int id);
        Task<UserViewModel> CreateUserAsync(UserViewModel userViewModel);
        Task<bool> UpdateUserAsync(int id, UserViewModel userViewModel);
        Task<bool> DeleteUserAsync(int id);
    }
    public class UserService : IUserService
    {
        private readonly LtbackendLocalContext _context;

        public UserService(LtbackendLocalContext context)
        {
            _context = context;
        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            return await _context.Users
            .Select(u => new UserViewModel
            {
                Id = u.Id,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                FirstName = u.FirstName,
                LastName = u.LastName,
                EmailVerified = u.EmailVerified,
                Avatar = u.Avatar,
                IsDisabled = u.IsDisabled,
                LastLogin = u.LastLogin,
                HotelId = u.HotelId,
                RoleId = u.RoleId,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt
            })
            .ToListAsync();
        }

        public async Task<UserViewModel> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
            .Where(u => u.Id == id)
            .Select(u => new UserViewModel
            {
                Id = u.Id,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                FirstName = u.FirstName,
                LastName = u.LastName,
                EmailVerified = u.EmailVerified,
                Avatar = u.Avatar,
                IsDisabled = u.IsDisabled,
                LastLogin = u.LastLogin,
                HotelId = u.HotelId,
                RoleId = u.RoleId,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt
            })
            .FirstOrDefaultAsync();

            return user;
        }

        public async Task<UserViewModel> CreateUserAsync(UserViewModel userViewModel)
        {
            var user = new User
            {
                Email = userViewModel.Email,
                PasswordHash = userViewModel.PasswordHash ?? BCrypt.Net.BCrypt.HashPassword("defaultPassword"), // Replace with proper password hashing
                PhoneNumber = userViewModel.PhoneNumber,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                EmailVerified = userViewModel.EmailVerified,
                Avatar = userViewModel.Avatar,
                IsDisabled = userViewModel.IsDisabled,
                LastLogin = userViewModel.LastLogin,
                HotelId = userViewModel.HotelId,
                RoleId = userViewModel.RoleId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            userViewModel.Id = user.Id;
            userViewModel.CreatedAt = user.CreatedAt;
            userViewModel.UpdatedAt = user.UpdatedAt;
            return userViewModel;
        }

        public async Task<bool> UpdateUserAsync(int id, UserViewModel userViewModel)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            user.Email = userViewModel.Email;
            user.PhoneNumber = userViewModel.PhoneNumber;
            user.FirstName = userViewModel.FirstName;
            user.LastName = userViewModel.LastName;
            user.EmailVerified = userViewModel.EmailVerified;
            user.Avatar = userViewModel.Avatar;
            user.IsDisabled = userViewModel.IsDisabled;
            user.LastLogin = userViewModel.LastLogin;
            user.HotelId = userViewModel.HotelId;
            user.RoleId = userViewModel.RoleId;
            user.UpdatedAt = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(userViewModel.PasswordHash))
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userViewModel.PasswordHash); // Replace with proper password hashing
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            user.IsDisabled = true; // Soft delete by disabling
            await _context.SaveChangesAsync();
            return true;
        }
    }

}