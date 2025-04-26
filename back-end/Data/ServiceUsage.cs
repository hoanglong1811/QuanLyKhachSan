using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class ServiceUsage
{
    public int Id { get; set; }

    public int BookingId { get; set; }

    public int ServiceId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime UsedAt { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
