using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureInventoryWebApiUsingToken.Models;

namespace SecureInventoryWebApiUsingToken.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoicePaymentApiController : ControllerBase
    {
        InvoiceTokendbContext db;

        public InvoicePaymentApiController()
        {
            this.db = new InvoiceTokendbContext();
        }

        [HttpGet]
        [Route("api/invoicepayment")]
        public List<TblInvoicePayment> GetAllInvoicePayments()
        {
            return db.TblInvoicePayments.ToList();
        }

        [HttpGet]
        [Route("api/invoicepayment/{id}")]
        public TblInvoicePayment GetInvoicePaymentById(int id)
        {
            return db.TblInvoicePayments.Find(id);
        }

        [HttpPost]
        [Route("api/invoicepayment")]
        public TblInvoicePayment AddInvoicePayment(TblInvoicePayment p)
        {
            db.TblInvoicePayments.Add(p);
            db.SaveChanges();
            return p;
        }

        [HttpPut]
        [Route("api/invoicepayment")]
        public TblInvoicePayment UpdateInvoicePayment(TblInvoicePayment p)
        {
            db.TblInvoicePayments.Update(p);
            db.SaveChanges();
            return p;
        }

        [HttpDelete]
        [Route("api/invoicepayment/{id}")]
        public string DeleteInvoicePayment(int id)
        {
            TblInvoicePayment p = db.TblInvoicePayments.Find(id);
            db.TblInvoicePayments.Remove(p);
            db.SaveChanges();
            return "Invoice Payment Deleted Successfully";
        }
    }
}
