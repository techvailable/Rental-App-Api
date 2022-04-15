using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class Category : Entity
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
            Brands = new HashSet<Brand>();
            Products = new HashSet<Product>();
        }
        
        public Int64 Id { get; set; }
        public Int64 StoreId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual Store Store { get; set; }
        public  virtual ICollection<SubCategory> SubCategories { get; set;}
        public  virtual ICollection<Brand> Brands { get; set; }
        public  virtual ICollection<Product> Products { get; set; }
    }
}
