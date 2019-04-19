using System.Collections.Generic;

namespace AspNetMvcApplication.Models {
    public class CustomerViewModel {
        public int Oid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactName {
            get { return string.Concat(FirstName, " ", LastName); }
        }
        public List<OrderViewModel> Orders { get; set; }
    }
}
