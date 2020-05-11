using DydarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DydarShop.VeiwModels {
    public class CarsListViewModel {
        public IEnumerable<Car> AllCars { get; set; }

        public string CurrCategory { get; set; }
    }
}
