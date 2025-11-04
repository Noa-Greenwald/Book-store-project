using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto_Common_Enteties
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = null!;

        public string Phone { get; set; }

        public string Email { get; set; } = null!;

        public DateTime Birthday { get; set; }
    }
}
