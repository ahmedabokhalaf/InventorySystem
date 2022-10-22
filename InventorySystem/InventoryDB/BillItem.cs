using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.InventoryDB
{
    public class BillItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 1)]
        public int ID { set; get; }
        [Key,ForeignKey("Bill"),Column(Order =2)]
        public int BillID { get; set; }
        public virtual Bill Bill { set; get; }

        [Key,ForeignKey("Item"),Column(Order = 3)]
        public int ItemID { get; set; }
        public virtual Item Item { set; get; }

        public int QuantitySelled { set; get; }


    }
}
