using System;
using System.Collections.Generic;

namespace back_end.Data;

public partial class Category
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string Name { get; set; } = null!;

    public string? Icon { get; set; }

    public virtual ICollection<CategoryDetail> CategoryDetails { get; set; } = new List<CategoryDetail>();

    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    public virtual Category? Parent { get; set; }
}
