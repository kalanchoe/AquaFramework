using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AquaFramework
{
    public interface IBindableDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IReadOnlyDictionary<TKey, TValue>, ICollection, IDictionary, IDeserializationCallback, ISerializable
    {
        event Action<IBindableDictionary<TKey, TValue>> OnDictionaryChanged;
        event Action<IBindableDictionary<TKey, TValue>, Dictionary<TKey, TValue>> OnAdd;
        event Action<IBindableDictionary<TKey, TValue>, Dictionary<TKey, TValue>> OnRemove;

        new TValue this[TKey key] { get; set; }

        new Dictionary<TKey, TValue>.ValueCollection Values { get; }
        new Dictionary<TKey, TValue>.KeyCollection Keys { get; }
        new int Count { get; }
        IEqualityComparer<TKey> Comparer { get; }

        new void Add(TKey key, TValue value);
        new void Clear();
        new bool ContainsKey(TKey key);
        bool ContainsValue(TValue value);
        new Dictionary<TKey, TValue>.Enumerator GetEnumerator();
        new bool Remove(TKey key);
        new bool TryGetValue(TKey key, out TValue value);
    }
}
