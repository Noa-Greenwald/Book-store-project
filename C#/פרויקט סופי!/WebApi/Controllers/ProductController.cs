using Microsoft.AspNetCore.Mvc;
using Bll_Servicies;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly productBll _productBll;

    public ProductController()
    {
        _productBll = new productBll();
    }

    // שליפת כל המוצרים
    [HttpGet("products")]
    public async Task<List<Dto_Common_Enteties.productsDto>> GetProducts()
    {
        return await _productBll.SelectAllAsync();
    }

    // שליפת כל הקטגוריות
    [HttpGet("categories")]
    public async Task<List<Dto_Common_Enteties.CategoryDto>> GetCategories()
    {
        return await _productBll.SelectCategoryAsync();
    }

    // סינון מוצרים לפי שם הקטגוריה
    [HttpPost("PostByCategoryName/{categoryName}")]
    public async Task<List<Dto_Common_Enteties.productsDto>> PostByCategoryName(string categoryName)
    {
        return await _productBll.PostByCategoryNameAsync(categoryName);
    }
    //שליפת כל הלקוחות
    [HttpGet("customers")]
    public async Task<List<Dto_Common_Enteties.CustomerDto>> GetCustomers()
    {
        return await _productBll.SelectAllCustomersAsync();
    }

    //בדיקה אם לקוח קיים
    [HttpGet("GetCheckCustomerEmail/{email}")]
    public async Task<bool> GetCheckCustomerEmail([FromRoute] string email)
    {
        return await _productBll.CheckCustomerEmailAsync(email);
    }

}
