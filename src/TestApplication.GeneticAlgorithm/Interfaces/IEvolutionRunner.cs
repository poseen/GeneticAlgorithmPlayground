using System.Collections.Generic;

namespace TestApplication.GeneticAlgorithm.Interfaces
{
    public interface IEvolutionRunner<TSpecimen>
    {
        void Initialize(int starterPopulationSize);

        void Iterate();

        IReadOnlyCollection<TSpecimen> Population { get; }
        
        IReadOnlyCollection<TSpecimen> Result { get; }
    }
}
