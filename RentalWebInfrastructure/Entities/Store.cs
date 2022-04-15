using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class Store : Entity
    {
        public Store()
        {
            Categories = new HashSet<Category>();
        }
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
