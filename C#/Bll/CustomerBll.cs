using Dal_Repository;
using Dal_Repository.Models;
using Dto_Common_Enteties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll_Servicies
{
    public class CustomerBll
    {
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
        private readonly CustomersDal _customersDal;
        public CustomerBll(CustomersDal customersDal)
        {
            _customersDal = customersDal ?? throw new ArgumentNullException(nameof(customersDal));
        }


        public async Task InsertCustomerAsync(CustomerDto customerDto)
        {
            var customerEntity = new Customer
            {
                CustomerName = customerDto.CustomerName,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
                Birthday = customerDto.Birthday
            };

            await _customersDal.InsertCustomerAsync(customerEntity);
        }

      /*  public async Task InsertCustomerAsync(Dto_Common_Enteties.CustomerDto customer)
        {
            await CustomersDal.InsertCustomerAsync(customer);
        }*/
    }
}
