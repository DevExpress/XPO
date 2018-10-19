using System;
using DevExpress.Xpo;

namespace DevExpress.Xpo.XamarinFormsDemo {

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

/*
    A fully functional XPO entity.
    [Persistent]
    public class ItemEntity : XPLiteObject {
        string id;
        [Key]
        public string Id {
            get { return id; }
            set { SetPropertyValue(nameof(Id), ref id, value); }
        }
        string text;
        [Size(256)]
        public string Text {
            get { return text; }
            set { SetPropertyValue(nameof(Text), ref text, value); }
        }
        string description;
        [Size(SizeAttribute.Unlimited)]
        public string Description {
            get { return description; }
            set { SetPropertyValue(nameof(Description), ref description, value); }
        }
    }
*/
}
