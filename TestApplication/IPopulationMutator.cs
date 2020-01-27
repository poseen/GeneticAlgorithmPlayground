using System;

namespace TestApplication
{
    public interface IPopulationMutator<TSpecimen, TWeight> where TWeight : IComparable<TWeight>
    {
        void Mutate(ref IWeightedList<TSpecimen, TWeight> population);
    }
}
