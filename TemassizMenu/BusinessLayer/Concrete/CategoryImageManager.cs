using DataAccessLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryImageManager
    {
        Repository<CategoryImage> repository = new Repository<CategoryImage>();

        public int Add(CategoryImage categoryImage)
        {
            return repository.Insert(categoryImage);
        }

        public List<CategoryImage> GetAll()
        {
            return repository.List();
        }

        public int Delete(int id)
        {
            CategoryImage categoryImage = repository.Find(x => x.Id == id);
            return repository.Delete(categoryImage);
        }

        public int Update(CategoryImage categoryImage)
        {
            CategoryImage resim = repository.Find(x => x.Id == categoryImage.Id);
            resim.Name = categoryImage.Name;
            resim.CategoryID = categoryImage.CategoryID;
            resim.Path = categoryImage.Path;
            return repository.Update(resim);
        }

        public CategoryImage Get(int id)
        {
            return repository.GetById(id);
        }
    }
}
