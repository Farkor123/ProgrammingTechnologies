using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarstwaDanych;

namespace WarstwaUslug
{
    public static class Extensions
    {
        public static List<Product> GetWithoutCategory(this List<Product> source)
        {
            return (from p in source
                    where p.ProductSubcategory == null || p.ProductSubcategory.ProductCategory == null
                    select p).ToList();
        }

        public static List<List<Product>> DivideIntoPages(this List<Product> source, int pageSize)
        {
            int i = 0;
            return source.Select(o => new { Index = i++, Value = o }).GroupBy(x => x.Index / pageSize).Select(x => x.Select(y => y.Value).ToList()).ToList();
        }

        public static string PrintProductProductVendor(this List<Product> source)
        {
            string output = "";
            source.Select(o => new { pName = o.Name, vNames = o.ProductVendors.Select(p => p.Vendor.Name).ToList() }).ToList().ForEach(o => {
                if (o.vNames.Count == 0)
                    output += o.pName + " - " + " NULL" + "\n";
              
                else
                 
                    foreach (var name in o.vNames)
                        output += o.pName + " - " + name + "\n";
            });
            return output;
        }

    }
}
