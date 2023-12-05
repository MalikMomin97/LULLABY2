using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SERVICES.Enum.DeviceEnum;

namespace SERVICES.DTO
{
    public class UpdateDevice
    {
        public int Id { get; set; }
        public long EndDateTime { get; set; }
    }
}
