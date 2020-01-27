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
                var fitness = 1.0d / (1.0d + Math.Abs(FitnessFunction(item.Item.A, item.Item.B, item.Item.C, item.Item.D) - _target));

                item.Weight = fitness;
            }
        }

        public ICollection<ConcreteSpecimen> GetAcceptableSpecimens(IWeightedList<ConcreteSpecimen, double> population)
        {
            return population.Where(x => x.Weight.Equals(1)).Select(x => x.Item).ToList().AsReadOnly();
        }

        private int FitnessFunction(int a, int b, int c, int d)
        {
            return a + (2 * b) + (3 * c) + (4 * d);
        }
    }
}
