using Microsoft.AspNetCore.Mvc;
using Bll_Servicies;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly CategoryBll _CategoryBll;

    public CategoryController()
    {
        _CategoryBll = new CategoryBll();

    }
    // שליפת כל הקטגוריות
    [HttpGet("categories")]
    public async Task<List<Dto_Common_Enteties.CategoryDto>> GetCategories()
    {
        return await _CategoryBll.SelectCategoryAsync();
    }

    // סינון מוצרים לפי שם הקטגוריה
    [HttpPost("PostByCategoryName/{categoryName}")]
    public async Task<List<Dto_Common_Enteties.productsDto>> PostByCategoryName(string categoryName)
    {
        return await _CategoryBll.PostByCategoryNameAsync(categoryName);
    }
}
