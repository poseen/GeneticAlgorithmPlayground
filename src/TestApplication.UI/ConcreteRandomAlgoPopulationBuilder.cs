//using System;
//using TestApplication.GeneticAlgorithm.DataStructures;
//using TestApplication.GeneticAlgorithm.Interfaces;

//namespace TestApplication.UI.ConcreteImplementation
//{
//    public class ConcreteRandomAlgoPopulationBuilder : IPopulationBuilder<ConcreteSpecimen>
//    {
//        public ConcreteRandomAlgoPopulationBuilder()
//        {
//        }

//        public IWeightedList<ConcreteSpecimen> Build(int sizeOfStarterPopulation)
//        {
//            var random = new Random();
//            var result = new WeightedList<ConcreteSpecimen>(sizeOfStarterPopulation);

//            // We generate the population around a random epicenter...
//            var epicenter = new
//            {
//                X = -1.5d + random.NextDouble() * 3,
//                Y = -1.5d + random.NextDouble() * 3
//            };

//            for (var i = 0; i < sizeOfStarterPopulation; i++)
//            {
//                var cell = new ConcreteSpecimen(epicenter.X + (-10 + random.NextDouble() * 20),
//                                                epicenter.Y + (-10 + random.NextDouble() * 20));
//                result.Add(new WeightedItem<ConcreteSpecimen>(cell, 0));
//            }

//            return result;
//        }
//    }
//}
