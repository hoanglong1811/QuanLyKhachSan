using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class CategoryDetail
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Icon { get; set; }

    public string? Description { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual ICollection<RoomType> RoomTypes { get; set; } = new List<RoomType>();
}
