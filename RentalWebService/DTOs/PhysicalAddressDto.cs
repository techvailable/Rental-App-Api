﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebService.DTOs
{
    public partial class PhysicalAddressDto : Dto
    {
       
        public Int64 Id { get; set; }
        public Int64 UserId { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string BillingAddress { get; set; }
        public int UnitNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Mobile { get; set; }
        public bool IsBilling { get; set; }
        public bool IsShipping { get; set; }
        public bool IsWareHouse { get; set; }
        public bool Active { get; set; }
    }
}
