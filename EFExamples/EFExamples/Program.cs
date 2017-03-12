using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExamples
{
    using CarShop.Models;
    using CarShop.Services.Repositories;

    class Program
    {
        static void Main(string[] args)
        {
            var service = new CarBrandsRepository();

            //var mercedes = new CarBrands { Id = Guid.NewGuid(), Brand = "Mercedes" };
            //service.Add(mercedes);

            //var bmw = new CarBrands { Id = Guid.NewGuid(), Brand = "BMW" };
            //service.Add(bmw);

            //var toyota = new CarBrands { Id = Guid.NewGuid(), Brand = "Toyota" };
            //service.Add(toyota);

            var brands = service.Find(c => c.Brand == "Toyota" || c.Brand == "BMW");
            var realResult = brands.ToList();

            Console.ReadLine();
        }
    }
}
