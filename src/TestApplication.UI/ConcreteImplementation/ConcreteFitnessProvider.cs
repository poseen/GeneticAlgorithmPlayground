using System;
using System.Collections.Generic;
using System.Linq;
using TestApplication.GeneticAlgorithm.DataStructures;
using TestApplication.GeneticAlgorithm.Interfaces;

namespace TestApplication.UI.ConcreteImplementation
{
    public class ConcreteFitnessProvider : IFitnessProvider<ConcreteSpecimen>
    {
        private readonly Func<double, double> _function;

        public ConcreteFitnessProvider(Func<double, double> functionToBeExamined)
        {
            _function = functionToBeExamined;
        }

        public void ReCalculateFitness(ref IWeightedList<ConcreteSpecimen> population)
        {
            var minimum = double.PositiveInfinity;
            var maximum = double.NegativeInfinity;

            foreach (var item in population)
            {
                // We are searching for global minimum.
                // Maybe the number of global minimum is infinite.
                var functionValue = FitnessFunction(item.Item.X);
                if(functionValue < minimum)
                {
                    minimum = functionValue;
                }

                if (functionValue > maximum)
                {
                    maximum = functionValue;
                }

                item.Weight = functionValue;
            }

            var diff = maximum - minimum + 1; // +1 to avoid division by zero

            foreach (var item in population)
            {
                var p = 1 - ((item.Weight + minimum) / diff);
                item.Weight = p;
            }
        }

        private double FitnessFunction(double x)
        {
            return _function(x);
        }
    }
}
