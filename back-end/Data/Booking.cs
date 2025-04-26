using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class Booking
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? BookingCode { get; set; }

    public byte? Children { get; set; }

    public byte? Adults { get; set; }

    public string? Notes { get; set; }

    public int? RoomCount { get; set; }

    public string? ArrivalTime { get; set; }

    public DateTime CheckInDate { get; set; }

    public DateTime CheckOutDate { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public decimal TotalPrice { get; set; }

    public decimal BasePrice { get; set; }

    public virtual ICollection<BookingRoomType> BookingRoomTypes { get; set; } = new List<BookingRoomType>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<ServiceUsage> ServiceUsages { get; set; } = new List<ServiceUsage>();

    public virtual User? User { get; set; }
}
