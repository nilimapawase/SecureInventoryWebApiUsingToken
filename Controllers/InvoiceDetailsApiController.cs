using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureInventoryWebApiUsingToken.Models;

namespace SecureInventoryWebApiUsingToken.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoiceDetailsApiController : ControllerBase
    {
        InvoiceTokendbContext db;

        public InvoiceDetailsApiController()
        {
            this.db = new InvoiceTokendbContext();
        }

        [HttpGet]
        [Route("api/invoicedetail")]
        public List<TblInvoiceDetail> GetAllInvoiceDeatils()
        {
            return db.TblInvoiceDetails.ToList();
        }

        [HttpGet]
        [Route("api/invoicedetail/{id}")]
        public TblInvoiceDetail GetInvoiceDetailById(int id)
        {
            return db.TblInvoiceDetails.Find(id);
        }

        [HttpPost]
        [Route("api/invoicedetail")]
        public TblInvoiceDetail AddInvoiceDetail(TblInvoiceDetail p)
        {
            db.TblInvoiceDetails.Add(p);
            db.SaveChanges();
            return p;
        }

        [HttpPut]
        [Route("api/invoicedetail")]
        public TblInvoiceDetail UpdateInvoiceDetail(TblInvoiceDetail p)
        {
            db.TblInvoiceDetails.Update(p);
            db.SaveChanges();
            return p;
        }

        [HttpDelete]
        [Route("api/invoicedetail/{id}")]
        public string DeleteInvoiceDetail(int id)
        {
            TblInvoiceDetail p = db.TblInvoiceDetails.Find(id);
            db.TblInvoiceDetails.Remove(p);
            db.SaveChanges();
            return "Invoice Detail Deleted Successfully";
        }
    }
}
