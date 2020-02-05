using System;
using TestApplication.GeneticAlgorithm.DataStructures;
using TestApplication.GeneticAlgorithm.Interfaces;

namespace TestApplication.UI.ConcreteImplementation
{
    public class ConcretePopulationBuilder : IPopulationBuilder<ConcreteSpecimen>
    {
        public ConcretePopulationBuilder()
        {
        }

        public IWeightedList<ConcreteSpecimen> Build(int sizeOfStarterPopulation)
        {
            var random = new Random();
            var result = new WeightedList<ConcreteSpecimen>(sizeOfStarterPopulation);

            // We generate the population around a random epicenter...
            var epicenter = -1.5d + random.NextDouble() * 3;

            for (var i = 0; i < sizeOfStarterPopulation; i++)
            {
                var cell = new ConcreteSpecimen(epicenter + (-2 + random.NextDouble() * 4));
                result.Add(new WeightedItem<ConcreteSpecimen>(cell, 0));
            }

            return result;
        }
    }
}
