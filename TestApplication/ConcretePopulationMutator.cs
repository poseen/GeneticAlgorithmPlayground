using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApplication
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
            var totalNumberOfMutableProperties = population.Count * 4; // population size * number of mutable properties.

            var indexes = Enumerable.Range(0, totalNumberOfMutableProperties)
                                    .OrderBy(x => Guid.NewGuid())
                                    .Take((int)Math.Floor(_mutationProbability * totalNumberOfMutableProperties));

            foreach (var idx in indexes)
            {
                var cellIndex = idx / 4;
                var propertyIndex = idx % 4;

                var specimen = population[cellIndex].Item;

                var a = specimen.A;
                var b = specimen.B;
                var c = specimen.C;
                var d = specimen.D;

                switch (propertyIndex)
                {
                    case 1: a = random.Next(-30, 31); break;
                    case 2: b = random.Next(-30, 31); break;
                    case 3: c = random.Next(-30, 31); break;
                    case 4: d = random.Next(-30, 31); break;
                }

                var mutatedSpecimen = new ConcreteSpecimen(a, b, c, d);

                population[cellIndex] = new WeightedItem<ConcreteSpecimen, double>(mutatedSpecimen, 0);
            }
        }
    }
}
