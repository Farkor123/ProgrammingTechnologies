using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class MyProductGetter
    {
        private static ProductionDataContext db = new ProductionDataContext();
        private static List<MyProduct> MyList = new MyList().MPList;

        public static List<MyProduct> GetMyProductsByName(string namePart)
        {
            return (from p in MyList
                    where p.Name.Contains(namePart)
                    select p).ToList();
        }
        public static List<MyProduct> GetProductsByVendorName(string vendorName)
        {
            return (from p in MyList
                    from v in db.ProductVendor
                    where p.ProductID == v.ProductID && v.Vendor.Name == vendorName
                    select p).ToList();
        }
        //Tutaj inaczej wygląda co nieco zapytanie, bo w tym pierwotnym w Tools
        //jest tylko odwołanie do db.ProductReviews, i MyList nie byłoby potrzebne...
        public static List<MyProduct> GetMyProductsWithNRecentReviews(int howManyReviews)
        {
            return (from p in MyList
                    where (from r in db.ProductReview orderby r.ModifiedDate select r.ProductID).
                    Take(howManyReviews).Contains(p.ProductID)
                    select p).Distinct().ToList();

        }
    }
}
