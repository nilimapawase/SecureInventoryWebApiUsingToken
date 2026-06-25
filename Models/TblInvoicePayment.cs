using System;
using System.Collections.Generic;

namespace SecureInventoryWebApiUsingToken.Models;

public partial class TblInvoicePayment
{
    public int PaymentId { get; set; }

    public int? InvoiceId { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public double? PaymentAmount { get; set; }

    public string? PaymentMode { get; set; }

    public string? Description { get; set; }

    public virtual TblInvoiceDetail? Invoice { get; set; }
}
