using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public bool? EmailVerified { get; set; }

    public string? Avatar { get; set; }

    public string? RefreshToken { get; set; }

    public bool? IsDisabled { get; set; }

    public DateTime? LastLogin { get; set; }

    public int? HotelId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Hotel? Hotel { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
