using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AccountingWorkingHours.Extension;

public static class Extension
{
    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection) => new(collection);
}