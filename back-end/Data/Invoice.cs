using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class Invoice
{
    public int Id { get; set; }

    public string? InvoiceCode { get; set; }

    public int BookingId { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal PaidAmount { get; set; }

    public decimal DueAmount { get; set; }

    public decimal? ExcessAmount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
