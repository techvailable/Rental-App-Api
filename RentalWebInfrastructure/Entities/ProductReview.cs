using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class ProductReview : Entity
    {
        
        public Int64 Id { get; set; }
        public Int64 ProductId { get; set; }
        public Int64 UserId { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public string? ReviewBy { get; set; }
        public string? Address { get; set; }
        public int Rating { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
