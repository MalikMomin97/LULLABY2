using Microsoft.AspNetCore.Mvc;
using SERVICES.DTO;
using SERVICES.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.IService
{
    public interface IDeviceService
    {
        public int Create(AddDevice Add_device);
        public UpdateDevice Update(UpdateDevice Up_device);
        public List<DeviceViewModel> GetAll();
        public List<DeviceViewModel> GetByUDID(string id);
        public TotalTestViewModel GetTotalTest();
        public IEnumerable<AllLocationViewModel> GetLocationData();
    }
}
