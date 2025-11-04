using Dal_Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll_Servicies
{
    public class CategoryBll
    {

        //  שליפת קטגוריות
        public async Task<List<Dto_Common_Enteties.CategoryDto>> SelectCategoryAsync()
        {
            using (DnProjectContext db = new DnProjectContext())
            {
                Dal_Repository.CategoryDal b = new Dal_Repository.CategoryDal();
                return await b.SelectCategoryAsync();
            }
        }

        // שליפה עפי קטגוריה
        public async Task<List<Dto_Common_Enteties.productsDto>> PostByCategoryNameAsync(string categoryName)
        {
            using (DnProjectContext db = new DnProjectContext())
            {
                var products = await db.Products.Include(p => p.Category)
                .Where(p => p.Category.CategoryName == categoryName).ToListAsync();


                return await Dal_Repository.modelsconverters.ProductsConverter.ToProductDtoList(products);
            }

        }
    }
}
