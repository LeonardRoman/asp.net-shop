using DydarShop.Data.Interfaces;
using DydarShop.Data.Moacks;
using DydarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DydarShop.Data.Mocks {
    public class MockCars : IAllCars {

        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars {
            get {
                return new List<Car> {
                    new Car {
                        Name = "Tesla",
                        ShortDesc = "Быстрый",
                        LongDesc = "Красивый и очень тихий",
                        Img = "/img/tesla.jpg",
                        Price = 45000,
                        IsFavorite = true,
                        Avalible = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car {
                        Name = "Ford Fiesta",
                        ShortDesc = "Тихий и спокойный",
                        LongDesc = "Удобный для городской жизни",
                        Img = "/img/ford-fiesta-ru.webp",
                        Price = 11000,
                        IsFavorite = false,
                        Avalible = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        Name = "BMW M3",
                        ShortDesc = "Дерзкий и стильный",
                        LongDesc = "Удобный для городской жизни",
                        Img = "/img/bmw-m3.jpg",
                        Price = 11000,
                        IsFavorite = false,
                        Avalible = true,
                        Category = _categoryCars.AllCategories.Last()
                    },

                };
            }
            set {
                throw new NotImplementedException();
            }
        }
        public IEnumerable<Car> GetFavCars { get; set; }

        public Car GetObjectCar(int carId) {
            throw new NotImplementedException();
        }
    }
}
