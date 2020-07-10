using DevExpress.Xpo;

namespace XamarinFormsDemo.Models {
    //POCO XPO entity
    [Persistent]
    public class Item {
        [Key]
        public string Id { get; set; }
        [Size(256)]
        public string Text { get; set; }
        [Size(SizeAttribute.Unlimited)]
        public string Description { get; set; }
    }
}
