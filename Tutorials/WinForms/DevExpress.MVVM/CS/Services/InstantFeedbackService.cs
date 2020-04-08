using System;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace WinFormsApplication.Services {
    public interface IInstantFeedbackService {
        object GetFocusedRowKey();
        void SetFocusedRowByKey(object focusedObjectKey);
    }
    //
    public sealed class InstantFeedbackService : IInstantFeedbackService {
        readonly GridView gridView;
        readonly string keyFieldName;
        public InstantFeedbackService(GridView gridView, string keyFieldName = "Oid") {
            this.gridView = gridView;
            this.keyFieldName = keyFieldName;
            if(gridView == null)
                throw new InvalidOperationException("The InstantFeedbackService is not initialized. The gridView property is not assigned");
            if(string.IsNullOrWhiteSpace(keyFieldName))
                throw new InvalidOperationException("The InstantFeedbackService is not initialized. The keyFieldName property is not assigned");
        }
        object IInstantFeedbackService.GetFocusedRowKey() {
            return gridView.GetFocusedRowCellValue(keyFieldName);
        }
        void IInstantFeedbackService.SetFocusedRowByKey(object focusedObjectKey) {
            gridView.FocusedRowHandle = gridView.DataController.FindRowByValue(keyFieldName, focusedObjectKey,
                new OperationCompleted(t => gridView.FocusedRowHandle = (int)t));
        }
    }
}
