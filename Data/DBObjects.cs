using DydarShop.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DydarShop.Data {
    public class DBObjects {
        public static void Initial(AppDBContent content) {

            if (!content.Category.Any()) {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any()) {
                content.Car.AddRange(
                    new Car {
                        Name = "Tesla",
                        ShortDesc = "Быстрый",
                        LongDesc = "Красивый и очень тихий",
                        Img = "/img/tesla.jpg",
                        Price = 45000,
                        IsFavorite = true,
                        Avalible = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car {
                        Name = "Ford Fiesta",
                        ShortDesc = "Тихий и спокойный",
                        LongDesc = "Удобный для городской жизни",
                        Img = "/img/ford-fiesta-ru.webp",
                        Price = 11000,
                        IsFavorite = false,
                        Avalible = true,
                        Category = Categories["Классический автомобили"]
                    },
                    new Car {
                        Name = "BMW M3",
                        ShortDesc = "Дерзкий и стильный",
                        LongDesc = "Удобный для городской жизни",
                        Img = "/img/bmw-m3.jpg",
                        Price = 11000,
                        IsFavorite = false,
                        Avalible = true,
                        Category = Categories["Классический автомобили"]
                    }
                );
            }

            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories {
            get {
                if (category == null) {
                    var list = new Category[] {
                        new Category { CategoryName = "Электромобили", Desc= "Соверменный вид транспорта"},
                        new Category { CategoryName = "Классический автомобили", Desc= "Машины с двигателем внутреннего сгорания"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.CategoryName, el);
                }
                return category;
            }
        }
    }
}
