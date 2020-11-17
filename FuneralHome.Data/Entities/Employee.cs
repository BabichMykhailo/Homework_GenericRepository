using FuneralHome.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuneralHome.Data.Entities
{
    public class Employee : IEntity<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public int PositionId { get; set; }

        public ICollection<Funeral> Funerals { get; set; }
    }
}
