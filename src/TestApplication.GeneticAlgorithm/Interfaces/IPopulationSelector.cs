using System;
using TestApplication.GeneticAlgorithm.DataStructures;

namespace TestApplication.GeneticAlgorithm.Interfaces
{
    public interface IPopulationSelector<TSpecimen>
    {
        void NaturalSelection(ref IWeightedList<TSpecimen> population);
    }
}
