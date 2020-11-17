using FuneralHomeCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Models.VeiwModels
{
    public class FuneralViewModel
    {
        public int Id { get; set; }
        public DateTime DateUtc { get; set; }
        public FuneralType Type { get; set; }

        public int ClientId { get; set; }
        public ClientViewModel Client { get; set; }

        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}
