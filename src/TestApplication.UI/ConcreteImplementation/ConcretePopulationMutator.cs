using System;
using System.Linq;
using TestApplication.GeneticAlgorithm.DataStructures;
using TestApplication.GeneticAlgorithm.Interfaces;

namespace TestApplication.UI.ConcreteImplementation
{
    public class ConcretePopulationMutator : IPopulationMutator<ConcreteSpecimen, double>
    {
        private readonly double _mutationProbability = 0.09016994374d; // phi ^(-5)
        private readonly Random random = new Random();

        public ConcretePopulationMutator()
        {
        }

        public void Mutate(ref IWeightedList<ConcreteSpecimen, double> population)
        {
            // Mutate
            var totalNumberOfMutableProperties = population.Count * 2; // population size * number of mutable properties.

            var indexes = Enumerable.Range(0, totalNumberOfMutableProperties)
                                    .OrderBy(x => Guid.NewGuid())
                                    .Take((int)Math.Floor(_mutationProbability * totalNumberOfMutableProperties));

            foreach (var idx in indexes)
            {
                var cellIndex = idx / 2;
                var propertyIndex = idx % 2;

                var specimen = population[cellIndex].Item;

                var x = specimen.X;
                var y = specimen.Y;

                switch (propertyIndex)
                {
                    case 0: x = -2 + random.NextDouble() * 4; break;
                    case 1: y = -2 + random.NextDouble() * 4; break;
                    default: throw new ArgumentOutOfRangeException(nameof(propertyIndex));
                }

                var mutatedSpecimen = new ConcreteSpecimen(x, y);

                population[cellIndex] = new WeightedItem<ConcreteSpecimen, double>(mutatedSpecimen, 0);
            }
        }
    }
}
