using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApplication
{
    public class ConcreteFitnessProvider : IFitnessProvider<ConcreteSpecimen, double>
    {
        private readonly int _target;
        
        public ConcreteFitnessProvider(int targetFunctionValue)
        {
            _target = targetFunctionValue;
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
            return population.Where(x => 1 - x.Weight < 0.01d)
                             .Select(x => x.Item)
                             .ToList()
                             .AsReadOnly();
        }

        private double FitnessFunction(double x, double y)
        {
            // Ripple
            return Math.Sin(x * x + y * y);

            /* 
             * Other examples from/based on: https://www.benjoffe.com/code/tools/functions3d/examples 
             */

            // Bumps
            // return (Math.Sin(5 * x) * Math.Cos(5 * y)) / 5.0d;

            // Intersecting Fences
            // return 0.75d / Math.Exp(Math.Pow((x * 5), 2) * Math.Pow((y * 5), 2)) - 0.1d;
        }
    }
}
