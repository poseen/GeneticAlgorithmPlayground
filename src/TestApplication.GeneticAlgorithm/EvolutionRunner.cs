﻿using System;
using System.Collections.Generic;
using System.Linq;
using TestApplication.GeneticAlgorithm.DataStructures;
using TestApplication.GeneticAlgorithm.Interfaces;

namespace TestApplication.GeneticAlgorithm
{
    public class EvolutionRunner<TSpecimen, TWeight> : IEvolutionRunner<TSpecimen> where TWeight : IComparable<TWeight>
    {
        private readonly IPopulationBuilder<TSpecimen, TWeight> _populationBuilder;
        private readonly IPopulationSelector<TSpecimen, TWeight> _populationSelector;
        private readonly IPopulationMutator<TSpecimen, TWeight> _populationMutator;
        private readonly IFitnessProvider<TSpecimen, TWeight> _fitnessProvider;
        private readonly ISpecimenCollector<TSpecimen> _specimenCollector;

        private IWeightedList<TSpecimen, TWeight> _population;

        public EvolutionRunner(IPopulationBuilder<TSpecimen, TWeight> populationBuilder,
                               IPopulationSelector<TSpecimen, TWeight> populationSelector,
                               IPopulationMutator<TSpecimen, TWeight> populationMutator,
                               IFitnessProvider<TSpecimen, TWeight> fitnessProvider)
        {
            _populationBuilder = populationBuilder;
            _populationSelector = populationSelector;
            _populationMutator = populationMutator;
            _fitnessProvider = fitnessProvider;
            _specimenCollector = new SpecimenCollector<TSpecimen>();
        }

        public IReadOnlyCollection<TSpecimen> Result => _specimenCollector.GetSpecimens();

        public IReadOnlyCollection<TSpecimen> Population => _population.Select(x => x.Item)
                                                                       .ToList()
                                                                       .AsReadOnly();

        public void Initialize(int starterPopulationSize)
        {
            _population = _populationBuilder.Build(starterPopulationSize);
            _fitnessProvider.ReCalculateFitness(ref _population);
        }

        public void Iterate()
        {
            _populationSelector.NaturalSelection(ref _population);
            _populationMutator.Mutate(ref _population);
            _fitnessProvider.ReCalculateFitness(ref _population);
            var acceptedSpecimen = _fitnessProvider.GetAcceptableSpecimens(_population);
            _specimenCollector.AddRange(acceptedSpecimen);
        }
    }
}