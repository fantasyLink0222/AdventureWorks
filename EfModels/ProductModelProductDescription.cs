using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class ProductModelProductDescription
{
    public long ProductModelId { get; set; }

    public long ProductDescriptionId { get; set; }

    public string Culture { get; set; } = null!;

    public string Rowguid { get; set; } = null!;

    public string ModifiedDate { get; set; } = null!;
}
