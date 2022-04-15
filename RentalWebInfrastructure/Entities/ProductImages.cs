using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class ProductImages : Entity
    {
        
        public Int64 Id { get; set; }
        public Int64 ProductId { get; set; }
        public string? Title { get; set; }
        public string? Tags { get; set; }
        public bool Default { get; set; }
        public virtual Product Product { get; set; }
    }
}
