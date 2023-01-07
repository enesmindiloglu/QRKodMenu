using DataAccessLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        Repository<Category> repository = new Repository<Category>();

        public int Add(Category category)
        {
            return repository.Insert(category);
        }

        public List<Category> GetAll()
        {
            return repository.List();
        }

        public int Delete(int id)
        {
            Category category = repository.Find(x => x.Id == id);
            return repository.Delete(category);
        }

        public int Update(Category category)
        {
            Category c = repository.Find(x => x.Id == category.Id);
            c.CategoryName = category.CategoryName;
            return repository.Update(c);
        }

        public Category Get(int id)
        {
            return repository.GetById(id);
        }
    }
}
