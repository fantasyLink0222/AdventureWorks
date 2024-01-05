using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class ProductCategory
{
    public long ProductCategoryId { get; set; }

    public long? ParentProductCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Rowguid { get; set; } = null!;

    public string ModifiedDate { get; set; } = null!;
}
