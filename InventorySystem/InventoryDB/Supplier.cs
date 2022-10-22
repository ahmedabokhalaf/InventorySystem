using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.InventoryDB
{
    public class Supplier
    {
       
        public int ID { set; get; }
        
        public string Name { set; get; }
        public int Phone { set; get; }
        public string Address { set; get; }
        public virtual ICollection<Item> Items { set; get; }
        public override string ToString()
        {
            return Name;
        }

    }
}
