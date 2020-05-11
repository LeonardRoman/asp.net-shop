using DydarShop.Data.Interfaces;
using DydarShop.VeiwModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DydarShop.Controllers {
    public class HomeController : Controller {
        private readonly IAllCars _carRep;


        public HomeController(IAllCars carRep) {
            _carRep = carRep;
        }

        public ViewResult Index() {
            var homeCars = new HomeViewModel {
                FavCars = _carRep.GetFavCars
            };

            return View(homeCars);
        }
    }
}
