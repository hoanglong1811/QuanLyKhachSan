using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class BookingRoomType
{
    public int Id { get; set; }

    public int BookingId { get; set; }

    public int RoomTypeId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual RoomType RoomType { get; set; } = null!;
}
