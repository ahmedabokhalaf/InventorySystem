using InventorySystem.InventoryDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Services
{
    public class ItemServices
    {
        MyDBContext DbContext = new MyDBContext();
        public List<Item> getAllItem()
        {
            List<Item> itemList = new List<Item>();
            itemList = DbContext.Items.Select(item => item).ToList();
            return itemList;
        }
        public int getItemId(string itemName)
        {

            int id = DbContext.Items.Where(i => i.Name == itemName).Select(i => i.ID).FirstOrDefault();
            return id;
        }
        public int getItemPrice(int itemId)
        {

            int sellPrice = DbContext.Items.Where(i => i.ID == itemId).Select(i => i.SellPrice).FirstOrDefault();
            return sellPrice;
        }
        public string getItemName(int itemID)
        {
            string itemName = DbContext.Categories.Where(c => c.ID == itemID).Select(c => c.Name).FirstOrDefault();
            return itemName;
        }
        public List<Item> getItemByCatName(string catName)
        {
           
            List<Item> q = DbContext.Items.Where(i => i.Category.Name == catName).Select(i=>i).ToList();
            
            return q;
        }
        public int getItemQuantity(int itemId)
        {

            int existQuantity = DbContext.Items.Where(i => i.ID == itemId).Select(i => i.Quantity).FirstOrDefault();
            return existQuantity;
        }
        public string getCatNameByItemName(string itemName)
        {
            string catName = DbContext.Items.Where(i => i.Name == itemName).Select(c => c.Category.Name).FirstOrDefault();
            return catName;
        }

        public List<Item> getItemLessThan(int num)
        {
            List<Item> itemList = new List<Item>();
            var q = DbContext.Items.Where(n => n.Quantity <= num);
            foreach (var item in q)
            {
                itemList.Add(item);
            }
            return itemList;

        }

        public void Add(string name, int buyPrice, int sellPrice, int quantity , int catID,int SuppID)
        {
            DbContext.Items.Add(new Item
            {
                Name = name,
                BuyPrice = buyPrice,
                SellPrice = sellPrice,
                Quantity = quantity,
                CategoryID = catID,
                SupplierID = SuppID,
                
               
            });
            DbContext.SaveChanges();
        }
        public void update(int id, string name, int buyPrice, int sellPrice, int quantity, int catID, int SuppID)
        {
            var update = DbContext.Items.Where(item => item.ID == id).FirstOrDefault();
            update.Name = name;
            update.BuyPrice = buyPrice;
            update.SellPrice = sellPrice;
            update.Quantity += quantity;
            update.CategoryID = catID;
            update.SupplierID = SuppID;
            DbContext.SaveChanges();
        }
        public void updateQuantity(int id, int quantity)
        {
            var update = DbContext.Items.Where(item => item.ID == id).FirstOrDefault();
            update.Quantity -= quantity;
            DbContext.SaveChanges();
        }

    }
}
