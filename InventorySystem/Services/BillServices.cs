using InventorySystem.InventoryDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Services
{
    public class BillServices
    {
        MyDBContext DbContext = new MyDBContext();
        public List<Bill> getAllBill()
        {
            List<Bill> billList = new List<Bill>();
            billList = DbContext.Bills.Select(bill => bill).ToList();
            return billList;
        }
        public int getBillId(int cusId,int salesId)
        {
            int id = DbContext.Bills.Where(c => c.CustomerID == cusId && c.SalesManID == salesId).Select(b => b.ID).FirstOrDefault();
            return id;
        }
        public void Add(int custId,int salesManId)
        {
            DbContext.Bills.Add(new Bill
            {
               CustomerID=custId,
               SalesManID = salesManId
            });
            DbContext.SaveChanges();
        }
    }
}
