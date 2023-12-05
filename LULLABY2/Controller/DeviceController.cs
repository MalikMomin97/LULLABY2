using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES.DTO;
using SERVICES.Helper;
using SERVICES.IService;

namespace LULLABY2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _service;
        public DeviceController(IDeviceService service)
        {
            _service = service;
        }

        [HttpPost("Add_Device")]
        public ActionResult<AddDevice>create(AddDevice Add_device) 
        {
            if (Add_device.UDID==null)
            {

                return BadRequest(new ApiResponse<AddDevice> { Status = "error", Message = "UDId is null" });
            }

            if (Add_device.Location == null || Add_device.Location == "0")
            {
                return BadRequest(new ApiResponse<AddDevice> { Status = "error", Message = "Invalid Location" });
            }

            var result = _service.Create(Add_device);
            
            return Ok(new { result });

        }

        [HttpPost("Update_Device")]
        public ActionResult<UpdateDevice> Update(UpdateDevice Update_device)
        {
            var result =_service.Update(Update_device);
            if(result==null)
            {
                return NotFound();
            }
            var response = new ApiResponse<UpdateDevice>
            {
                Status = "Success",
                Message = "Updated Successfully"
            };
            return Ok(response);
        }

        
    }
}
