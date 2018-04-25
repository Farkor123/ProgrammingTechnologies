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
    }
}
