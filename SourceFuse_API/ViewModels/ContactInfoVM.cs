using System;
namespace Sourcefuse_Api.ViewModels
{
    public class ContactInfoVM
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
    }
}
