using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.InventoryDB
{
   public class Item
    {
        

        public int ID { set; get; }
        
        public string Name { set; get; }
        public int BuyPrice { set; get; }
        public int SellPrice { set; get; }
        public int Quantity { set; get; }
 
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { set; get; }

        [ForeignKey("Supplier")]
        public int SupplierID { get; set; }
        public virtual Supplier Supplier { set; get; }
        public virtual ICollection<BillItem> BillItems { set; get; }
        public override string ToString()
        {
            return  Name;
        }
    }
}
