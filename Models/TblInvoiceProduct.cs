using System;
using System.Collections.Generic;

namespace SecureInventoryWebApiUsingToken.Models;

public partial class TblInvoiceProduct
{
    public int InvoiceProductId { get; set; }

    public int? InvoiceId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual TblInvoiceDetail? Invoice { get; set; }

    public virtual TblProduct? Product { get; set; }
}
