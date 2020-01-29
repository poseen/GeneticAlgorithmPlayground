using System.Collections.Generic;

namespace TestApplication.GeneticAlgorithm.DataStructures
{
    public interface ISpecimenCollector<TSpecimen>
    {
        void Add(TSpecimen specimen);
        void AddRange(IEnumerable<TSpecimen> specimens);
        void Clear();
        IReadOnlyCollection<TSpecimen> GetSpecimens();
    }
}
