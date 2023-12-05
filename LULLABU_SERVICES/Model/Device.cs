using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SERVICES.Enum.DeviceEnum;

namespace SERVICES.Model
{
    public class Device
    {
        public int Id { get; set; }
        public string UDID { get; set; }
        public long StartDateTime { get; set; }
        public string Location { get; set; }
        public DeviceEnumType DeviceType { get; set; }
        public long? EndDateTime { get; set; }
        
    }
}
