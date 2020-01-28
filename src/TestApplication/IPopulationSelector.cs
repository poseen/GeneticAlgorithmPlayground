using System;

namespace TestApplication
{
    public interface IPopulationSelector<TSpecimen, TWeight> where TWeight : IComparable<TWeight>
    {
        void NaturalSelection(ref IWeightedList<TSpecimen, TWeight> population);
    }
}
