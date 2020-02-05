using System;
using System.Linq;
using TestApplication.GeneticAlgorithm.DataStructures;
using TestApplication.GeneticAlgorithm.Interfaces;

namespace TestApplication.UI.ConcreteImplementation
{
    public class ConcretePopulationMutator : IPopulationMutator<ConcreteSpecimen>
    {
        private readonly double _mutationProbability = 0.09016994374d; // phi ^(-5)
        private readonly Random random = new Random();

        public ConcretePopulationMutator()
        {
        }

        private int iteration = 0;

        public void Mutate(ref IWeightedList<ConcreteSpecimen> population)
        {
            // Mutate
            var numberOfMutableProperties = 1;
            var totalNumberOfMutableProperties = population.Count * numberOfMutableProperties; // population size * number of mutable properties.

            var indexes = Enumerable.Range(0, totalNumberOfMutableProperties)
                                    .OrderBy(x => Guid.NewGuid())
                                    .Take((int)Math.Floor(_mutationProbability * totalNumberOfMutableProperties));

            iteration = (iteration + 1) % 10;

            var strength = Math.Sin((iteration / 10.0d) * Math.PI);

            var mutationFactorX = strength * (random.Next(0, 2) == 0 ? -1 : 1) * random.NextDouble() * 10d;

            foreach (var idx in indexes)
            {
                var cellIndex = idx / numberOfMutableProperties;
                var propertyIndex = idx % numberOfMutableProperties;

                var specimen = population[cellIndex].Item;

                var x = specimen.X;

                switch (propertyIndex)
                {
                    case 0: x = x + mutationFactorX; break;
                    default: throw new ArgumentOutOfRangeException(nameof(propertyIndex));
                }

                var mutatedSpecimen = new ConcreteSpecimen(x);

                population[cellIndex] = new WeightedItem<ConcreteSpecimen>(mutatedSpecimen, 0);
            }
        }
    }
}
