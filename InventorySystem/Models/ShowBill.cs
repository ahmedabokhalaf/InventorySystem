using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.InventoryDB
{
     public class ShowBill
    {
        public string Category { set; get; }
        public string Name { set; get; }
        public int Quantity { set; get; }
        public int PriceOfPice { set; get; }
        public int TotalPrice { set; get; }
        public string Customer { set; get; }
        public string SalesMan { set; get; }

    }
}
