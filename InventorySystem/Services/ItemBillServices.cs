using InventorySystem.InventoryDB;
using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Services
{
    public class ItemBillServices
    {
        MyDBContext DbContext = new MyDBContext();
        ItemServices ItemServices = new ItemServices();
        public List<BillItem> getAllBill()
        {
            List<BillItem> billItemList = new List<BillItem>();
            billItemList = DbContext.BillItems.Select(billitem => billitem).ToList();
            return billItemList;
        }
        public List<Item> getStayedItems()
        {
            var billItemList = DbContext.BillItems.Select(billitem => billitem.ItemID).ToList();
            var stayedItem = (from s in DbContext.Items
                        where !billItemList.Contains(s.ID)
                        orderby s.Name
                        select s).ToList<Item>();
  
            return stayedItem;
        }
        public List<SaledItem> getBillByGroup()
        {
            List<SaledItem> itemSaled = new List<SaledItem>();

           var result = DbContext.BillItems.GroupBy(entry => entry.Item.Name).Select(g => new SaledItem { Name = g.Key, quantitySaled = g.Sum(e => e.QuantitySelled) }); ;
            foreach(var q in result)
            {
                itemSaled.Add(q);
            }
            return itemSaled ;

        }
        
        public void Add(int billID, int itemID,int quanSaled)
        {
            DbContext.BillItems.Add(new BillItem
            {
                ItemID = itemID,
                BillID = billID,
                QuantitySelled = quanSaled
            });
            DbContext.SaveChanges();
        }
    }
}
