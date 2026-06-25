using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureInventoryWebApiUsingToken.Models;

namespace SecureInventoryWebApiUsingToken.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductApiController : ControllerBase
    {
        InvoiceTokendbContext db;

        public ProductApiController() 
        {
            this.db = new InvoiceTokendbContext();
        }

        [HttpGet]
        [Route("api/product")]
        public List<TblProduct> GetAllProducts()
        {
            return db.TblProducts.ToList();
        }

        [HttpGet]
        [Route("api/product/{id}")]
        public TblProduct GetProductById(int id)
        {
            return db.TblProducts.Find(id);
        }

        [HttpPost]
        [Route("api/product")]
        public TblProduct AddProduct(TblProduct p)
        {
            db.TblProducts.Add(p);
            db.SaveChanges();
            return p;
        }

        [HttpPut]
        [Route("api/product")]
        public TblProduct UpdateProduct(TblProduct p)
        {
            db.TblProducts.Update(p);
            db.SaveChanges();
            return p;
        }

        [HttpDelete]
        [Route("api/product/{id}")]
        public string DeleteProduct(int id)
        {
            TblProduct p = db.TblProducts.Find(id);
            db.TblProducts.Remove(p);
            db.SaveChanges();
            return "Product Deleted Successfully";
        }
    }
}
