using System;
using System.Collections.Generic;
using System.Linq;
using TestApplication.GeneticAlgorithm.DataStructures;
using TestApplication.GeneticAlgorithm.Interfaces;

namespace TestApplication.UI.ConcreteImplementation
{
    public class ConcretePopulationSelector : IPopulationSelector<ConcreteSpecimen, double>
    {
        private readonly IFitnessProvider<ConcreteSpecimen, double> _fitnessProvider;

        public ConcretePopulationSelector(IFitnessProvider<ConcreteSpecimen, double> fitnessProvider)
        {
            _fitnessProvider = fitnessProvider;
        }

        public void NaturalSelection(ref IWeightedList<ConcreteSpecimen, double> population)
        {
            var originalPopulation = population.ToArray();
            population.Clear();
            var count = originalPopulation.Length;
            var numberOfParents = 2;
            var sumFitness = originalPopulation.Sum(x => x.Weight);
            var random = new Random();
            var acceptableSpecimens = new List<ConcreteSpecimen>();

            /**************************************************************************************************
             *    Based on https://stackoverflow.com/questions/10765660/roulette-wheel-selection-procedure    *
             **************************************************************************************************
             *                                                                                                *
             *    For all members of population                                                               *
             *         sum += fitness ( member )                                                              *
             *    End for                                                                                     *
             *                                                                                                *
             *    Loop until new population is full                                                           *
             *         Do this twice                                                                          *
             *              Number = Random between 0 and sum                                                 *
             *              Currentfitness = 0.0                                                              *
             *              For each member in population                                                     *
             *                 Currentfitness += fitness(member)                                              *
             *                 if Number > Currentfitness then select member                                  *
             *              End for                                                                           *
             *         End                                                                                    *
             *    Create offspring                                                                            *
             *    End loop                                                                                    *
             *                                                                                                *
             **************************************************************************************************/

            for (var i = 0; i < count; i++)
            {
                var parents = new ConcreteSpecimen[numberOfParents];
                for(var j = 0; j < numberOfParents; j++)
                {
                    while (parents[j] == null)
                    {
                        var number = random.NextDouble() * sumFitness;
                        var currentFitness = 0.0d;

                        foreach (var item in originalPopulation)
                        {
                            currentFitness += item.Weight;

                            if (number > currentFitness)
                            {
                                parents[j] = item.Item;
                            }
                        }
                    }
                }

                // Default case: let's just randomly select which gene is coming from which parent...
                var x = parents[random.Next(0, 2)].X;
                var y = parents[random.Next(0, 2)].Y;

                switch (random.Next(3))
                {
                    case 0:
                        // Let's take the arithmetic mean ("average") of the parent's genes
                        x = (parents[0].X + parents[1].X) / 2.0d;
                        y = (parents[0].Y + parents[1].Y) / 2.0d;
                        break;

                    case 1:
                        // Let's take the geometric mean of the parent's genes
                        x = Math.Pow((parents[0].X * parents[1].X), 0.5d);
                        y = Math.Pow((parents[0].Y * parents[1].Y), 0.5d);

                        // If any calculation returned a not a number, then we fall back to average.
                        if(double.IsNaN(x))
                        {
                            x = (parents[0].X + parents[1].X) / 2.0d;
                        }

                        if (double.IsNaN(y))
                        {
                            y = (parents[0].Y + parents[1].Y) / 2.0d;
                        }
                        break;

                    default:
                        // Default case.
                        break;
                }

                var offSpring = new ConcreteSpecimen(x, y);

                population.Add(new WeightedItem<ConcreteSpecimen, double>(offSpring, 0));
            }
        }
    }
}
