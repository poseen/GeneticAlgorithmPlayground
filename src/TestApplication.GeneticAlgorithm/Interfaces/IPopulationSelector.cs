using System;
using TestApplication.GeneticAlgorithm.DataStructures;

namespace TestApplication.GeneticAlgorithm.Interfaces
{
    public interface IPopulationSelector<TSpecimen, TWeight> where TWeight : IComparable<TWeight>
    {
        void NaturalSelection(ref IWeightedList<TSpecimen, TWeight> population);
    }
}
