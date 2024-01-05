using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class CustomerAddress
{
    public long CustomerId { get; set; }

    public long AddressId { get; set; }

    public string AddressType { get; set; } = null!;

    public string Rowguid { get; set; } = null!;

    public string ModifiedDate { get; set; } = null!;
}
