using System;
using TestApplication.GeneticAlgorithm.DataStructures;
using TestApplication.GeneticAlgorithm.Interfaces;

namespace TestApplication.UI.ConcreteImplementation
{
    public class ConcretePopulationBuilder : IPopulationBuilder<ConcreteSpecimen, double>
    {
        public ConcretePopulationBuilder()
        {
        }

        public IWeightedList<ConcreteSpecimen, double> Build(int sizeOfStarterPopulation)
        {
            var random = new Random();
            var result = new WeightedList<ConcreteSpecimen, double>(sizeOfStarterPopulation);
            for (var i = 0; i < sizeOfStarterPopulation; i++)
            {
                var cell = new ConcreteSpecimen(-4 + random.NextDouble() * 8, -4 + random.NextDouble() * 8);
                result.Add(new WeightedItem<ConcreteSpecimen, double>(cell, 0));
            }

            return result;
        }
    }
}
