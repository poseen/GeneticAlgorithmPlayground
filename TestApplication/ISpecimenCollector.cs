using System.Collections.Generic;

namespace TestApplication
{
    public interface ISpecimenCollector<TSpecimen>
    {
        void Add(TSpecimen specimen);
        void AddRange(IEnumerable<TSpecimen> specimens);
        void Clear();
        IReadOnlyCollection<TSpecimen> GetSpecimens();
    }
}
