using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class Room
{
    public int Id { get; set; }

    public int RoomTypeId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public string? Thumbnail { get; set; }

    public string? Images { get; set; }

    public int? Floor { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual RoomType RoomType { get; set; } = null!;
}
