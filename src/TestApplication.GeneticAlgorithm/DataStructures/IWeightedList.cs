using System;
using System.Collections;
using System.Collections.Generic;

namespace TestApplication.GeneticAlgorithm.DataStructures
{
    public interface IWeightedList<TSpecimen, TWeight> : ICollection<WeightedItem<TSpecimen, TWeight>>, IEnumerable<WeightedItem<TSpecimen, TWeight>>, IEnumerable, IList<WeightedItem<TSpecimen, TWeight>>, IReadOnlyCollection<WeightedItem<TSpecimen, TWeight>>, IReadOnlyList<WeightedItem<TSpecimen, TWeight>>, ICollection, IList
        where TWeight : IComparable<TWeight>
    {
        /// <summary>
        /// Gets a value indication the number of elements contained in the population.
        /// </summary>
        /// <remarks>
        /// This is needed otherwise call to this <see cref="Count" /> will be ambigious between <see cref="ICollection.Count" /> and <see cref="ICollection{T}.Count" />.
        /// </remarks>
        new int Count { get; }

        /// <summary>
        /// Removes all items from the population.
        /// </summary>
        /// <remarks>
        /// This is needed otherwise call to this <see cref="Clear" /> will be ambigious between <see cref="IList.Clear" /> and <see cref="ICollection{T}.Clear" />.
        /// </remarks>
        new void Clear();

        /// <summary>
        /// Indexer operator.
        /// </summary>
        /// <remarks>
        /// This is needed otherwise call to this operator will be ambigious between<see cref="IList" /> and <see cref="IList{T}" />.
        /// </remarks>
        new WeightedItem<TSpecimen, TWeight> this[int index] { get; set; }
    }
}
