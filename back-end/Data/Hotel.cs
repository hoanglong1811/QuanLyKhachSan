using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Location { get; set; }

    public string? Description { get; set; }

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public int? Quantity { get; set; }

    public string Thumbnail { get; set; } = null!;

    public string Images { get; set; } = null!;

    public int? Floor { get; set; }

    public int Stars { get; set; }

    public string? CheckinTime { get; set; }

    public string? CheckoutTime { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<RoomType> RoomTypes { get; set; } = new List<RoomType>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<CategoryDetail> CategoryDetails { get; set; } = new List<CategoryDetail>();
}
