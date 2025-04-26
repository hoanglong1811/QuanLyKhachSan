using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class Review
{
    public int Id { get; set; }

    public int BookingId { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
