using AquaFramework.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AquaFramework.Binding
{
    class BindableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IBindableDictionary<TKey, TValue>
    {

        public BindableDictionary()
        {
        }

        public BindableDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary)
        {
        }

        public BindableDictionary(IEqualityComparer<TKey> comparer) : base(comparer)
        {
        }

        public BindableDictionary(int capacity) : base(capacity)
        {
        }

        public BindableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) : base(dictionary, comparer)
        {
        }

        public BindableDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(capacity, comparer)
        {
        }

        protected BindableDictionary(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public event Action<IBindableDictionary<TKey, TValue>> OnDictionaryChanged;
        public event Action<IBindableDictionary<TKey, TValue>, Dictionary<TKey, TValue>> OnAdd;
        public event Action<IBindableDictionary<TKey, TValue>, Dictionary<TKey, TValue>> OnRemove;

        new public TValue this[TKey key]
        {
            set
            {
                if (!base.ContainsKey(key)) throw new AquaFrameworkException("Invalid key.");
                Dictionary<TKey, TValue> remove = new Dictionary<TKey, TValue>();
                Dictionary<TKey, TValue> add = new Dictionary<TKey, TValue>();
                remove.Add(key, base[key]);
                base[key] = value;
                add.Add(key, value);
                OnRemove?.Invoke(this, remove);
                OnAdd?.Invoke(this, add);
                OnDictionaryChanged?.Invoke(this);
            }
            get
            {
                return base[key];
            }
        }
        new public void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            Dictionary<TKey, TValue> add = new Dictionary<TKey, TValue>();
            add.Add(key, value);
            OnAdd?.Invoke(this, add);
            OnDictionaryChanged?.Invoke(this);
        }
        new public void Clear()
        {
            Dictionary<TKey, TValue> remove = new Dictionary<TKey, TValue>(this);
            base.Clear();
            OnRemove?.Invoke(this, remove);
            OnDictionaryChanged?.Invoke(this);
        }
        new public bool Remove(TKey key)
        {
            Dictionary<TKey, TValue> remove = new Dictionary<TKey, TValue>();
            if (base.ContainsKey(key)) remove.Add(key, base[key]);
            bool result = base.Remove(key);
            OnRemove?.Invoke(this, remove);
            OnDictionaryChanged?.Invoke(this);
            return result;
        }
    }
}
