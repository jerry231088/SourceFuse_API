using System;
using System.Collections.Generic;

namespace Sourcefuse_Api.ViewModels
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ContactInfoVM ContactInfo { get; set; }
        public List<OrdersVM> Orders { get; set; }
    }
}
