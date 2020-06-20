using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace BlazorServerSideApplication {
    public static class JsonPopulateObjectHelper {
        public static void PopulateObject(string json, Session session, PersistentBase obj) {
            PopulateObject(json, session, obj.ClassInfo, obj);
        }

        public static void PopulateObject(string json, Session session, XPClassInfo classInfo, object obj) {
            PopulateObject(JObject.Parse(json), session, classInfo, obj);
        }

        public static T PopulateObject<T>(string json, Session session) where T : PersistentBase {
            return (T)PopulateObject(json, session, session.Dictionary.GetClassInfo(typeof(T)));
        }

        public static object PopulateObject(string json, Session session, XPClassInfo classInfo) {
            return PopulateObject(JObject.Parse(json), session, classInfo);
        }

        static object PopulateObject(JObject jobject, Session session, XPClassInfo classInfo) {
            object obj = classInfo.CreateObject(session);
            PopulateObject(jobject, session, classInfo, obj);
            return obj;
        }

        static void PopulateObject(JObject jobject, Session session, XPClassInfo classInfo, object obj) {
            foreach(XPMemberInfo mi in classInfo.Members) {
                if(!jobject.ContainsKey(mi.Name)) {
                    continue;
                }
                if(mi.ReferenceType != null && !mi.IsCollection) {
                    PopulateReferenceProperty(jobject, obj, mi, session);
                } else if(mi.IsCollection) {
                    throw new NotImplementedException();
                } else if(!mi.IsAliased && !mi.IsReadOnly) {
                    PopulateProperty(jobject, obj, mi);
                }
            }
        }

        static void PopulateProperty(JObject jobject, object obj, XPMemberInfo memberInfo) {
            JValue jvalue = (JValue)jobject[memberInfo.Name];
            object value = jvalue.Value;
            if(value != null) {
                if(value.GetType() != memberInfo.StorageType) {
                    value = Convert.ChangeType(value, memberInfo.StorageType, CultureInfo.InvariantCulture);
                }
            }
            memberInfo.SetValue(obj, value);
        }

        static void PopulateReferenceProperty(JObject jobject, object obj, XPMemberInfo memberInfo, Session session) {
            JObject refJObject = null;
            XPMemberInfo keyMemberInfo = memberInfo.ReferenceType.KeyProperty;
            if(jobject[memberInfo.Name] is JValue referenceShort) {
                dynamic nestedJObject = new JObject();
                nestedJObject[keyMemberInfo.Name] = referenceShort;
                refJObject = nestedJObject;
            } else if(jobject[memberInfo.Name] is JObject referenceLong) {
                refJObject = referenceLong;
            } else if(refJObject == null) {
                throw new ArgumentException("Unknown JSON format for reference properties! Short and long formats are supported: '{{ReferenceName: KeyValue}}' or {{ReferenceName: {{KeyName: KeyValue}}}}.", "jobject");
            }
            object refObject = memberInfo.GetValue(obj);
            if(refJObject != null) {
                JToken keyToken = refJObject[memberInfo.ReferenceType.KeyProperty.Name];
                object keyValue = ((JValue)keyToken).Value;
                if(keyValue != null) {
                    if(keyValue.GetType() != keyMemberInfo.MemberType) {
                        keyValue = Convert.ChangeType(keyValue, keyMemberInfo.MemberType, CultureInfo.InvariantCulture);
                    }
                    refObject = session.GetObjectByKey(memberInfo.ReferenceType, keyValue);
                }
            } else {
                refObject = null;
            }
            if(refObject != null) {
                PopulateObject(refJObject, session, memberInfo.ReferenceType, refObject);
            }
            memberInfo.SetValue(obj, refObject);
        }
    }
}