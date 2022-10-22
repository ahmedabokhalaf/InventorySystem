using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.InventoryDB
{
    public class MyDBContext : DbContext
    {
        
        public MyDBContext() : base(" Data Source =.; Initial Catalog = InventoryDb; Integrated Security = True")
        {
           
        }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Item> Items { set; get; }
        public DbSet<Supplier> Suppliers { set; get; }
        public DbSet<SalesMan> SalesMens { set; get; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
