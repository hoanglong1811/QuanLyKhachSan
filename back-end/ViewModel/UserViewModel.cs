using System;
using System.ComponentModel.DataAnnotations;

namespace back_end.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        public string? PasswordHash { get; set; } // Optional for updates, required for creation

        [StringLength(255)]
        public string? PhoneNumber { get; set; }

        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }

        public bool? EmailVerified { get; set; }

        [StringLength(255)]
        public string? Avatar { get; set; }

        public bool? IsDisabled { get; set; }

        public DateTime? LastLogin { get; set; }

        public int? HotelId { get; set; }

        [Required]
        public int RoleId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}