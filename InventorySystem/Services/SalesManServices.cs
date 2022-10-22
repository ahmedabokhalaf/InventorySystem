using InventorySystem.InventoryDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Services
{
    class SalesManServices
    {
        MyDBContext DbContext = new MyDBContext();

        public List<SalesMan> getAllSalesMan()
        {
            List<SalesMan> salesManList = new List<SalesMan>();
            salesManList = DbContext.SalesMens.Select(c => c).ToList();
            return salesManList;
        }
        public int getSalesManId(string saleName)
        {

            int id = DbContext.SalesMens.Where(s => s.Name == saleName).Select(s => s.ID).FirstOrDefault();
            return id;
        }
        public string getSalesManName(int saleID)
        {
            string saleName = DbContext.Categories.Where(c => c.ID == saleID).Select(c => c.Name).FirstOrDefault();
            return saleName;
        }
        public void Add(string saleManName, int phone, string address)
        {
            DbContext.SalesMens.Add(new SalesMan { Name = saleManName, Phone = phone, Address = address });
            DbContext.SaveChanges();
        }
    }
}
