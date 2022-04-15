using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class UserRole : Entity
    {
       
        public Int64 Id { get; set; }
        public Int64 UserId { get; set; }
        public Int64 RoleId { get; set; }
        public virtual AdminUser AdminUser { get; set; }
        public virtual Role Role { get; set; }
    }
}
