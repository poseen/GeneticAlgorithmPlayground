using System;
using TestApplication.GeneticAlgorithm.DataStructures;

namespace TestApplication.GeneticAlgorithm.Interfaces
{
    public interface IPopulationMutator<TSpecimen>
    {
        void Mutate(ref IWeightedList<TSpecimen> population);
    }
}
