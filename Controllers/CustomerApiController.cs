using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureInventoryWebApiUsingToken.Models;

namespace SecureInventoryWebApiUsingToken.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CustomerApiController : ControllerBase
    {
        InvoiceTokendbContext db;

        public CustomerApiController(InvoiceTokendbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("api/customer")]
        public List<TblCustomer> GetAll()
        {
            return db.TblCustomers.ToList();
        }

        [HttpGet]
        [Route("api/customer/{id}")]
        public TblCustomer GetById(int id)
        {
            return db.TblCustomers.Find(id);
        }

        [HttpPost]
        [Route("api/customer")]
        public void AddCustomer(TblCustomer customer)
        {
            db.TblCustomers.Add(customer);
            db.SaveChanges();
        }

        [HttpPut]
        [Route("api/customer")]
        public void UpdateCustomer(TblCustomer customer)
        {
            db.TblCustomers.Update(customer);
            db.SaveChanges();
        }

        [HttpDelete]
        [Route("api/customer/{id}")]
        public string DeleteCustomer(int id)
        {
            TblCustomer c = db.TblCustomers.Find(id);
            db.TblCustomers.Remove(c);
            db.SaveChanges();
            return "Customer Deleted Successfully";
        }
    }
}
