using System;

namespace TestApplication.GeneticAlgorithm.DataStructures
{
    public class WeightedItem<TItem> : IComparable<WeightedItem<TItem>>
    {
        public WeightedItem(TItem item, double weight)
        {
            Item = item;
            Weight = weight;
        }

        public TItem Item { get; set; }

        public double Weight { get; set; }

        public int CompareTo(WeightedItem<TItem> other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }
}
