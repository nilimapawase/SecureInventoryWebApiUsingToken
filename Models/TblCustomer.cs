using System;
using System.Collections.Generic;

namespace SecureInventoryWebApiUsingToken.Models;

public partial class TblCustomer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? MobileNumber { get; set; }

    public string? City { get; set; }

    public virtual ICollection<TblInvoiceDetail> TblInvoiceDetails { get; set; } = new List<TblInvoiceDetail>();
}
