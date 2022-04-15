using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class IpAddress : Entity
    {
                
        public Int64 Id { get; set; }
        public Int64 UserId { get; set; }
        public int IpV1 { get; set; }
        public int IpV2 { get; set; }
        public int IpV3 { get; set; }
        public int IpV4 { get; set; }
        public virtual User User { get; set; }
    }
}
