using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class AdminUser : Entity
    {
        public AdminUser()
        {
            UserRole = new HashSet<UserRole>();
        }
        
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
