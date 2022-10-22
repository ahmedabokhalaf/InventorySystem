using InventorySystem.InventoryDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Services
{
    public class UserServices
    {

        MyDBContext DbContext = new MyDBContext();
        public List<User> getAllUsers()
        {
            List<User> usersList = new List<User>();
            usersList = DbContext.Users.Select(user => user).ToList();
            return usersList;
        }
      
        public void Add(string _username, string _password)
        {
            DbContext.Users.Add(new User
            {
                UserName = _username,
                Password = _password
            });
            DbContext.SaveChanges();
        }
        public void show()
        {
            getAllUsers();
        }
    }
}
