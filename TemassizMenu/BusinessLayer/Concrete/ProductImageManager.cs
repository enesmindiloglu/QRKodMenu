using DataAccessLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductImageManager
    {
        Repository<ProductImage> repository = new Repository<ProductImage>();

        public int Add(ProductImage image)
        {
            return repository.Insert(image);
        }

        public List<ProductImage> GetAll()
        {
            return repository.List();
        }

        public int Delete(int id)
        {
            ProductImage productImage = repository.Find(x => x.Id == id);
            return repository.Delete(productImage);
        }

        public int Update(ProductImage image)
        {
            ProductImage productImage = repository.Find(x => x.Id == image.Id);
            productImage.Name = image.Name;
            productImage.ProductID = image.ProductID;
            productImage.Path = image.Path;
            return repository.Update(productImage);
        }

        public ProductImage Get(int id)
        {
            return repository.GetById(id);
        }
    }
}
