using Dal_Repository.Models;
using Dto_Common_Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository
{
    public class CustomersDal
    {
        public async Task<List<Dto_Common_Enteties.CustomerDto>> SelectAllCustomersAsync()
        {
            using (DnProjectContext db = new DnProjectContext())
            {
                var cu = db.Customers.ToList();
                return await modelsconverters.CustomerConverter.ToCustomerDtoList(cu);
            }
        }
        public async Task InsertCustomerAsync(Customer customer)
        {
            using (var db = new DnProjectContext())
            {
                db.Customers.Add(customer);
                await db.SaveChangesAsync();
            }
        }



        /*
        public async Task InsertCustomerAsync(CustomerDto customerDto)
        {
            using (DnProjectContext db = new DnProjectContext())
            {
                var newCustomer= modelsconverters.CustomerConverter.ToCustomer(customerDto);
                db.Customers.Add(newCustomer);
                await db.SaveChangesAsync();
            }
        }*/

    }
}
    