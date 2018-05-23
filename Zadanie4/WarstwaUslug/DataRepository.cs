using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarstwaDanych;

namespace WarstwaUslug
{
    public class DataRepository
    {
        private DataClassesDataContext dataContext = new DataClassesDataContext();
        //CRUD
        
        public Vendor CreateVendor()
        {
            Vendor newVendor = new Vendor();
            dataContext.Vendors.InsertOnSubmit(newVendor);
            newVendor.ModifiedDate = System.DateTime.Now;
            return newVendor;
        }
        public void DeleteVendor(Vendor vendor)
        {
            dataContext.Vendors.DeleteOnSubmit(vendor);
        }
        public List<Vendor> GetAllVendors()
        {
            return dataContext.Vendors.ToList();
        }
        public void SubmitChanges()
        {
            dataContext.SubmitChanges();
        }       
    }
}
