using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVICES.AccountViewModel;
using SERVICES.DTO;
using SERVICES.Helper;
using SERVICES.IService;

namespace LULLABY2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _Service;
        public AccountController(IAccountService Service)
        {
            _Service = Service;
        }
        [Authorize(Roles =UserRoles.Admin)]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            var result = await _Service.Registerr(model);
            if (result != null)
            {
                //var response = new ApiResponse<Register>
                //{
                //    Status = "Success",
                //    Message = "Created Successfully"
                //};
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<ActionResult>Login(loginModel model)
        {
            var result=await _Service.login(model);
            return Ok(result);
        }

    }
}
