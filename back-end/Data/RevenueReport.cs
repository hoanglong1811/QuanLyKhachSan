using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class RevenueReport
{
    public int Id { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public decimal TotalRevenue { get; set; }

    public int TotalBookings { get; set; }

    public int TotalServicesUsed { get; set; }

    public DateTime? CreatedAt { get; set; }
}
