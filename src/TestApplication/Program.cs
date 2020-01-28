using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace TestApplication
{
    public class Program
    {
        public const double DoublePrecision = 0.00001d;

        static void Main(string[] args)
        {
            Console.WriteLine("╔══════════════════════╗");
            Console.WriteLine("║ Hello Genetic World! ║");
            Console.WriteLine("╚══════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("Now let's do something more interesting. In this application we will try to generate the possible (approximating) solution to the following function:");
            Console.WriteLine();
            Console.WriteLine($"   sin(x² + y²) = 0");
            Console.WriteLine();
            Console.WriteLine("Afterwards we will plot the found points in the -2..+2 plane.");
            Console.WriteLine();
            Console.WriteLine("Launching algorithm.");

            // Used to build the starter population:
            var builder = new ConcretePopulationBuilder();
            
            // Used to define the fitness function.
            var fitnessProvider = new ConcreteFitnessProvider(0);

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
            Console.WriteLine("Stopped.");
            Console.WriteLine();

            const int imgWidth = 1500;
            const int imgHeight = 1500;

            var bmp = new Bitmap(imgWidth, imgHeight);
            var g = Graphics.FromImage(bmp);

            var rect = new Rectangle(0, 0, imgWidth, imgHeight);
            g.FillRectangle(Brushes.MidnightBlue, rect.X, rect.Y, rect.Width, rect.Height);

            var leftTop = Translate(-1, 1, imgWidth, imgHeight);
            var leftMiddle = Translate(-1, 0, imgWidth, imgHeight);
            var leftBottom = Translate(-1, -1, imgWidth, imgHeight);

            var rightTop = Translate(1, 1, imgWidth, imgHeight);
            var rightMiddle = Translate(1, 0, imgWidth, imgHeight);
            var rightBottom = Translate(1, -1, imgWidth, imgHeight);

            var topMiddle = Translate(0, 1, imgWidth, imgHeight);
            var bottomMiddle = Translate(0, -1, imgWidth, imgHeight);

            g.DrawLine(Pens.White, leftMiddle.x, leftMiddle.y, rightMiddle.x, rightMiddle.y);
            g.DrawLine(Pens.White, topMiddle.x, topMiddle.y, bottomMiddle.x, bottomMiddle.y);

            var b = Brushes.GreenYellow;

            // Print out found specimens:
            foreach (var item in evolutionAlgorithm.Result.OrderBy(x => x.X).ThenBy(x => x.Y))
            {
                var position = Translate(item.X / 2.0d, item.Y / 2.0d, imgWidth, imgHeight);
                g.FillRectangle(b, position.x, position.y, 1, 1);
            }

            bmp.Save("output.bmp");

            Console.WriteLine("Image saved. Trying to open with associated application...");

            new Process
            {
                StartInfo = new ProcessStartInfo(@"output.bmp")
                {
                    UseShellExecute = true
                }
            }.Start();
        }

        /// <summary>
        /// Translates the given dx, dy to "image coordinates" where the image size is given.
        /// dy and dy considered to be between -1 and 1.
        /// </summary>
        /// <param name="dx">The value in the X-axis, must be between [-1, 1].</param>
        /// <param name="dy">The value in the Y-axis, must be between [-1, 1].</param>
        /// <param name="width">Width of the canvas where we would like to plot the found points of the function.</param>
        /// <param name="height">Height of the canvas where we would like to plot the found points of the function.</param>
        /// <returns>A tuple of (x, y) with the translated coordinates.</returns>
        private static (int x, int y) Translate(double dx, double dy, int width, int height)
        {
            var halfWidth = width / 2.0d;
            var halfHeight = height / 2.0d;
            
            var middleY = height / 2;

            var tx = (int)Math.Round((dx + 1) * halfWidth);
            var ty = (int)Math.Round(middleY - dy * halfHeight);

            return (tx, ty);
        }
    }
}
