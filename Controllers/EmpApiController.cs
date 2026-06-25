using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureInventoryWebApiUsingToken.Models;
using Microsoft.AspNetCore.Authorization;

namespace SecureInventoryWebApiUsingToken.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmpApiController : ControllerBase
    {
        InvoiceTokendbContext db;

        public EmpApiController(InvoiceTokendbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("api/employee")]
        public List<TblEmployee> GetAll()
        {
            return db.TblEmployees.ToList();
        }

        [HttpGet]
        [Route("api/employee/{id}")]
        public TblEmployee GetById(int id)
        {
            return db.TblEmployees.Find(id);
        }

        [HttpPost]
        [Route("api/employee")]
        public void AddEmployee(TblEmployee emp)
        {
            db.TblEmployees.Add(emp);
            db.SaveChanges();
        }

        [HttpPut]
        [Route("api/employee")]
        public void UpdateEmployee(TblEmployee emp)
        {
            db.TblEmployees.Update(emp);
            db.SaveChanges();
        }

        [HttpDelete]
        [Route("api/employee/{id}")]
        public string DeleteEmployee(int id)
        {
            TblEmployee e = db.TblEmployees.Find(id);
            db.TblEmployees.Remove(e);
            db.SaveChanges();
            return "Employee Deleted Successfully";
        }
    }
}
