using Microsoft.AspNetCore.Mvc;
using SERVICES.Data;
using SERVICES.DTO;
using SERVICES.Helper;
using SERVICES.IService;
using SERVICES.Model;
using SERVICES.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Service
{
    public class DeviceService : IDeviceService
    {
        private readonly LullabyDbContext _db;
        public DeviceService(LullabyDbContext db)
        {
            _db = db;
        }
        public int Create(AddDevice Add_device)
        {


            Device d = new Device
            {
                UDID = Add_device.UDID,
                StartDateTime = Add_device.StartDateTime,
                Location = Add_device.Location,
                DeviceType = Add_device.DeviceType,
            };

          var r=  _db.device.Add(d);
            _db.SaveChanges();
            return d.Id;
        }
        public UpdateDevice Update(UpdateDevice Up_device)
        {
            var ud = _db.device.Find(Up_device.Id);
            if (ud.Id != null)
            {
                ud.EndDateTime = Up_device.EndDateTime;
            }
            _db.SaveChanges();
            return (Up_device);
        }

        public List<DeviceViewModel> GetByUDID(string id)
        {
            var list = new List<DeviceViewModel>();

            var r =_db.device.Where(u=>u.UDID==id).ToList();
           
            if(r!=null)

            {
                foreach (var rx in r)
                {


                    DeviceViewModel d = new DeviceViewModel
                    {

                        UDID = rx.UDID,
                        StartDateTime = rx.StartDateTime,
                        Location = rx.Location,
                        DeviceType = rx.DeviceType,
                        EndDateTime = rx.EndDateTime,

                    };
                    list.Add(d);
                }
                return list;

            }

            return null;
        }

        public TotalTestViewModel GetTotalTest()
        {
            var allTest = _db.device.Where(u => u.Id != null).Count();

            var testcomp = _db.device.Where(u => u.StartDateTime != 0 && u.EndDateTime != null).Count();

            var lefttest = _db.device.Where(u => u.EndDateTime == null).Count();
            var ALL_USERS = _db.device.Where(u => u.DeviceType == Enum.DeviceEnum.DeviceEnumType.Android || u.DeviceType == Enum.DeviceEnum.DeviceEnumType.Ios).Count();

            var A_User = _db.device.Where(u => u.DeviceType == Enum.DeviceEnum.DeviceEnumType.Android).Count();
            var Ios_User = _db.device.Where(u => u.DeviceType == Enum.DeviceEnum.DeviceEnumType.Ios).Count();

            float And = (float)A_User / ALL_USERS * 100;
            float IOS = (float)Ios_User / ALL_USERS * 100;

            var result = new TotalTestViewModel
            {
                All_Test_Count = allTest,
                Test_Complete_Count = testcomp,
                Tests_Left_Count = lefttest,
                Android_User_Percentage = And,
                Ios_User_Percentage = IOS

            };
            return result;
        }

        public IEnumerable<AllLocationViewModel> GetLocationData()
        {
            var locationCounts = _db.device.GroupBy(u => u.Location).Select(group => new AllLocationViewModel
            {
                Location = group.Key,
                Count = group.Count()
            }).ToList();

            return (locationCounts);
        }

        public List<DeviceViewModel> GetAll()
        {
            
                var unique_UdIds = _db.device.Select(u => u.UDID).Distinct().ToList();

                var list = new List<DeviceViewModel>();

                foreach (var r in unique_UdIds)
                {

                    var result = _db.device.FirstOrDefault(u => u.UDID == r);

                   var Device = new DeviceViewModel
                    {

                        UDID = result.UDID,
                        StartDateTime = result.StartDateTime,
                        Location = result.Location,
                        DeviceType = result.DeviceType,
                        EndDateTime = result.EndDateTime,

                    };
                    list.Add(Device);
                }
                return list;

            
        }
    }
}
