using System;
namespace Sourcefuse_Api.ViewModels
{
    public class OrdersVM
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string OrderStatus { get; set; }
        public float Order_Total { get; set; }
        public string PaymentMethod { get; set; }
        public string Shipping_Address { get; set; }
        public string Billing_Address { get; set; }
        public string OrderItems { get; set; }
        public string Tracking_Info { get; set; }
        public bool Return { get; set; }
        public bool OrderPriority { get; set; }
        public bool Custom { get; set; }
    }
}
