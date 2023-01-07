using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public string Path { get; set; }
    }
}
