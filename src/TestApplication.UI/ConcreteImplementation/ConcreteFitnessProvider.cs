using System;
using System.Collections.Generic;
using System.Linq;
using TestApplication.GeneticAlgorithm.DataStructures;
using TestApplication.GeneticAlgorithm.Interfaces;

namespace TestApplication.UI.ConcreteImplementation
{
    public class ConcreteFitnessProvider : IFitnessProvider<ConcreteSpecimen, double>
    {
        private readonly Func<double, double, double> _function;

        public ConcreteFitnessProvider(Func<double, double, double> functionToBeExamined)
        {
            _function = functionToBeExamined;
        }

        public void ReCalculateFitness(ref IWeightedList<ConcreteSpecimen, double> population)
        {
            foreach (var item in population)
            {
                // Calculate the fitness value of the specimen. 1 means perfect specimen, lower values are worse.
                var distanceFromTarget = Math.Abs(FitnessFunction(item.Item.X, item.Item.Y) - 0);
                
                // We are searching for those points, which are inside (-2, -2)..(2, 2) radius.
                if(Math.Abs(item.Item.X) > 2 || Math.Abs(item.Item.Y) > 2)
                {
                    distanceFromTarget = 2;
                }

                var fitness = 1.0d / (1.0d + distanceFromTarget);

                item.Weight = fitness;
            }
        }

        public ICollection<ConcreteSpecimen> GetAcceptableSpecimens(IWeightedList<ConcreteSpecimen, double> population)
        {
            return population.Where(x => 1 - x.Weight < 0.1d)
                             .Select(x => x.Item)
                             .ToList()
                             .AsReadOnly();
        }

        private double FitnessFunction(double x, double y)
        {
            return _function(x, y);
        }
    }
}
