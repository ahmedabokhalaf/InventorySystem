using InventorySystem.InventoryDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Services
{
    public class CategoryServcices
    {
        MyDBContext DbContext = new MyDBContext();

        public List<Category> getAllCategory()
        {
            List<Category> categoryList = new List<Category>();
            categoryList = DbContext.Categories.Select(d => d).ToList();
            return categoryList;
        }

        public int getCatId(string catName)
        {
            int id = DbContext.Categories.Where(c => c.Name == catName).Select(c => c.ID).FirstOrDefault();
            return id;
        }
        public string getCatName(int catID)
        {
            string categoryName = DbContext.Categories.Where(c => c.ID == catID).Select(c => c.Name).FirstOrDefault();
            return categoryName;
        }
        public void Add(string name)
        {
            DbContext.Categories.Add(new Category {Name = name});
            DbContext.SaveChanges();
        }
    }
}
