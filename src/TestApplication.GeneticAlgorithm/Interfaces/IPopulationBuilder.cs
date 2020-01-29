using System;
using TestApplication.GeneticAlgorithm.DataStructures;

namespace TestApplication.GeneticAlgorithm.Interfaces
{
    public interface IPopulationBuilder<TSpecimen, TWeight> where TWeight : IComparable<TWeight>
    {
        IWeightedList<TSpecimen, TWeight> Build(int sizeOfStarterPopulation);
    }
}
