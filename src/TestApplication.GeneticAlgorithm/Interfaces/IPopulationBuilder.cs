using System;
using TestApplication.GeneticAlgorithm.DataStructures;

namespace TestApplication.GeneticAlgorithm.Interfaces
{
    public interface IPopulationBuilder<TSpecimen>
    {
        IWeightedList<TSpecimen> Build(int sizeOfStarterPopulation);
    }
}
