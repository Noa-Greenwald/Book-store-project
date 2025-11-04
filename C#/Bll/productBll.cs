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

    


    }

}

