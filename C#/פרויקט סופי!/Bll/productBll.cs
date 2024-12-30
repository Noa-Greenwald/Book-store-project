using Dal_Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Bll_Servicies

{
    //שליפה של כל המוצרים
    public class productBll
    {
        public async Task<List<Dto_Common_Enteties.productsDto>> SelectAllAsync()
        {
            using (DnProjectContext db = new DnProjectContext())
            {
                Dal_Repository.ProductDal a = new Dal_Repository.ProductDal();
                return await a.SelectAllAsync();
            }
        }

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
                var l = await db.Products.Include(p => p.Category)
                         .Where(p => p.Category.CategoryName == categoryName).ToListAsync();

                return await Dal_Repository.modelsconverters.ProductsConverter.ToProductDtoList(l);
            }

        }
        //שליפת טבלת לקוחות 
        public async Task<List<Dto_Common_Enteties.CustomerDto>> SelectAllCustomersAsync()
        {
            using (DnProjectContext db = new DnProjectContext())
            {
                Dal_Repository.CustomersDal b = new Dal_Repository.CustomersDal();
                return await b.SelectAllCustomersAsync();
            }
        }


        //בדיקה האם הלקוח קיים
        public async Task<bool> CheckCustomerEmailAsync(string email)
        {
            using (DnProjectContext db = new DnProjectContext())
            {
                // בדוק אם יש לקוח עם המייל המבוקש
                var customerExists = await db.Customers
                    .AnyAsync(p => p.Email == email);

                return customerExists;
            }
        }


    }

}

