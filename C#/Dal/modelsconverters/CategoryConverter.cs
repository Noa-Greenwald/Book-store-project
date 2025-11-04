

namespace Dal_Repository.modelsconverters;

public class CategoryConverter
{
    public static async Task<List<Dto_Common_Enteties.CategoryDto>> ToCategoryDtoList(List<Models.Category> lp)
    {
        List<Dto_Common_Enteties.CategoryDto> l = new List<Dto_Common_Enteties.CategoryDto>();
        foreach (Models.Category p in lp)
        {
            l.Add(ToCategoryDto(p));
        }
        return l;
    }

    public static Dto_Common_Enteties.CategoryDto ToCategoryDto(Models.Category p)
    {
        Dto_Common_Enteties.CategoryDto pc = new Dto_Common_Enteties.CategoryDto();

        pc.CategoryName = p.CategoryName;
        pc.CategoryId = p.CategoryId;

        return pc;
    }
}

