using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class MyList
    {
        public MyList()
        {
            ProductionDataContext db = new ProductionDataContext();
            foreach (Product pkur in db.Product.ToList())
            {
                MPList.Add(new MyProduct(pkur));
            }
        }
        private List<MyProduct> _MPList = new List<MyProduct>();
        public List<MyProduct> MPList
        {
            get { return _MPList; }
            private set { _MPList = value; }
        }
    }
}
