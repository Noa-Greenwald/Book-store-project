using Dal_Repository.Models;


namespace Dal_Repository
{
    public class ProductDal
    {

        //שליפת כל המוצרים
        public async Task<List<Dto_Common_Enteties.productsDto>> SelectAllAsync()
        {
            using (DnProjectContext db = new DnProjectContext())
            {
                var l = db.Products.ToList();
                return await modelsconverters.ProductsConverter.ToProductDtoList(l);
            }
        }


    }
}