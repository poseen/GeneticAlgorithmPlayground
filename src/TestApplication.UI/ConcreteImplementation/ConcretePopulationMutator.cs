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
            var totalNumberOfMutableProperties = population.Count * 2; // population size * number of mutable properties.

            var indexes = Enumerable.Range(0, totalNumberOfMutableProperties)
                                    .OrderBy(x => Guid.NewGuid())
                                    .Take((int)Math.Floor(_mutationProbability * totalNumberOfMutableProperties));

            iteration = (iteration + 1) % 10;

            var strength = Math.Sin((iteration / 10.0d) * Math.PI);

            var mutationFactorX = strength * (random.Next(0, 2) == 0 ? -1 : 1) * random.NextDouble() * 10d;
            var mutationFactorY = strength * (random.Next(0, 2) == 0 ? -1 : 1) * random.NextDouble() * 10d;

            foreach (var idx in indexes)
            {
                var cellIndex = idx / 2;
                var propertyIndex = idx % 2;

                var specimen = population[cellIndex].Item;

                var x = specimen.X;
                var y = specimen.Y;

                switch (propertyIndex)
                {
                    case 0: x = x + mutationFactorX; break;
                    case 1: y = y + mutationFactorY; break;
                    default: throw new ArgumentOutOfRangeException(nameof(propertyIndex));
                }

                var mutatedSpecimen = new ConcreteSpecimen(x, y);

                population[cellIndex] = new WeightedItem<ConcreteSpecimen>(mutatedSpecimen, 0);
            }
        }
    }
}
