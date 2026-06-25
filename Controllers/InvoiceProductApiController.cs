using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureInventoryWebApiUsingToken.Models;

namespace SecureInventoryWebApiUsingToken.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoiceProductApiController : ControllerBase
    {

        InvoiceTokendbContext db;

        public InvoiceProductApiController()
        {
            this.db = new InvoiceTokendbContext();
        }

        [HttpGet]
        [Route("api/invoiceproduct")]
        public List<TblInvoiceProduct> GetAllInvoiceProduct()
        {
            return db.TblInvoiceProducts.ToList();
        }

        [HttpGet]
        [Route("api/invoiceproduct/{id}")]
        public TblInvoiceProduct GetInvoiceProductById(int id)
        {
            return db.TblInvoiceProducts.Find(id);
        }

        [HttpPost]
        [Route("api/invoiceproduct")]
        public TblInvoiceProduct AddInvoiceProduct(TblInvoiceProduct p)
        {
            db.TblInvoiceProducts.Add(p);
            db.SaveChanges();
            return p;
        }

        [HttpPut]
        [Route("api/invoiceproduct")]
        public TblInvoiceProduct UpdateInvoiceProduct(TblInvoiceProduct p)
        {
            db.TblInvoiceProducts.Update(p);
            db.SaveChanges();
            return p;
        }

        [HttpDelete]
        [Route("api/invoiceproduct/{id}")]
        public string DeleteInvoiceProduct(int id)
        {
            TblInvoiceProduct p = db.TblInvoiceProducts.Find(id);
            db.TblInvoiceProducts.Remove(p);
            db.SaveChanges();
            return "Invoice Product Deleted Successfully";
        }


    }
}
