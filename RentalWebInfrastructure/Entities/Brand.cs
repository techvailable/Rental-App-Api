using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class Brand : Entity
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }
        
        public Int64 Id { get; set; }
        public Int64 CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
