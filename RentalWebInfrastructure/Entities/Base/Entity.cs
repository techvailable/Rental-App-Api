using System;
using System.Collections.Generic;
using System.Text;

namespace RentalWebInfrastructure.Entities
{
    public class Entity
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
