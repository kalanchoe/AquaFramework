using AquaFramework.Binding;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AquaFramework.Factories
{
    public class BindableMemberFactory : IBindableMemberFactory
    {
        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>()
        {
            return new BindableDictionary<TKey, TValue>();
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            return new BindableDictionary<TKey, TValue>(dictionary);
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(IEqualityComparer<TKey> comparer)
        {
            return new BindableDictionary<TKey, TValue>(comparer);
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(int capacity)
        {
            return new BindableDictionary<TKey, TValue>(capacity);
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            return new BindableDictionary<TKey, TValue>(dictionary, comparer);
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(int capacity, IEqualityComparer<TKey> comparer)
        {
            return new BindableDictionary<TKey, TValue>(capacity, comparer);
        }

        public IBindableList<T> CreateBindableList<T>(bool loop, int maxCapacity = 0)
        {
            return new BindableList<T>(loop, maxCapacity);
        }

        public IBindableList<T> CreateBindableList<T>(IEnumerable<T> collection, bool loop, int maxCapacity = 0)
        {
            return new BindableList<T>(collection, loop, maxCapacity);
        }

        public IBindableList<T> CreateBindableList<T>(int capacity, bool loop, int maxCapacity = 0)
        {
            return new BindableList<T>(capacity, loop, maxCapacity);
        }

        public IBindableList<TCellData, TListContext> CreateBindableList<TCellData, TListContext>(bool loop, int maxCapacity = 0)
        {
            return new BindableList<TCellData, TListContext>(loop, maxCapacity);
        }

        public IBindableList<TCellData, TListContext> CreateBindableList<TCellData, TListContext>(IEnumerable<TCellData> collection, bool loop, int maxCapacity = 0)
        {
            return new BindableList<TCellData, TListContext>(collection, loop, maxCapacity);
        }

        public IBindableList<TCellData, TListContext> CreateBindableList<TCellData, TListContext>(int capacity, bool loop, int maxCapacity = 0)
        {
            return new BindableList<TCellData, TListContext>(capacity, loop, maxCapacity);
        }

        public IBindableProperty<T> CreateBindableProperty<T>()
        {
            return new BindableProperty<T>();
        }

        public IBindableProperty<T> CreateBindableProperty<T>(T value)
        {
            BindableProperty<T> bindableProperty = new BindableProperty<T>();
            bindableProperty.Value = value;
            return bindableProperty;
        }
    }
}
