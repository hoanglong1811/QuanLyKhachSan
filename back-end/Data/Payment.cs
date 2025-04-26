using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class Payment
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? PaymentDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int InvoiceId { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;
}
