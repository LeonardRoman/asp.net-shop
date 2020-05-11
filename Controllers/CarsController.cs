using DydarShop.Data.Interfaces;
using DydarShop.Data.Models;
using DydarShop.VeiwModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DydarShop.Controllers {
    public class CarsController : Controller {

        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategrorys;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat) {
            _allCars = iAllCars;
            _allCategrorys = iCarsCat;

        }
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category) {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category)) {
                cars = _allCars.Cars.OrderBy(i => i.Id);
            }
            else {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase)) {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Электромобили")).OrderBy(i => i.Id);
                    currCategory = "Электрический двигатель";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase)) {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Классический автомобили")).OrderBy(i => i.Id);
                    currCategory ="Двигатель внутреннего сгорания";
                }

            }

            var carObj = new CarsListViewModel {
                AllCars = cars,
                CurrCategory = currCategory
            };
            ViewBag.Title = "Автомобилями";
            //ViewBag.Category = "Some New";
            //var cars = _allCars.Cars;
            //return View(cars);
            return View(carObj);
        }

    }
}
