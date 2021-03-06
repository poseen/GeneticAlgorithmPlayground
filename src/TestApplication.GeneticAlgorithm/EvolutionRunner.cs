﻿using System;
using System.Collections.Generic;
using System.Linq;
using TestApplication.GeneticAlgorithm.DataStructures;
using TestApplication.GeneticAlgorithm.Interfaces;

namespace TestApplication.GeneticAlgorithm
{
    public class EvolutionRunner<TSpecimen, TWeight> : IEvolutionRunner<TSpecimen> where TWeight : IComparable<TWeight>
    {
        private readonly IPopulationBuilder<TSpecimen> _populationBuilder;
        private readonly IPopulationSelector<TSpecimen> _populationSelector;
        private readonly IPopulationMutator<TSpecimen> _populationMutator;
        private readonly IFitnessProvider<TSpecimen> _fitnessProvider;

        private IWeightedList<TSpecimen> _population;

        public EvolutionRunner(IPopulationBuilder<TSpecimen> populationBuilder,
                               IPopulationSelector<TSpecimen> populationSelector,
                               IPopulationMutator<TSpecimen> populationMutator,
                               IFitnessProvider<TSpecimen> fitnessProvider)
        {
            _populationBuilder = populationBuilder;
            _populationSelector = populationSelector;
            _populationMutator = populationMutator;
            _fitnessProvider = fitnessProvider;
        }

        public IReadOnlyCollection<TSpecimen> Population => _population.Select(x => x.Item)
                                                                       .ToList()
                                                                       .AsReadOnly();

        public void Initialize(int starterPopulationSize)
        {
            _population = _populationBuilder.Build(starterPopulationSize);
        }

        public void Iterate()
        {
            _fitnessProvider.ReCalculateFitness(ref _population);
            _populationSelector.NaturalSelection(ref _population);
            _populationMutator.Mutate(ref _population);
        }
    }
}
