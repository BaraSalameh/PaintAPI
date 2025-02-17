using Application.Account.Queries.LoginQueries;
using Microsoft.AspNetCore.Mvc;
using PaintAPIs.Controllers;

namespace Supper.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] LoginQuery request) => Ok(await Mediator.Send(request));
    }
}
