using CoreApisWithJWT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SecureInventoryWebApiUsingToken.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecureInventoryWebApiUsingToken.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        InvoiceTokendbContext _context;

        private readonly IConfiguration _configuration;
        public EmployeeApiController(IConfiguration configuration)
        {
            _context = new InvoiceTokendbContext();
            _configuration = configuration;
        }

        [HttpPost]
        [Route("api/login")]
        public IActionResult Login(EmployeeLoginModel employee)
        {
            TblEmployee emp = _context.TblEmployees.ToList().FirstOrDefault(e => e.EmployeeCode.Equals(employee.EmployeeCode) & e.Password.Equals(employee.Password));
            if (emp != null)
            {
                var authclaims = new List<Claim>()
             {
                 new Claim(ClaimTypes.Name,emp.EmployeeCode),
                 new Claim(ClaimTypes.Email,emp.EmailAddress)


         };
                var token = GetToken(authclaims);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [NonAction]

        public JwtSecurityToken GetToken(List<Claim> authclaims)
        {
            var authsignkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                 audience: _configuration["JWT:ValidAudience"],
                 expires: DateTime.Now.AddHours(3),
                 claims: authclaims,
                 signingCredentials: new SigningCredentials(authsignkey, SecurityAlgorithms.HmacSha256)

                );
            return token;
        }
    }
}
