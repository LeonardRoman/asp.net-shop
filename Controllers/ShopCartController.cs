using DydarShop.Data.Interfaces;
using DydarShop.Data.Models;
using DydarShop.Data.Repository;
using DydarShop.VeiwModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DydarShop.Controllers {
    public class ShopCartController : Controller {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart) {
            _carRep = carRep;
            _shopCart = shopCart;
        }
        public ViewResult Index() {
            var items = _shopCart.getShopItems();
            _shopCart.LIstShopItems = items;

            var obj = new ShopCartViewModel { ShopCart = _shopCart };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id) {
            var item = _carRep.Cars.FirstOrDefault(i => i.Id == id);
            if (item != null) {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
