using System;
using DevExpress.Utils;

namespace WinFormsApplication.ViewModels {
    public sealed class ViewID : IEquatable<ViewID> {
        readonly object viewType;
        readonly int? id;
        public ViewID(object viewType) {
            this.viewType = viewType;
            this.id = null;
        }
        public ViewID(object viewType, int id) {
            this.viewType = viewType;
            this.id = id;
        }
        public bool Equals(ViewID other) {
            return (other != null) && Equals(viewType, other.viewType) && Equals(id, other.id);
        }
        public override bool Equals(object obj) {
            return Equals(obj as ViewID);
        }
        public override int GetHashCode() {
            return HashCodeHelper.CalculateGeneric(viewType, id);
        }
    }
}
