using System;

namespace AspNetMvcApplication.Models {
    public class OrderViewModel {
        public int Oid { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Freight { get; set; }
        public int CustomerId { get; set; }
    }
}
