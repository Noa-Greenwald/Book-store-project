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

   

}
