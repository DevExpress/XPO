using DevExpress.Xpo;
using System.Collections.Generic;
using System.ComponentModel;

namespace BlazorServerSideApplication {
    public static class PopulateObjectHelper {
        public static void PopulateObject(Session session, XPBaseObject @object, Dictionary<string, object> values) {
            PropertyDescriptorCollection pdc = session.GetProperties(@object.ClassInfo);
            foreach(KeyValuePair<string, object> kvp in values) {
                object value = kvp.Value;
                if(value is XPBaseObject xpobj)
                    value = session.GetObjectByKey(xpobj.ClassInfo, session.GetKeyValue(xpobj));
                PropertyDescriptor prop = pdc.Find(kvp.Key, false);
                if(prop != null)
                    prop.SetValue(@object, value);
            }
        }
    }
}
