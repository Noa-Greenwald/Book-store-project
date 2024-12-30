using Dal_Repository.Models;

namespace Dal_Repository
{
    public class CategoryDal
    {

        // הקטגוריות
        public async Task<List<Dto_Common_Enteties.CategoryDto>> SelectCategoryAsync()
        {
            using (DnProjectContext db = new DnProjectContext())
            {
                var c = db.Categories.ToList();
                return await modelsconverters.CategoryConverter.ToCategoryDtoList(c);

            }

        }
    }
}

