using Bll_Servicies;
using Dal_Repository;
using Dto_Common_Enteties;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerBll _CustomerBll;

    public CustomerController()
    {

        _CustomerBll = new CustomerBll(new CustomersDal());
    }

    //שליפת כל הלקוחות
    [HttpGet("customers")]
    public async Task<List<CustomerDto>> GetCustomers()
    {
        return await _CustomerBll.SelectAllCustomersAsync();
    }

    //בדיקה אם לקוח קיים
    [HttpGet("GetCheckCustomerEmail/{email}")]
    public async Task<bool> GetCheckCustomerEmail([FromRoute] string email)
    {
        return await _CustomerBll.CheckCustomerEmailAsync(email);
    }

    [HttpPost] 
    [Route("InsertCustomer")]

    public async Task<IActionResult> InsertCustomerAsync([FromBody] CustomerDto customerDto)
    {
        if (customerDto == null)
        {
            return BadRequest(new { message = "Invalid customer data." });
        }

        await _CustomerBll.InsertCustomerAsync(customerDto);
        return Ok(new { message = "Customer inserted successfully." });
    }

}