using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestApplication
{
    public class WeightedList<TSpecimen, TWeight> : IWeightedList<TSpecimen, TWeight>
        where TWeight : IComparable<TWeight>
    {
        private readonly List<WeightedItem<TSpecimen, TWeight>> _internalList;

        public WeightedList()
        {
            _internalList = new List<WeightedItem<TSpecimen, TWeight>>();
        }

        public WeightedList(int capacity)
        {
            _internalList = new List<WeightedItem<TSpecimen, TWeight>>(capacity);
        }

        public WeightedList(IEnumerable<TSpecimen> items)
        {
            _internalList = new List<WeightedItem<TSpecimen, TWeight>>(items.Select(x => new WeightedItem<TSpecimen, TWeight>(x, default(TWeight))));
        }

        public WeightedList(IEnumerable<WeightedItem<TSpecimen, TWeight>> items)
        {
            _internalList = new List<WeightedItem<TSpecimen, TWeight>>(items);
        }

        public WeightedItem<TSpecimen, TWeight> this[int index] 
        { 
            get => _internalList[index];
            set => _internalList[index] = value;
        }

        public int Count => _internalList.Count;

        public void Add(WeightedItem<TSpecimen, TWeight> item)
        {
            _internalList.Add(item);
        }

        public IEnumerator<WeightedItem<TSpecimen, TWeight>> GetEnumerator()
        {
            return _internalList.GetEnumerator();
        }

        public void Clear()
        {
            _internalList.Clear();
        }

        public bool Contains(WeightedItem<TSpecimen, TWeight> item)
        {
            return _internalList.Contains(item);
        }

        public void CopyTo(WeightedItem<TSpecimen, TWeight>[] array, int arrayIndex)
        {
            _internalList.CopyTo(array, arrayIndex);
        }

        public int IndexOf(WeightedItem<TSpecimen, TWeight> item)
        {
            return _internalList.IndexOf(item);
        }

        public void Insert(int index, WeightedItem<TSpecimen, TWeight> item)
        {
            _internalList.Insert(index, item);
        }

        public bool Remove(WeightedItem<TSpecimen, TWeight> item)
        {
            return _internalList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _internalList.RemoveAt(index);
        }

        #region IList overrides
        object IList.this[int index]
        {
            get => ((IList)_internalList)[index];
            set => ((IList)_internalList)[index] = value;
        }

        bool IList.IsReadOnly => ((IList)_internalList).IsReadOnly;

        bool IList.IsFixedSize => ((IList)_internalList).IsFixedSize;

        int IList.Add(object value)
        {
            return ((IList)_internalList).Add(value);
        }

        bool IList.Contains(object value)
        {
            return ((IList)_internalList).Contains(value);
        }

        int IList.IndexOf(object value)
        {
            return ((IList)_internalList).IndexOf(value);
        }

        void IList.Insert(int index, object value)
        {
            ((IList)_internalList).Insert(index, value);
        }

        void IList.Remove(object value)
        {
            ((IList)_internalList).Remove(value);
        }

        #endregion

        #region ICollection and ICollection<.> overrides

        int ICollection.Count => _internalList.Count;

        bool ICollection.IsSynchronized => ((ICollection)_internalList).IsSynchronized;

        object ICollection.SyncRoot => ((ICollection)_internalList).SyncRoot;

        void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection)_internalList).CopyTo(array, index);
        }

        bool ICollection<WeightedItem<TSpecimen, TWeight>>.IsReadOnly => ((ICollection<WeightedItem<TSpecimen, TWeight>>)_internalList).IsReadOnly;

        #endregion

        #region IEnumerator overrides

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_internalList).GetEnumerator();
        }

        #endregion
    }
}
