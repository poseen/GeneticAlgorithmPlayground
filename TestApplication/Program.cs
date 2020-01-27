using System;
using System.Linq;

namespace TestApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔══════════════════════╗");
            Console.WriteLine("║ Hello Genetic World! ║");
            Console.WriteLine("╚══════════════════════╝");
            Console.WriteLine();

            if (args.Length != 1 || !int.TryParse(args[0], out int target))
            {
                var exeName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                Console.WriteLine("[Usage]");
                Console.WriteLine();
                Console.WriteLine($"   {exeName} <target number>");
                Console.WriteLine();
                Console.WriteLine("[Example]");
                Console.WriteLine();
                Console.WriteLine($"   {exeName} 30");
                return;
            }

            Console.WriteLine("In this application we will try to generate the possible (approximating) solution to the following function:");
            Console.WriteLine();
            Console.WriteLine($"   a + 2b + 3c + 4d = {target}");
            Console.WriteLine();

            Console.WriteLine("Launching algorithm.");

            // Used to build the starter population:
            var builder = new ConcretePopulationBuilder();
            
            // Used to define the fitness function.
            var fitnessProvider = new ConcreteFitnessProvider(target);

            // The selector - nature's laws - which will select who will mate with who and what children will be born:
            var selector = new ConcretePopulationSelector(fitnessProvider);

            // The mutator, which will mutate the population slightly to enable evolution:
            var mutator = new ConcretePopulationMutator();

            // The manager of the whole algorithm, it accepts the builder, selector and mutator objects as plugins. (See Strategy pattern.)
            var evolutionAlgorithm = new EvolutionRunner<ConcreteSpecimen, double>(builder, selector, mutator, fitnessProvider);

            // Initialize the algorith: create a random starter population.
            evolutionAlgorithm.Initialize();

            var i = 0;
            Console.WriteLine("Press [ESC] to stop.");
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                i++;

                // Let nature do its job!
                evolutionAlgorithm.Iterate();

                // DEBUG: Showing iteration number and number of already found specimens:
                Console.Write($"\r{i + 1} iteration, found specimens: {evolutionAlgorithm.Result.Count}.");
            }

            Console.WriteLine();
            Console.WriteLine("Done.");
            Console.WriteLine();

            // Print out found specimens:
            foreach (var item in evolutionAlgorithm.Result.OrderBy(x => x.A).ThenBy(x => x.B).ThenBy(x => x.C).ThenBy(x => x.D))
            {
                Console.WriteLine($"{item.A} + (2 * {item.B}) + (3 * {item.C}) + (4 * {item.D}) = {item.A} + {2 * item.B} + {3 * item.C} + {4 * item.D} = {item.A + 2 * item.B + 3 * item.C + 4 * item.D}.");
            }
        }
    }
}
