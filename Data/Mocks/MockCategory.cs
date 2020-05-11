using DydarShop.Data.Interfaces;
using DydarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DydarShop.Data.Moacks {
    public class MockCategory : ICarsCategory {
        public IEnumerable<Category> AllCategories {
            get {
                return new List<Category> {
                    new Category { CategoryName = "Электромобили", Desc= "Соверменный вид транспорта"},
                    new Category { CategoryName = "Классический автомобили", Desc= "Машины с двигателем внутреннего сгорания"}
                };
            }
        }
    }
}
