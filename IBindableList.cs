using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AquaFramework
{
    public interface IBindableList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IList<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection, IList
    {
        event Action<IBindableList<T>> OnListChanged;
        event Action<IBindableList<T>, List<T>> OnAdd;
        event Action<IBindableList<T>, List<T>> OnRemove;

        bool Loop { get; }
        int MaxCapacity { get; }

        new T this[int index] { get; set; }

        new int Count { get; }
        int Capacity { get; set; }

        new void Add(T item);
        void AddRange(IEnumerable<T> collection);
        ReadOnlyCollection<T> AsReadOnly();
        int BinarySearch(T item);
        int BinarySearch(T item, IComparer<T> comparer);
        int BinarySearch(int index, int count, T item, IComparer<T> comparer);
        new void Clear();
        new bool Contains(T item);
        List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter);
        void CopyTo(int index, T[] array, int arrayIndex, int count);
        new void CopyTo(T[] array, int arrayIndex);
        void CopyTo(T[] array);
        bool Exists(Predicate<T> match);
        T Find(Predicate<T> match);
        List<T> FindAll(Predicate<T> match);
        int FindIndex(int startIndex, int count, Predicate<T> match);
        int FindIndex(int startIndex, Predicate<T> match);
        int FindIndex(Predicate<T> match);
        T FindLast(Predicate<T> match);
        int FindLastIndex(int startIndex, int count, Predicate<T> match);
        int FindLastIndex(int startIndex, Predicate<T> match);
        int FindLastIndex(Predicate<T> match);
        void ForEach(Action<T> action);
        new List<T>.Enumerator GetEnumerator();
        List<T> GetRange(int index, int count);
        int IndexOf(T item, int index, int count);
        int IndexOf(T item, int index);
        new int IndexOf(T item);
        new void Insert(int index, T item);
        void InsertRange(int index, IEnumerable<T> collection);
        int LastIndexOf(T item);
        int LastIndexOf(T item, int index);
        int LastIndexOf(T item, int index, int count);
        new bool Remove(T item);
        int RemoveAll(Predicate<T> match);
        new void RemoveAt(int index);
        void RemoveRange(int index, int count);
        void Reverse(int index, int count);
        void Reverse();
        void Sort(Comparison<T> comparison);
        void Sort(int index, int count, IComparer<T> comparer);
        void Sort();
        void Sort(IComparer<T> comparer);
        T[] ToArray();
        void TrimExcess();
        bool TrueForAll(Predicate<T> match);
    }

    public interface IBindableList<TCellData, TListContext> : ICollection<TCellData>, IEnumerable<TCellData>, IEnumerable, IList<TCellData>, IReadOnlyCollection<TCellData>, IReadOnlyList<TCellData>, ICollection, IList
    {
        TListContext ListContext { set; get; }

        event Action<IBindableList<TCellData, TListContext>> OnListChanged;
        event Action<IBindableList<TCellData, TListContext>, List<TCellData>> OnAdd;
        event Action<IBindableList<TCellData, TListContext>, List<TCellData>> OnRemove;

        bool Loop { get; }
        int MaxCapacity { get; }

        new TCellData this[int index] { get; set; }

        new int Count { get; }
        int Capacity { get; set; }

        new void Add(TCellData item);
        void AddRange(IEnumerable<TCellData> collection);
        ReadOnlyCollection<TCellData> AsReadOnly();
        int BinarySearch(TCellData item);
        int BinarySearch(TCellData item, IComparer<TCellData> comparer);
        int BinarySearch(int index, int count, TCellData item, IComparer<TCellData> comparer);
        new void Clear();
        new bool Contains(TCellData item);
        List<TOutput> ConvertAll<TOutput>(Converter<TCellData, TOutput> converter);
        void CopyTo(int index, TCellData[] array, int arrayIndex, int count);
        new void CopyTo(TCellData[] array, int arrayIndex);
        void CopyTo(TCellData[] array);
        bool Exists(Predicate<TCellData> match);
        TCellData Find(Predicate<TCellData> match);
        List<TCellData> FindAll(Predicate<TCellData> match);
        int FindIndex(int startIndex, int count, Predicate<TCellData> match);
        int FindIndex(int startIndex, Predicate<TCellData> match);
        int FindIndex(Predicate<TCellData> match);
        TCellData FindLast(Predicate<TCellData> match);
        int FindLastIndex(int startIndex, int count, Predicate<TCellData> match);
        int FindLastIndex(int startIndex, Predicate<TCellData> match);
        int FindLastIndex(Predicate<TCellData> match);
        void ForEach(Action<TCellData> action);
        new List<TCellData>.Enumerator GetEnumerator();
        List<TCellData> GetRange(int index, int count);
        int IndexOf(TCellData item, int index, int count);
        int IndexOf(TCellData item, int index);
        new int IndexOf(TCellData item);
        new void Insert(int index, TCellData item);
        void InsertRange(int index, IEnumerable<TCellData> collection);
        int LastIndexOf(TCellData item);
        int LastIndexOf(TCellData item, int index);
        int LastIndexOf(TCellData item, int index, int count);
        new bool Remove(TCellData item);
        int RemoveAll(Predicate<TCellData> match);
        new void RemoveAt(int index);
        void RemoveRange(int index, int count);
        void Reverse(int index, int count);
        void Reverse();
        void Sort(Comparison<TCellData> comparison);
        void Sort(int index, int count, IComparer<TCellData> comparer);
        void Sort();
        void Sort(IComparer<TCellData> comparer);
        TCellData[] ToArray();
        void TrimExcess();
        bool TrueForAll(Predicate<TCellData> match);
    }
}
