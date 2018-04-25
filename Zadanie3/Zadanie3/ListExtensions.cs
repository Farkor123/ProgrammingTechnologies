using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public static class ListExtensions
    {
        public static List<Product> NotCategorized(this List<Product> list)
        {
            return new List<Product>(list.Where(p => p.ProductSubcategoryID == null));
        }

        public static List<Product> GetPage(this List<Product> list, int itemsPerPage, int pageNumber)
        {
            return list.GetRange(pageNumber * itemsPerPage, itemsPerPage);
        }

        public static string Stringify(this List<Product> list)
        {
            ProductionDataContext dataContext = new ProductionDataContext();

            var results = from p in list
                          join pv in dataContext.ProductVendor on p.ProductID equals pv.ProductID
                          join v in dataContext.Vendor on pv.BusinessEntityID equals v.BusinessEntityID
                          select new {Prod = p, Vend = v};

            string result = "";
            foreach(var pair in results)
            {
                result += pair.Prod.Name + "-" + pair.Vend.Name + "\n";
            }
            return result;
        }
    }
}
