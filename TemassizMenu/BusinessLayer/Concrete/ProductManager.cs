using DataAccessLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager
    {
        Repository<Product> repository = new Repository<Product>();

        public int Add(Product product)
        {
            return repository.Insert(product);
        }

        public List<Product> GetAll()
        {
            return repository.List();
        }

        public int Delete(int id)
        {
            Product product = repository.Find(x => x.Id == id);
            return repository.Delete(product);
        }

        public int Update(Product product)
        {
            Product p = repository.Find(x => x.Id == product.Id);
            p.ProductName = product.ProductName;
            p.Price = product.Price;
            p.CategoryID = product.CategoryID;
            return repository.Update(p);
        }

        public Product Get(int id)
        {
            return repository.GetById(id);
        }

        public List<Product> GetAllByCategoryID(int id)
        {
            return repository.FindAll(x => x.CategoryID == id);
        }
    }
}
