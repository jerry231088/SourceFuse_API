using System;
namespace Sourcefuse_Api.ViewModels
{
    public class OrdersVM
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string 
        public bool OrderPriority { get; set; }
        public bool Custom { get; set; }
    }
}
