using System;
using System.Collections.Generic;
using System.Linq;
using TestApplication.GeneticAlgorithm.DataStructures;

namespace TestApplication.UI.ConcreteImplementation
{
    public static class Extensions
    {
        public static bool Equals5Precision(this double a, double b)
        {
            return Math.Abs(a - b) < 0.00001d;
        }

        public static WeightedItem<T> WeightedRandom<T>(this IEnumerable<WeightedItem<T>> _internalList)
        {
            if (!_internalList.Any())
            {
                return default;
            }

            var random = new Random();
            var cumSum = _internalList.Sum(x => x.Weight);
            var p = random.NextDouble() * cumSum;
            var enumerator = _internalList.GetEnumerator();
            enumerator.Reset();
            enumerator.MoveNext();

            double previousItemSumProbability = 0;
            WeightedItem<T> currentItem;
            double currentItemSumProbability = 0;

            do
            {
                previousItemSumProbability = currentItemSumProbability;
                currentItem = enumerator.Current;
                currentItemSumProbability = previousItemSumProbability + currentItem.Weight;

                if (previousItemSumProbability <= p && p <= currentItemSumProbability)
                {
                    break;
                }

            } while (enumerator.MoveNext());

            return enumerator.Current;
        }
    }
}
