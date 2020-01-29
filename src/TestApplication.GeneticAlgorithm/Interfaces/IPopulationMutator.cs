using System;
using TestApplication.GeneticAlgorithm.DataStructures;

namespace TestApplication.GeneticAlgorithm.Interfaces
{
    public interface IPopulationMutator<TSpecimen, TWeight> where TWeight : IComparable<TWeight>
    {
        void Mutate(ref IWeightedList<TSpecimen, TWeight> population);
    }
}
