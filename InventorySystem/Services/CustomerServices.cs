using InventorySystem.InventoryDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Services
{
    public class CustomerServices
    {
        MyDBContext DbContext = new MyDBContext();
        public List<Customer> getAllCustomer()
        {
            List<Customer> customerList = new List<Customer>();
            customerList = DbContext.Customers.Select(c => c).ToList();
            return customerList;
        }
        public int getCustomerId(string cusName)
        {

            int id = DbContext.Customers.Where(c => c.Name == cusName).Select(c => c.ID).FirstOrDefault();
            return id;
        }
        public string getCustomerName(int cusID)
        {
            string categoryName = DbContext.Categories.Where(c => c.ID == cusID).Select(c => c.Name).FirstOrDefault();
            return categoryName;
        }
        public void Add(string name, int phone, string address) {
            DbContext.Customers.Add(new Customer
            {
                Name = name,
                Phone = phone,
                Address = address,
            });
            DbContext.SaveChanges();
        }
    }
}
