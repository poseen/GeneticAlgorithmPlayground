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

        private int iterations = 0;

        public void Mutate(ref IWeightedList<ConcreteSpecimen> population)
        {
            iterations = (iterations + 1) % 10;

            if(iterations != 0)
            {
                return;
            }

            // Mutate
            var totalNumberOfMutableProperties = population.Count * 2; // population size * number of mutable properties.

            var indexes = Enumerable.Range(0, totalNumberOfMutableProperties)
                                    .OrderBy(x => Guid.NewGuid())
                                    .Take((int)Math.Floor(_mutationProbability * totalNumberOfMutableProperties));

            
            var mutationX = (random.Next(0, 2) == 0 ? -1 : 1) * random.NextDouble() * 10;
            var mutationY = (random.Next(0, 2) == 0 ? -1 : 1) * random.NextDouble() * 10;

            foreach (var idx in indexes)
            {
                var cellIndex = idx / 2;
                var propertyIndex = idx % 2;

                var specimen = population[cellIndex].Item;

                var x = specimen.X;
                var y = specimen.Y;


                switch (propertyIndex)
                {
                    case 0: x = x + mutationX; break;
                    case 1: y = y + mutationY; break;
                    default: throw new ArgumentOutOfRangeException(nameof(propertyIndex));
                }

                var mutatedSpecimen = new ConcreteSpecimen(x, y);

                population[cellIndex] = new WeightedItem<ConcreteSpecimen>(mutatedSpecimen, 0);
            }
        }
    }
}
