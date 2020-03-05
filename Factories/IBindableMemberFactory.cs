using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AquaFramework.Factories
{
    public interface IBindableMemberFactory
    {
        IBindableProperty<T> CreateBindableProperty<T>();
        IBindableProperty<T> CreateBindableProperty<T>(T value);
        IBindableList<T> CreateBindableList<T>(bool loop, int maxCapacity = 0);
        IBindableList<T> CreateBindableList<T>(IEnumerable<T> collection, bool loop, int maxCapacity = 0);
        IBindableList<T> CreateBindableList<T>(int capacity, bool loop, int maxCapacity = 0);
        IBindableList<TCellData, TListContext> CreateBindableList<TCellData, TListContext>(bool loop, int maxCapacity = 0);
        IBindableList<TCellData, TListContext> CreateBindableList<TCellData, TListContext>(IEnumerable<TCellData> collection, bool loop, int maxCapacity = 0);
        IBindableList<TCellData, TListContext> CreateBindableList<TCellData, TListContext>(int capacity, bool loop, int maxCapacity = 0);
        IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>();
        IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary);
        IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(IEqualityComparer<TKey> comparer);
        IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(int capacity);
        IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer);
        IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(int capacity, IEqualityComparer<TKey> comparer);
    }
}