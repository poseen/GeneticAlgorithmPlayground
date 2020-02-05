//using System;
//using System.Collections.Generic;
//using System.Linq;
//using TestApplication.GeneticAlgorithm.DataStructures;
//using TestApplication.GeneticAlgorithm.Interfaces;
//using TestApplication.GeneticAlgorithm;

//namespace TestApplication.UI.ConcreteImplementation
//{
//    class ConcreteRandomAlgorithm<TSpecimen> : IEvolutionRunner<TSpecimen>
//    {
//        private readonly IPopulationBuilder<TSpecimen> _populationBuilder;
//        private readonly IFitnessProvider<TSpecimen> _fitnessProvider;
//        private readonly ISpecimenCollector<TSpecimen> _specimenCollector;
        
//        private int _starterPopulationSize;
//        private IWeightedList<TSpecimen> _population;

//        public ConcreteRandomAlgorithm(IPopulationBuilder<TSpecimen> populationBuilder,
//                               IFitnessProvider<TSpecimen> fitnessProvider)
//        {
//            _populationBuilder = populationBuilder;
//            _fitnessProvider = fitnessProvider;
//            _specimenCollector = new SpecimenCollector<TSpecimen>();
//        }

//        public IReadOnlyCollection<TSpecimen> Result => _specimenCollector.GetSpecimens();

//        public IReadOnlyCollection<TSpecimen> Population => _population.Select(x => x.Item).ToList().AsReadOnly();

//        public void Initialize(int starterPopulationSize)
//        {
//            _population = _populationBuilder.Build(starterPopulationSize);
//            _fitnessProvider.ReCalculateFitness(ref _population);
//            _starterPopulationSize = starterPopulationSize;
//        }

//        public void Iterate()
//        {
//            _population = _populationBuilder.Build(_starterPopulationSize);
//            _fitnessProvider.ReCalculateFitness(ref _population);
//            var acceptedSpecimen = _fitnessProvider.GetAcceptableSpecimens(_population);
//            _specimenCollector.AddRange(acceptedSpecimen);
//        }
//    }
//}