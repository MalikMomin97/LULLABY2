using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.ViewModel
{
    public class TotalTestViewModel
    {
        public int All_Test_Count { get; set; }
        public int Test_Complete_Count { get; set; }
        public int Tests_Left_Count { get; set; }
        public float Android_User_Percentage { get; set; }
        public float Ios_User_Percentage { get; set; }
    }
}
