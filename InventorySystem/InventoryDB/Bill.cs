using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.InventoryDB
{
    public class Bill
    {
        
        public int ID { set; get; }
     
        [ForeignKey("SalesMan")]
        public int SalesManID { get; set; }
        public virtual SalesMan SalesMan { set; get; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { set; get; }

        public virtual ICollection<BillItem> BillItems { set; get; }


    }
}
