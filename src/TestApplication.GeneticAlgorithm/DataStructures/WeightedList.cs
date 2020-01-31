using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestApplication.GeneticAlgorithm.DataStructures
{
    public class WeightedList<TSpecimen> : IWeightedList<TSpecimen>
    {
        private readonly List<WeightedItem<TSpecimen>> _internalList;

        public WeightedList()
        {
            _internalList = new List<WeightedItem<TSpecimen>>();
        }

        public WeightedList(int capacity)
        {
            _internalList = new List<WeightedItem<TSpecimen>>(capacity);
        }

        public WeightedList(IEnumerable<TSpecimen> items)
        {
            _internalList = new List<WeightedItem<TSpecimen>>(items.Select(x => new WeightedItem<TSpecimen>(x, default)));
        }

        public WeightedList(IEnumerable<WeightedItem<TSpecimen>> items)
        {
            _internalList = new List<WeightedItem<TSpecimen>>(items);
        }

        public WeightedItem<TSpecimen> this[int index] 
        { 
            get => _internalList[index];
            set => _internalList[index] = value;
        }

        public int Count => _internalList.Count;

        public void Add(WeightedItem<TSpecimen> item)
        {
            _internalList.Add(item);
        }

        public IEnumerator<WeightedItem<TSpecimen>> GetEnumerator()
        {
            return _internalList.GetEnumerator();
        }

        public void Clear()
        {
            _internalList.Clear();
        }

        public bool Contains(WeightedItem<TSpecimen> item)
        {
            return _internalList.Contains(item);
        }

        public void CopyTo(WeightedItem<TSpecimen>[] array, int arrayIndex)
        {
            _internalList.CopyTo(array, arrayIndex);
        }

        public int IndexOf(WeightedItem<TSpecimen> item)
        {
            return _internalList.IndexOf(item);
        }

        public void Insert(int index, WeightedItem<TSpecimen> item)
        {
            _internalList.Insert(index, item);
        }

        public bool Remove(WeightedItem<TSpecimen> item)
        {
            return _internalList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _internalList.RemoveAt(index);
        }

        public TSpecimen WeightedRandom()
        {
            if(!_internalList.Any())
            {
                return default;
            }

            const int maxRounds = 4;
            var rounds = 0;

            var random = new Random();

            // This is the item we return if we couldn't find any in the roulette...
            var finalItem = _internalList[random.Next(0, _internalList.Count)].Item;

            var minWeight = _internalList.Min(x => x.Weight);
            var maxWeight = _internalList.Max(x => x.Weight);
            var diffWeight = maxWeight - minWeight;
            
            var enumerator = _internalList.GetEnumerator();
            enumerator.MoveNext();

            while (true)
            {
                if (rounds >= maxRounds)
                {
                    return finalItem;
                }

                // Try to move to the next. If we are at the end of the list, we go again.
                if (!enumerator.MoveNext())
                {
                    rounds++;
                    enumerator.MoveNext();
                }

                var p = minWeight + random.NextDouble() * diffWeight;
                if(enumerator.Current.Weight < p)
                {
                    return enumerator.Current.Item;
                }
            }
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

        bool ICollection<WeightedItem<TSpecimen>>.IsReadOnly => ((ICollection<WeightedItem<TSpecimen>>)_internalList).IsReadOnly;

        #endregion

        #region IEnumerator overrides

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_internalList).GetEnumerator();
        }

        #endregion
    }
}
