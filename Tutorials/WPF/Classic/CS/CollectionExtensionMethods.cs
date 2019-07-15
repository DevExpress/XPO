using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace WpfApplication {
    static class CollectionExtensionMethods {

        public static async Task<ObservableCollection<T>> ToObservableCollectionAsync<T>(this IQueryable<T> source) {
            return new ObservableCollection<T>(await source.ToListAsync());
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IQueryable<T> source) {
            return new ObservableCollection<T>(source.ToList());
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source) {
            var observable = new ObservableCollection<T>(source.ToList());
            var observableSource = source as INotifyCollectionChanged;
            if(observableSource != null) {
                SetupINotifyCollectionChangedEvents(observableSource, observable);
            }
            return observable;
        }

        static void SetupINotifyCollectionChangedEvents<T>(INotifyCollectionChanged source, IList<T> target) {
            source.CollectionChanged += (s, e) => {
                switch(e.Action) {
                    case NotifyCollectionChangedAction.Add:
                        foreach(T item in e.NewItems) {
                            target.Add(item);
                        }
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach(T item in e.OldItems) {
                            target.Remove(item);
                        }
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        for(int i = e.OldStartingIndex; i < e.OldItems.Count; i++) {
                            target[i] = (T)e.NewItems[i];
                        }
                        break;
                    case NotifyCollectionChangedAction.Move:
                    case NotifyCollectionChangedAction.Reset:
                        target.Clear();
                        foreach(T item in target) {
                            target.Add(item);
                        }
                        break;
                }
            };
        }
    }
}
