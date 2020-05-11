using DydarShop.Data.Interfaces;
using DydarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DydarShop.Data.Repository {
    public class CategoryRepository : ICarsCategory {

        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent) {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}