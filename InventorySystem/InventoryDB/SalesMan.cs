﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.InventoryDB
{
    public class SalesMan
    {
       
        public int ID { set; get; }
       
        public string Name { set; get; }
        public long? Phone { set; get; }
        public string Address { set; get; }
        public virtual ICollection<Bill> Bills { set; get; }

        public override string ToString()
        {
            return Name;
        }


    }
}
