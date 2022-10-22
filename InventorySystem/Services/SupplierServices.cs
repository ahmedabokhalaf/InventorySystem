using InventorySystem.InventoryDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Services
{
    public class SupplierServices
    {
        MyDBContext DbContext = new MyDBContext();
        public List<Supplier> getAllSuppliers()
        {
            List<Supplier> supplierList = new List<Supplier>();
            supplierList = DbContext.Suppliers.Select(d => d).ToList();
            return supplierList;
        }
        public int getSupplierId(string SupplierName)
        {

            int id = DbContext.Suppliers.Where(s => s.Name == SupplierName).Select(s => s.ID).FirstOrDefault();
            return id;
        }
        public void Add(string supplierName,int phone ,string address)
        {
            DbContext.Suppliers.Add(new Supplier { Name = supplierName,Phone = phone , Address = address });
            DbContext.SaveChanges();
        }
    }
}
