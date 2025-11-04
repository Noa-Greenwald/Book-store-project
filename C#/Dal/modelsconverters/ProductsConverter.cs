using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dal_Repository.modelsconverters
{
        public class ProductsConverter
        {
            public  static async Task<List<Dto_Common_Enteties.productsDto>> ToProductDtoList(List<Models.Product> lp)
            {
                List<Dto_Common_Enteties.productsDto> l = new List<Dto_Common_Enteties.productsDto>();
                foreach (Models.Product p in lp)
                {
                    l.Add(ToProductDto(p));
                }
                return l;
            }

            public static Dto_Common_Enteties.productsDto ToProductDto(Models.Product p)
            {
            Dto_Common_Enteties.productsDto pc = new Dto_Common_Enteties.productsDto();

            pc.ProductName = p.ProductName;
                 pc.Picture = p.Picture;
                 pc.Price = p.Price;
                 pc.Description = p.Description;
                 pc.MatchAge = p.MatchAge;
                 pc.CompanyId = p.CompanyId;
                 pc.CategoryId= p.CategoryId;

                return pc;
            }
        }
    }
  

