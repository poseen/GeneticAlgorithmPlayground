using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.GeneticAlgorithm.DataStructures;
using TestApplication.GeneticAlgorithm.Interfaces;
using TestApplication.GeneticAlgorithm;

namespace TestApplication.UI.ConcreteImplementation
{
    class ConcreteRandomAlgorithm<TSpecimen, TWeight> : IEvolutionRunner<TSpecimen> where TWeight : IComparable<TWeight>
    {
        private readonly IPopulationBuilder<TSpecimen, TWeight> _populationBuilder;
        private readonly IPopulationSelector<TSpecimen, TWeight> _populationSelector;
        private readonly IPopulationMutator<TSpecimen, TWeight> _populationMutator;
        private readonly IFitnessProvider<TSpecimen, TWeight> _fitnessProvider;
        private readonly ISpecimenCollector<TSpecimen> _specimenCollector;

        private IWeightedList<TSpecimen, TWeight> _population;

        public ConcreteRandomAlgorithm(IPopulationBuilder<TSpecimen, TWeight> populationBuilder,
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

        private int _starterPopulationSize;

        public void Initialize(int starterPopulationSize)
        {
            _population = _populationBuilder.Build(starterPopulationSize);
            _fitnessProvider.ReCalculateFitness(ref _population);
            _starterPopulationSize = starterPopulationSize;
        }

        public void Iterate()
        {
            _population = _populationBuilder.Build(_starterPopulationSize);
            _fitnessProvider.ReCalculateFitness(ref _population);
            var acceptedSpecimen = _fitnessProvider.GetAcceptableSpecimens(_population);
            _specimenCollector.AddRange(acceptedSpecimen);
        }
    }
}