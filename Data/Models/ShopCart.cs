using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DydarShop.Data.Models {
    public class ShopCart {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent) {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> LIstShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider service) {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) {
                ShopCartId = shopCartId
            };
        }

        public void AddToCart(Car car) {
            appDBContent.ShopCartItem.Add(new ShopCartItem {
                ShopCartId = ShopCartId,
                Car = car,
                Price = car.Price
            });

            appDBContent.SaveChanges();
        }
        public List<ShopCartItem> getShopItems() {
            return appDBContent.ShopCartItem.Where(i => i.ShopCartId == ShopCartId).Include(s => s.Car).ToList();
        }
    }
}
