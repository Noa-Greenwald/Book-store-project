using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Dto_Common_Enteties
{
    public class productsDto
    {
        public string ProductName { get; set; } = null!;

        public int CategoryId { get; set; }

        public int CompanyId { get; set; }

        public int? MatchAge { get; set; }

        public string Description { get; set; } = null!;

        public string Picture { get; set; } = null!;

        public double? Price { get; set; }


        //public virtual Category Category { get; set; } = null!;

        //public virtual Company Company { get; set; } = null!;
    }
}

