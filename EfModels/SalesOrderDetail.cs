using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class SalesOrderDetail
{
    public long SalesOrderId { get; set; }

    public long SalesOrderDetailId { get; set; }

    public long OrderQty { get; set; }

    public long ProductId { get; set; }

    public double UnitPrice { get; set; }

    public double UnitPriceDiscount { get; set; }

    public string Rowguid { get; set; } = null!;

    public string ModifiedDate { get; set; } = null!;
}
