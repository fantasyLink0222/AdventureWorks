﻿using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class VGetAllCategory
{
    public string? ParentProductCategoryName { get; set; }

    public string? ProductCategoryName { get; set; }

    public long? ProductCategoryId { get; set; }
}
