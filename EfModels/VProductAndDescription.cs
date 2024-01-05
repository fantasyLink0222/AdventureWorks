﻿using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class VProductAndDescription
{
    public long? ProductId { get; set; }

    public string? Name { get; set; }

    public string? ProductModel { get; set; }

    public string? Culture { get; set; }

    public string? Description { get; set; }
}
