using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebService.DTOs
{
    public partial class UserRoleDto : Dto
    {
       
        public Int64 Id { get; set; }
        public Int64 UserId { get; set; }
        public Int64 RoleId { get; set; }
    }
}
