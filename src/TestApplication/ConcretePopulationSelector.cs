using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApplication
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

                var offSpring = new ConcreteSpecimen(parents[random.Next(0, 2)].X, parents[random.Next(0, 2)].Y);
                
                population.Add(new WeightedItem<ConcreteSpecimen, double>(offSpring, 0));
            }
        }
    }
}
