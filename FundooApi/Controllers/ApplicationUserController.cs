using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Model;
using FundooBusiness.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundooApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserBusiness applicationUser;
        public ApplicationUserController(IApplicationUserBusiness applicationUser)
        {
            this.applicationUser = applicationUser;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(ApplicationUserModel applicationUserModel)
        {
            try
            {
                var result =await applicationUser.RegistrationAsync(applicationUserModel);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}