using AquaFramework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaFramework.Binding
{
    class BindableList<T> : List<T>, IBindableList<T>
    {
        bool _loop;
        int _maxCapacity;

        public bool Loop { get => _loop; set => _loop = value; }
        public int MaxCapacity { get => _maxCapacity; set => _maxCapacity = value; }

        public event Action<IBindableList<T>> OnListChanged;
        public event Action<IBindableList<T>, List<T>> OnAdd;
        public event Action<IBindableList<T>, List<T>> OnRemove;

        public BindableList(bool loop, int maxCapacity)
        {
            if (loop) if (maxCapacity <= 0) throw new AquaFrameworkException("Invalid maxCapacity.");
            Loop = loop;
            MaxCapacity = maxCapacity;
        }

        public BindableList(IEnumerable<T> collection, bool loop, int maxCapacity) : base(collection)
        {
            if (loop) if (maxCapacity <= 0) throw new AquaFrameworkException("Invalid maxCapacity.");
            if (loop) if (maxCapacity < collection.Count()) throw new AquaFrameworkException("Invalid maxCapacity.");
            Loop = loop;
            MaxCapacity = maxCapacity;
        }

        public BindableList(int capacity, bool loop, int maxCapacity) : base(capacity)
        {
            if (maxCapacity <= 0) throw new AquaFrameworkException("Invalid maxCapacity.");
            if (maxCapacity < capacity) throw new AquaFrameworkException("Invalid maxCapacity.");
            Loop = loop;
            MaxCapacity = maxCapacity;
        }

        new public T this[int index]
        {
            set
            {
                List<T> remove = new List<T>();
                remove.Add(base[index]);
                base[index] = value;
                OnRemove?.Invoke(this, remove);
                List<T> add = new List<T>();
                add.Add(value);
                OnAdd?.Invoke(this, add);
                OnListChanged?.Invoke(this);
            }
            get
            {
                return base[index];
            }
        }
        new public void Add(T item)
        {
            base.Add(item);
            List<T> add = new List<T>();
            add.Add(item);
            OnAdd?.Invoke(this, add);
            if (Loop)
            {
                List<T> remove = new List<T>();
                while (Count > MaxCapacity)
                {
                    remove.Add(base[0]);
                    base.RemoveAt(0);
                }
                OnRemove?.Invoke(this, remove);
            }
            OnListChanged?.Invoke(this);
        }
        new public void AddRange(IEnumerable<T> collection)
        {
            base.AddRange(collection);
            List<T> add = new List<T>();
            add.AddRange(collection);
            OnAdd?.Invoke(this, add);
            if (Loop)
            {
                List<T> remove = new List<T>();
                while (Count > MaxCapacity)
                {
                    remove.Add(base[0]);
                    base.RemoveAt(0);
                }
                OnRemove?.Invoke(this, remove);
            }
            OnListChanged?.Invoke(this);
        }
        new public void Clear()
        {
            List<T> remove = new List<T>(this);
            base.Clear();
            OnRemove?.Invoke(this, remove);
            OnListChanged?.Invoke(this);
        }
        new public void ForEach(Action<T> action)
        {
            base.ForEach(action);
            OnListChanged?.Invoke(this);
        }
        new public void Insert(int index, T item)
        {
            base.Insert(index, item);
            List<T> add = new List<T>();
            add.Add(item);
            OnAdd?.Invoke(this, add);
            if (Loop)
            {
                List<T> remove = new List<T>();
                while (Count > MaxCapacity)
                {
                    remove.Add(base[0]);
                    base.RemoveAt(0);
                }
                OnRemove?.Invoke(this, remove);
            }
            OnListChanged?.Invoke(this);
        }
        new public void InsertRange(int index, IEnumerable<T> collection)
        {
            base.InsertRange(index, collection);
            List<T> add = new List<T>();
            add.AddRange(collection);
            OnAdd?.Invoke(this, add);
            if (Loop)
            {
                List<T> remove = new List<T>();
                while (Count > MaxCapacity)
                {
                    remove.Add(base[0]);
                    base.RemoveAt(0);
                }
                OnRemove?.Invoke(this, remove);
            }
            OnListChanged?.Invoke(this);
        }
        new public bool Remove(T item)
        {
            List<T> remove = new List<T>();
            if (Contains(item)) remove.Add(item);
            bool result = base.Remove(item);
            OnRemove?.Invoke(this, remove);
            OnListChanged?.Invoke(this);
            return result;
        }
        new public int RemoveAll(Predicate<T> match)
        {
            List<T> remove = new List<T>();
            remove.AddRange(FindAll(match));
            int reslut = base.RemoveAll(match);
            OnRemove?.Invoke(this, remove);
            OnListChanged?.Invoke(this);
            return reslut;
        }
        new public void RemoveAt(int index)
        {
            List<T> remove = new List<T>();
            remove.Add(base[index]);
            base.RemoveAt(index);
            OnRemove?.Invoke(this, remove);
            OnListChanged?.Invoke(this);
        }
        new public void RemoveRange(int index, int count)
        {
            List<T> remove = new List<T>();
            for (int i = index; i < count; i++)
            {
                remove.Add(base[i]);
            }
            base.RemoveRange(index, count);
            OnRemove?.Invoke(this, remove);
            OnListChanged?.Invoke(this);
        }
        new public void Reverse(int index, int count)
        {
            base.RemoveRange(index, count);
            OnListChanged?.Invoke(this);
        }
        new public void Reverse()
        {
            base.Reverse();
            OnListChanged?.Invoke(this);
        }
        new public void Sort(Comparison<T> comparison)
        {
            base.Sort(comparison);
            OnListChanged?.Invoke(this);
        }
        new public void Sort(int index, int count, IComparer<T> comparer)
        {
            base.Sort(index, count, comparer);
            OnListChanged?.Invoke(this);
        }
        new public void Sort()
        {
            base.Sort();
            OnListChanged?.Invoke(this);
        }
        new public void Sort(IComparer<T> comparer)
        {
            base.Sort(comparer);
            OnListChanged?.Invoke(this);
        }
    }

    class BindableList<TCellData, TListContext> : List<TCellData>, IBindableList<TCellData, TListContext>
    {
        TListContext _listContext;
        public TListContext ListContext { get => _listContext; set => _listContext = value; }
        bool _loop;
        int _maxCapacity;

        public bool Loop { get => _loop; set => _loop = value; }
        public int MaxCapacity { get => _maxCapacity; set => _maxCapacity = value; }

        public event Action<IBindableList<TCellData, TListContext>> OnListChanged;
        public event Action<IBindableList<TCellData, TListContext>, List<TCellData>> OnAdd;
        public event Action<IBindableList<TCellData, TListContext>, List<TCellData>> OnRemove;

        public BindableList(bool loop, int maxCapacity)
        {
            if (loop) if (maxCapacity <= 0) throw new AquaFrameworkException("Invalid maxCapacity.");
            Loop = loop;
            MaxCapacity = maxCapacity;
        }

        public BindableList(IEnumerable<TCellData> collection, bool loop, int maxCapacity) : base(collection)
        {
            if (loop) if (maxCapacity <= 0) throw new AquaFrameworkException("Invalid maxCapacity.");
            if (loop) if (maxCapacity < collection.Count()) throw new AquaFrameworkException("Invalid maxCapacity.");
            Loop = loop;
            MaxCapacity = maxCapacity;
        }

        public BindableList(int capacity, bool loop, int maxCapacity) : base(capacity)
        {
            if (maxCapacity <= 0) throw new AquaFrameworkException("Invalid maxCapacity.");
            if (maxCapacity < capacity) throw new AquaFrameworkException("Invalid maxCapacity.");
            Loop = loop;
            MaxCapacity = maxCapacity;
        }

        new public TCellData this[int index]
        {
            set
            {
                List<TCellData> remove = new List<TCellData>();
                remove.Add(base[index]);
                base[index] = value;
                OnRemove?.Invoke(this, remove);
                List<TCellData> add = new List<TCellData>();
                add.Add(value);
                OnAdd?.Invoke(this, add);
                OnListChanged?.Invoke(this);
            }
            get
            {
                return base[index];
            }
        }
        new public void Add(TCellData item)
        {
            base.Add(item);
            List<TCellData> add = new List<TCellData>();
            add.Add(item);
            OnAdd?.Invoke(this, add);
            if (Loop)
            {
                List<TCellData> remove = new List<TCellData>();
                while (Count > MaxCapacity)
                {
                    remove.Add(base[0]);
                    base.RemoveAt(0);
                }
                OnRemove?.Invoke(this, remove);
            }
            OnListChanged?.Invoke(this);
        }
        new public void AddRange(IEnumerable<TCellData> collection)
        {
            base.AddRange(collection);
            List<TCellData> add = new List<TCellData>();
            add.AddRange(collection);
            OnAdd?.Invoke(this, add);
            if (Loop)
            {
                List<TCellData> remove = new List<TCellData>();
                while (Count > MaxCapacity)
                {
                    remove.Add(base[0]);
                    base.RemoveAt(0);
                }
                OnRemove?.Invoke(this, remove);
            }
            OnListChanged?.Invoke(this);
        }
        new public void Clear()
        {
            List<TCellData> remove = new List<TCellData>(this);
            base.Clear();
            OnRemove?.Invoke(this, remove);
            OnListChanged?.Invoke(this);
        }
        new public void ForEach(Action<TCellData> action)
        {
            base.ForEach(action);
            OnListChanged?.Invoke(this);
        }
        new public void Insert(int index, TCellData item)
        {
            base.Insert(index, item);
            List<TCellData> add = new List<TCellData>();
            add.Add(item);
            OnAdd?.Invoke(this, add);
            if (Loop)
            {
                List<TCellData> remove = new List<TCellData>();
                while (Count > MaxCapacity)
                {
                    remove.Add(base[0]);
                    base.RemoveAt(0);
                }
                OnRemove?.Invoke(this, remove);
            }
            OnListChanged?.Invoke(this);
        }
        new public void InsertRange(int index, IEnumerable<TCellData> collection)
        {
            base.InsertRange(index, collection);
            List<TCellData> add = new List<TCellData>();
            add.AddRange(collection);
            OnAdd?.Invoke(this, add);
            if (Loop)
            {
                List<TCellData> remove = new List<TCellData>();
                while (Count > MaxCapacity)
                {
                    remove.Add(base[0]);
                    base.RemoveAt(0);
                }
                OnRemove?.Invoke(this, remove);
            }
            OnListChanged?.Invoke(this);
        }
        new public bool Remove(TCellData item)
        {
            List<TCellData> remove = new List<TCellData>();
            if (Contains(item)) remove.Add(item);
            bool result = base.Remove(item);
            OnRemove?.Invoke(this, remove);
            OnListChanged?.Invoke(this);
            return result;
        }
        new public int RemoveAll(Predicate<TCellData> match)
        {
            List<TCellData> remove = new List<TCellData>();
            remove.AddRange(FindAll(match));
            int reslut = base.RemoveAll(match);
            OnRemove?.Invoke(this, remove);
            OnListChanged?.Invoke(this);
            return reslut;
        }
        new public void RemoveAt(int index)
        {
            List<TCellData> remove = new List<TCellData>();
            remove.Add(base[index]);
            base.RemoveAt(index);
            OnRemove?.Invoke(this, remove);
            OnListChanged?.Invoke(this);
        }
        new public void RemoveRange(int index, int count)
        {
            List<TCellData> remove = new List<TCellData>();
            for (int i = index; i < count; i++)
            {
                remove.Add(base[i]);
            }
            base.RemoveRange(index, count);
            OnRemove?.Invoke(this, remove);
            OnListChanged?.Invoke(this);
        }
        new public void Reverse(int index, int count)
        {
            base.RemoveRange(index, count);
            OnListChanged?.Invoke(this);
        }
        new public void Reverse()
        {
            base.Reverse();
            OnListChanged?.Invoke(this);
        }
        new public void Sort(Comparison<TCellData> comparison)
        {
            base.Sort(comparison);
            OnListChanged?.Invoke(this);
        }
        new public void Sort(int index, int count, IComparer<TCellData> comparer)
        {
            base.Sort(index, count, comparer);
            OnListChanged?.Invoke(this);
        }
        new public void Sort()
        {
            base.Sort();
            OnListChanged?.Invoke(this);
        }
        new public void Sort(IComparer<TCellData> comparer)
        {
            base.Sort(comparer);
            OnListChanged?.Invoke(this);
        }
    }
}
