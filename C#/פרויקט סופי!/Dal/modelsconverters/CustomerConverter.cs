using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository.modelsconverters
{
    public class CustomerConverter
    {
        public static async Task<List<Dto_Common_Enteties.CustomerDto>> ToCustomerDtoList(List<Models.Customer> lp)
        {
            List<Dto_Common_Enteties.CustomerDto> l = new List<Dto_Common_Enteties.CustomerDto>();
            foreach (Models.Customer p in lp)
            {
                l.Add(ToCustomerDto(p));
            }
            return l;
        }


        public static Dto_Common_Enteties.CustomerDto ToCustomerDto(Models.Customer p)
        {
            Dto_Common_Enteties.CustomerDto pc = new Dto_Common_Enteties.CustomerDto();

            pc.CustomerId = p.CustomerId;
            pc.CustomerName = p.CustomerName;
            pc.Phone = p.Phone;
            pc.Email = p.Email;
            pc.Birthday = p.Birthday;

            return pc;
        }

    }
}
