using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES.IService;

namespace LULLABY2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDeviceController : ControllerBase
    {
        private readonly IDeviceService _service;
        public AdminDeviceController(IDeviceService service)
        {
            _service = service;
        }

        [HttpGet("GetByUDID")]
        public ActionResult  GetByUDid(string id)
        {
            var result = _service.GetByUDID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(new { result });
        }
        [HttpGet("GetTotalTest")]
        public ActionResult Get_Total_Test()
        {
            var result = _service.GetTotalTest();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(new { result });
        }

        [HttpGet("GetLocationData")]
        public ActionResult GetLocationData()
        {
            var result = _service.GetLocationData();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(new { result });
        }
        [HttpGet("GetAll")]
        public ActionResult GetALL()
        {
            var get=_service.GetAll();
            return Ok(get);
        }
    }
}
