using System;
using System.Collections.Generic;

namespace SecureInventoryWebApiUsingToken.Models;

public partial class TblInvoiceDetail
{
    public int InvoiceId { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly? InvoiceDate { get; set; }

    public double? TotalAmount { get; set; }

    public string? Status { get; set; }

    public virtual TblCustomer? Customer { get; set; }

    public virtual ICollection<TblInvoicePayment> TblInvoicePayments { get; set; } = new List<TblInvoicePayment>();

    public virtual ICollection<TblInvoiceProduct> TblInvoiceProducts { get; set; } = new List<TblInvoiceProduct>();
}
