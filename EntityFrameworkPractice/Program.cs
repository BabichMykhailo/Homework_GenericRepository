using FuneralHome.Controllers;
using FuneralHome.Data.Entities;
using FuneralHome.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctrl = new Repository();

            var x = new Employee() 
            {
                Id = 3,
                FirstName = "Mike",
                LastName = "Babich",
                MiddleName = "A",
                Phone = "+38099087588",
                PositionId = 1
            };
            //ctrl.Delete(1);
            var a = ctrl.GetById(3);
            ctrl.Update(x);
            var b = ctrl.GetById(3);
        }
    }
}
