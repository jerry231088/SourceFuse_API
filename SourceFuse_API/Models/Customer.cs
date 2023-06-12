using System;
using System.Collections.Generic;

namespace Sourcefuse_Api.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
