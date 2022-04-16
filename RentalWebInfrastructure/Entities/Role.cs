using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class Role : Entity
    {
        public Role()
        {
            UserRole = new HashSet<UserRole>();
        }
        
        public Int64 Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
