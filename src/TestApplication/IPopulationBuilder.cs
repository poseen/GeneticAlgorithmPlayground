using System;

namespace TestApplication
{
    public interface IPopulationBuilder<TSpecimen, TWeight> where TWeight : IComparable<TWeight>
    {
        IWeightedList<TSpecimen, TWeight> Build(int sizeOfStarterPopulation);
    }
}
