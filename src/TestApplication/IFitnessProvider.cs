using System;
using System.Collections.Generic;

namespace TestApplication
{
    public interface IFitnessProvider<TSpecimen, TWeight>
        where TWeight : IComparable<TWeight>
    {
        void ReCalculateFitness(ref IWeightedList<TSpecimen, TWeight> population);

        ICollection<TSpecimen> GetAcceptableSpecimens(IWeightedList<TSpecimen, TWeight> population);
    }
}
