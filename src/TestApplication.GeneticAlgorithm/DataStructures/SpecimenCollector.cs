using System.Collections.Generic;
using System.Linq;
using TestApplication.GeneticAlgorithm.DataStructures;

namespace TestApplication.GeneticAlgorithm
{
    public class SpecimenCollector<TSpecimen> : ISpecimenCollector<TSpecimen>
    {
        private readonly HashSet<TSpecimen> _resultSet = new HashSet<TSpecimen>();

        public void Add(TSpecimen specimen)
        {
            _resultSet.Add(specimen);
        }

        public void AddRange(IEnumerable<TSpecimen> specimens)
        {
            foreach (var item in specimens)
            {
                _resultSet.Add(item);
            }
        }

        public void Clear()
        {
            _resultSet.Clear();
        }

        public IReadOnlyCollection<TSpecimen> GetSpecimens()
        {
            return _resultSet.ToList().AsReadOnly();
        }
    }
}
