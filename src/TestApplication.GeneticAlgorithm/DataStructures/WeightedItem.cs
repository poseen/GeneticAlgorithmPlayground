using System;

namespace TestApplication.GeneticAlgorithm.DataStructures
{
    public class WeightedItem<TItem, TWeight> : IComparable<WeightedItem<TItem, TWeight>>
        where TWeight : IComparable<TWeight>
    {
        public WeightedItem(TItem item, TWeight weight)
        {
            Item = item;
            Weight = weight;
        }

        public TItem Item { get; set; }

        public TWeight Weight { get; set; }

        public int CompareTo(WeightedItem<TItem, TWeight> other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }
}
