using Microsoft.AspNetCore.Mvc;
using SERVICES.AccountViewModel;
using SERVICES.DTO;

namespace SERVICES.IService
{
    public interface IAccountService
    {
        public  Task<bool> Registerr([FromBody]Register model);
        public Task<ActionResult> login(loginModel model);
    }
}
