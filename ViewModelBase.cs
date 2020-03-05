using AquaFramework.Factories;
using System.Collections.Generic;
using System;
using AquaFramework.Exceptions;

namespace AquaFramework
{
    public abstract class ViewModelBase : IBindableMemberFactory
    {
        IBindableMemberFactory _bindableMemberFactory = new BindableMemberFactory();
        static List<ViewModelBase> _viewModelBases = new List<ViewModelBase>();

        protected ViewModelBase()
        {
            _viewModelBases.Add(this);
        }

        protected virtual void Show(object arg)
        {
        }

        protected virtual void Update(object arg)
        {
        }

        protected virtual void Close(object arg)
        {
        }

        protected void SetViewModel(Type type, Operation operation, object arg = null)
        {
            ViewModelBase viewModelBase = _viewModelBases.Find(x => x.GetType() == type);
            if (viewModelBase == null) throw new AquaFrameworkException("No view model of the specified type was found: " + type.ToString());
            switch (operation)
            {
                case Operation.Show:
                    viewModelBase.Show(arg);
                    break;
                case Operation.Update:
                    viewModelBase.Update(arg);
                    break;
                case Operation.Close:
                    viewModelBase.Close(arg);
                    break;
            }
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>()
        {
            return _bindableMemberFactory.CreateBindableDictionary<TKey, TValue>();
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            return _bindableMemberFactory.CreateBindableDictionary(dictionary);
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(IEqualityComparer<TKey> comparer)
        {
            return _bindableMemberFactory.CreateBindableDictionary<TKey, TValue>(comparer);
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(int capacity)
        {
            return _bindableMemberFactory.CreateBindableDictionary<TKey, TValue>(capacity);
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            return _bindableMemberFactory.CreateBindableDictionary(dictionary, comparer);
        }

        public IBindableDictionary<TKey, TValue> CreateBindableDictionary<TKey, TValue>(int capacity, IEqualityComparer<TKey> comparer)
        {
            return _bindableMemberFactory.CreateBindableDictionary<TKey, TValue>(capacity, comparer);
        }

        public IBindableList<T> CreateBindableList<T>(bool loop, int maxCapacity = 0)
        {
            return _bindableMemberFactory.CreateBindableList<T>(loop, maxCapacity);
        }

        public IBindableList<T> CreateBindableList<T>(IEnumerable<T> collection, bool loop, int maxCapacity = 0)
        {
            return _bindableMemberFactory.CreateBindableList(collection, loop, maxCapacity);
        }

        public IBindableList<T> CreateBindableList<T>(int capacity, bool loop, int maxCapacity = 0)
        {
            return _bindableMemberFactory.CreateBindableList<T>(capacity, loop, maxCapacity);
        }

        public IBindableList<TCellData, TListContext> CreateBindableList<TCellData, TListContext>(bool loop, int maxCapacity = 0)
        {
            return _bindableMemberFactory.CreateBindableList<TCellData, TListContext>(loop, maxCapacity);
        }

        public IBindableList<TCellData, TListContext> CreateBindableList<TCellData, TListContext>(IEnumerable<TCellData> collection, bool loop, int maxCapacity = 0)
        {
            return _bindableMemberFactory.CreateBindableList<TCellData, TListContext>(collection, loop, maxCapacity);
        }

        public IBindableList<TCellData, TListContext> CreateBindableList<TCellData, TListContext>(int capacity, bool loop, int maxCapacity = 0)
        {
            return _bindableMemberFactory.CreateBindableList<TCellData, TListContext>(capacity, loop, maxCapacity);
        }

        public IBindableProperty<T> CreateBindableProperty<T>()
        {
            return _bindableMemberFactory.CreateBindableProperty<T>();
        }

        public IBindableProperty<T> CreateBindableProperty<T>(T value)
        {
            return _bindableMemberFactory.CreateBindableProperty(value);
        }
    }
}
