using System;
using System.Collections.Generic;
using System.Linq;
using TestApplication.GeneticAlgorithm.DataStructures;
using TestApplication.GeneticAlgorithm.Interfaces;

namespace TestApplication.UI.ConcreteImplementation
{
    public class ConcretePopulationSelector : IPopulationSelector<ConcreteSpecimen>
    {
        private readonly IFitnessProvider<ConcreteSpecimen> _fitnessProvider;

        public ConcretePopulationSelector(IFitnessProvider<ConcreteSpecimen> fitnessProvider)
        {
            _fitnessProvider = fitnessProvider;
        }

        public void NaturalSelection(ref IWeightedList<ConcreteSpecimen> population)
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
                var parents = new WeightedItem<ConcreteSpecimen>[2];
                for (var j = 0; j < numberOfParents; j++)
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
                                parents[j] = item;
                            }
                        }
                    }
                }

                //var parents = new WeightedItem<ConcreteSpecimen>[2];
                //parents[0] = originalPopulation.WeightedRandom();
                //parents[1] = originalPopulation.WeightedRandom();

                double x, y;

                switch (random.Next(3))
                {
                    case 0:
                        x = (parents[0].Weight * parents[0].Item.X + parents[1].Weight * parents[1].Item.X) / (parents[0].Weight + parents[1].Weight);
                        y = (parents[0].Weight * parents[0].Item.Y + parents[1].Weight * parents[1].Item.Y) / (parents[0].Weight + parents[1].Weight);
                        break;

                    case 1:
                        x = (parents[0].Weight * parents[0].Item.X + parents[1].Weight * parents[1].Item.X) / (parents[0].Weight + parents[1].Weight);
                        y = parents[random.Next(0, 2)].Item.Y;
                        break;

                    case 2:
                        x = parents[random.Next(0, 2)].Item.X;
                        y = (parents[0].Weight * parents[0].Item.Y + parents[1].Weight * parents[1].Item.Y) / (parents[0].Weight + parents[1].Weight);
                        break;

                    default:
                        // Default case: let's just randomly select which gene is coming from which parent...
                        x = parents[random.Next(0, 2)].Item.X;
                        y = parents[random.Next(0, 2)].Item.Y;
                        break;
                }

                var offSpring = new ConcreteSpecimen(x, y);

                population.Add(new WeightedItem<ConcreteSpecimen>(offSpring, 0));
            }
        }
    }
}
