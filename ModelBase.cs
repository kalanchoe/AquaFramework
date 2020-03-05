using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaFramework.Factories;

namespace AquaFramework
{
    public class ModelBase : IBindableMemberFactory
    {
        IBindableMemberFactory bindableMemberFactory = new BindableMemberFactory();

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>()
        {
            return bindableMemberFactory.CreateBindableDictionary<TKey, TValue>();
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            return bindableMemberFactory.CreateBindableDictionary(dictionary);
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(IEqualityComparer<TKey> comparer)
        {
            return bindableMemberFactory.CreateBindableDictionary<TKey, TValue>(comparer);
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(int capacity)
        {
            return bindableMemberFactory.CreateBindableDictionary<TKey, TValue>(capacity);
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            return bindableMemberFactory.CreateBindableDictionary(dictionary, comparer);
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(int capacity, IEqualityComparer<TKey> comparer)
        {
            return bindableMemberFactory.CreateBindableDictionary<TKey, TValue>(capacity, comparer);
        }

        public IBindableList<T> CreateBindableList<T>(bool loop, int maxCapacity = 0)
        {
            return bindableMemberFactory.CreateBindableList<T>(loop, maxCapacity);
        }

        public IBindableList<T> CreateBindableList<T>(IEnumerable<T> collection, bool loop, int maxCapacity = 0)
        {
            return bindableMemberFactory.CreateBindableList(collection, loop, maxCapacity);
        }

        public IBindableList<T> CreateBindableList<T>(int capacity, bool loop, int maxCapacity = 0)
        {
            return bindableMemberFactory.CreateBindableList<T>(capacity, loop, maxCapacity);
        }

        public IBindableList<TCellData, TListContext> CreateBindableList<TCellData, TListContext>(bool loop, int maxCapacity = 0)
        {
            return bindableMemberFactory.CreateBindableList<TCellData, TListContext>(loop, maxCapacity);
        }

        public IBindableList<TCellData, TListContext> CreateBindableList<TCellData, TListContext>(IEnumerable<TCellData> collection, bool loop, int maxCapacity = 0)
        {
            return bindableMemberFactory.CreateBindableList<TCellData, TListContext>(collection, loop, maxCapacity);
        }

        public IBindableList<TCellData, TListContext> CreateBindableList<TCellData, TListContext>(int capacity, bool loop, int maxCapacity = 0)
        {
            return bindableMemberFactory.CreateBindableList<TCellData, TListContext>(capacity, loop, maxCapacity);
        }

        public IBindableProperty<T> CreateBindableProperty<T>()
        {
            return bindableMemberFactory.CreateBindableProperty<T>();
        }

        public IBindableProperty<T> CreateBindableProperty<T>(T value)
        {
            return bindableMemberFactory.CreateBindableProperty(value);
        }
    }
}
