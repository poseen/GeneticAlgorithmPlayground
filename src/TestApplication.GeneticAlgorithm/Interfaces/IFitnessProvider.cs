using System;
using System.Collections.Generic;
using TestApplication.GeneticAlgorithm.DataStructures;

namespace TestApplication.GeneticAlgorithm.Interfaces
{
    public interface IFitnessProvider<TSpecimen>
    {
        void ReCalculateFitness(ref IWeightedList<TSpecimen> population);
    }
}
