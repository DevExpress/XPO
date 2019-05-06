using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Grid;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplicationMvvm.Services {
    public sealed class InstantFeedbackService : ServiceBase, IInstantFeedbackService {
        public static DependencyProperty KeyFieldNameProperty = DependencyProperty.Register("KeyFieldName", typeof(string), typeof(InstantFeedbackService));
        public string KeyFieldName {
            get { return (string)GetValue(KeyFieldNameProperty); }
            set { SetValue(KeyFieldNameProperty, value); }
        }
        private void Guard() {
            if (string.IsNullOrWhiteSpace(KeyFieldName))
                throw new InvalidOperationException("The InstantFeedbackService is not initialized. The KeyFieldName property is not assigned");
        }
        object IInstantFeedbackService.GetFocusedRowKey() {
            Guard();
            GridControl grid = (GridControl)AssociatedObject;
            return grid.GetFocusedRowCellValue(KeyFieldName);
        }
        async Task IInstantFeedbackService.SetFocusedRowByKeyAsync(object focusedObjectKey) {
            Guard();
            GridControl grid = (GridControl)AssociatedObject;
            grid.View.FocusedRowHandle = await grid.FindRowByValueAsync(KeyFieldName, focusedObjectKey);
        }
    }
    public interface IInstantFeedbackService {
        object GetFocusedRowKey();
        Task SetFocusedRowByKeyAsync(object focusedObjectKey);
    }
}
