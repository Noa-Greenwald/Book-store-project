using Dal_Repository.Models;
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

    }
}
