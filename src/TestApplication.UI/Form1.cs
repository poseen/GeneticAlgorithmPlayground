using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApplication;
using TestApplication.GeneticAlgorithm;
using TestApplication.UI.ConcreteImplementation;

namespace TestApplication.UI
{
    public partial class MainForm : Form
    {
        private readonly Image _image;
        private readonly Image _bgImage;
        private readonly Random _random = new Random();

        private enum Function
        {
            /// <summary>
            /// Ripple
            /// f(x, y) = sin(x² + y²)
            /// </summary>
            Ripple,

            /// <summary>
            /// Hyperbolic paraboloid
            /// f(x, y) = x² - y²
            /// https://en.wikipedia.org/wiki/Paraboloid#Hyperbolic_paraboloid
            /// </summary>
            HyperbolicParaboloid,

            /// <summary>
            /// Monkey-saddle
            /// f(x, y) = x³ - -3xy²
            /// https://en.wikipedia.org/wiki/Monkey_saddle
            /// </summary>
            MonkeySaddle,

            /// <summary>
            /// f(x, y) = sin(x²) * cos(y²) - 5
            /// </summary>
            Sinx2Cosy2Minus5,

            /// <summary>
            /// Bumps
            /// f(x, y) = (sin(5x) * c(5y)) / 5;
            /// From/based on: https://www.benjoffe.com/code/tools/functions3d/examples
            /// </summary>
            Bumps,

            /// <summary>
            /// Intersecting Fences
            /// f(x, y) = (0.75 / exp(5x² * 5y²)) - 0.1d;
            /// From/based on: https://www.benjoffe.com/code/tools/functions3d/examples
            /// </summary>
            IntersectingFences
        }

        private class FunctionDescription
        {
            public FunctionDescription(string title, Function funcEnum, Func<double, double, double> function)
            {
                Title = title;
                FunctionEnum = funcEnum;
                Function = function;
            }

            public Func<double, double, double> Function { get; }

            public string Title { get; }
            
            public Function FunctionEnum { get; }

            public override string ToString()
            {
                return Title;
            }
        }

        private readonly IDictionary<int, FunctionDescription> _functions;

        public MainForm()
        {
            InitializeComponent();
            _image = pictureboxPreview.Image = new Bitmap(600, 600);
            _bgImage = pictureboxPreview.BackgroundImage = new Bitmap(600, 600);

            _functions = new Dictionary<int, FunctionDescription>()
            {
                { 0, new FunctionDescription("Ripple", Function.Ripple, (x, y) => Math.Sin(x * x + y * y)) },
                { 1, new FunctionDescription("Hyperbolic paraboloid", Function.HyperbolicParaboloid, (x, y) => x*x - y*y) },
                { 2, new FunctionDescription("Monkey-Saddle", Function.MonkeySaddle, (x, y) => x * x * x - 3 * x * y * y) },
                { 3, new FunctionDescription("Sin(x²) * Cos(y²) - 0.5", Function.Sinx2Cosy2Minus5, (x, y) => (Math.Sin(x * x) * Math.Cos(y * y)) - 0.5d) },
                { 4, new FunctionDescription("Bumps", Function.Bumps, (x, y) => (Math.Sin(5 * x) * Math.Cos(5 * y)) / 5.0d) },
                { 5, new FunctionDescription("Intersecting Fences", Function.IntersectingFences, (x, y) => 0.75d / Math.Exp(Math.Pow((x * 5), 2) * Math.Pow((y * 5), 2)) - 0.1d) }
            };

            comboboxTargetFunction.Items.AddRange(_functions.Values.ToArray());
            comboboxTargetFunction.SelectedIndex = 0;
        }

        private EvolutionRunner<ConcreteSpecimen, double> Build()
        {
            // Used to build the starter population:
            var builder = new ConcretePopulationBuilder();

            // Used to define the fitness function.
            var fitnessProvider = new ConcreteFitnessProvider((comboboxTargetFunction.SelectedItem as FunctionDescription).Function, double.Parse(textboxAcceptingDistance.Text));

            // The selector - nature's laws - which will select who will mate with who and what children will be born:
            var selector = new ConcretePopulationSelector(fitnessProvider);

            // The mutator, which will mutate the population slightly to enable evolution:
            var mutator = new ConcretePopulationMutator();

            // The manager of the whole algorithm, it accepts the builder, selector and mutator objects as plugins. (See Strategy pattern.)
            var evolutionAlgorithm = new EvolutionRunner<ConcreteSpecimen, double>(builder, selector, mutator, fitnessProvider);

            return evolutionAlgorithm;
        }

        private ConcreteRandomAlgorithm<ConcreteSpecimen, double> BuildRandomAlgo()
        {
            // Used to build the starter population:
            var builder = new ConcretePopulationBuilder();

            // Used to define the fitness function.
            var fitnessProvider = new ConcreteFitnessProvider((comboboxTargetFunction.SelectedItem as FunctionDescription).Function, double.Parse(textboxAcceptingDistance.Text));

            // The selector - nature's laws - which will select who will mate with who and what children will be born:
            var selector = new ConcretePopulationSelector(fitnessProvider);

            // The mutator, which will mutate the population slightly to enable evolution:
            var mutator = new ConcretePopulationMutator();

            // The manager of the whole algorithm, it accepts the builder, selector and mutator objects as plugins. (See Strategy pattern.)
            var evolutionAlgorithm = new ConcreteRandomAlgorithm<ConcreteSpecimen, double>(builder, selector, mutator, fitnessProvider);

            return evolutionAlgorithm;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            StartAlgorithm();
        }

        private void StartAlgorithm()
        {
            const int imgWidth = 600;
            const int imgHeight = 600;

            var algo = Build();
            algo.Initialize((int)numericStartPopulationSize.Value);

            var rect = new Rectangle(0, 0, imgWidth, imgHeight);

            var leftTop = Translate(-1, 1, imgWidth, imgHeight);
            var leftMiddle = Translate(-1, 0, imgWidth, imgHeight);
            var leftBottom = Translate(-1, -1, imgWidth, imgHeight);

            var rightTop = Translate(1, 1, imgWidth, imgHeight);
            var rightMiddle = Translate(1, 0, imgWidth, imgHeight);
            var rightBottom = Translate(1, -1, imgWidth, imgHeight);

            var topMiddle = Translate(0, 1, imgWidth, imgHeight);
            var bottomMiddle = Translate(0, -1, imgWidth, imgHeight);

            var b = Brushes.GreenYellow;
            var b2 = Brushes.Red;

            var bg = Graphics.FromImage(_bgImage);
            var g = Graphics.FromImage(_image);

            bg.FillRectangle(Brushes.MidnightBlue, rect.X, rect.Y, rect.Width, rect.Height);
            //bg.DrawLine(Pens.White, leftMiddle.x, leftMiddle.y, rightMiddle.x, rightMiddle.y);
            //bg.DrawLine(Pens.White, topMiddle.x, topMiddle.y, bottomMiddle.x, bottomMiddle.y);

            var cnt = 0;
            int iterationsUntilFound10Specimens = 0;

            while (cnt < (int)numericNumberOfIterations.Value)
            {
                cnt++;
                algo.Iterate();

                g.Clear(Color.Transparent);

                // Print out found specimens:
                foreach (var item in algo.Population)
                {
                    var position = Translate(item.X / 2.0d, item.Y / 2.0d, imgWidth, imgHeight);
                    g.FillRectangle(b, position.x-1, position.y-1, 2, 2);
                }

                // Print out found specimens:
                foreach (var item in algo.Result)
                {
                    var position = Translate(item.X / 2.0d, item.Y / 2.0d, imgWidth, imgHeight);
                    g.FillRectangle(b2, position.x - 1, position.y - 1, 2, 2);
                }

                var calculationForOneSpecimen = (cnt * algo.Population.Count) / (algo.Result.Count + 1);

                if (algo.Result.Count >= 10 && iterationsUntilFound10Specimens == 0)
                {
                    iterationsUntilFound10Specimens = cnt;
                }

                labelStatistics.Text = $"It.#: {cnt}, Found: {algo.Result.Count}, # of calc: {cnt * algo.Population.Count}. Avg calc/specimen: {calculationForOneSpecimen}. Iterations until first 10: {iterationsUntilFound10Specimens}";
                labelStatistics.Refresh();

                pictureboxPreview.Refresh();
            }
        }

        private void StartRandomAlgo()
        {
            const int imgWidth = 600;
            const int imgHeight = 600;

            var algo = BuildRandomAlgo();
            algo.Initialize((int)numericStartPopulationSize.Value);

            var rect = new Rectangle(0, 0, imgWidth, imgHeight);

            var leftTop = Translate(-1, 1, imgWidth, imgHeight);
            var leftMiddle = Translate(-1, 0, imgWidth, imgHeight);
            var leftBottom = Translate(-1, -1, imgWidth, imgHeight);

            var rightTop = Translate(1, 1, imgWidth, imgHeight);
            var rightMiddle = Translate(1, 0, imgWidth, imgHeight);
            var rightBottom = Translate(1, -1, imgWidth, imgHeight);

            var topMiddle = Translate(0, 1, imgWidth, imgHeight);
            var bottomMiddle = Translate(0, -1, imgWidth, imgHeight);

            var b = Brushes.GreenYellow;
            var b2 = Brushes.Red;

            var bg = Graphics.FromImage(_bgImage);
            var g = Graphics.FromImage(_image);

            bg.FillRectangle(Brushes.MidnightBlue, rect.X, rect.Y, rect.Width, rect.Height);
            //bg.DrawLine(Pens.White, leftMiddle.x, leftMiddle.y, rightMiddle.x, rightMiddle.y);
            //bg.DrawLine(Pens.White, topMiddle.x, topMiddle.y, bottomMiddle.x, bottomMiddle.y);

            var cnt = 0;
            int iterationsUntilFound10Specimens = 0;

            while (cnt < (int)numericNumberOfIterations.Value)
            {
                cnt++;
                algo.Iterate();

                g.Clear(Color.Transparent);

                // Print out found specimens:
                foreach (var item in algo.Population)
                {
                    var position = Translate(item.X / 2.0d, item.Y / 2.0d, imgWidth, imgHeight);
                    g.FillRectangle(b, position.x - 1, position.y - 1, 2, 2);
                }

                // Print out found specimens:
                foreach (var item in algo.Result)
                {
                    var position = Translate(item.X / 2.0d, item.Y / 2.0d, imgWidth, imgHeight);
                    g.FillRectangle(b2, position.x - 1, position.y - 1, 2, 2);
                }

                var calculationForOneSpecimen = (cnt * algo.Population.Count) / (algo.Result.Count + 1);
                
                if(algo.Result.Count >= 10 && iterationsUntilFound10Specimens == 0)
                {
                    iterationsUntilFound10Specimens = cnt;
                }


                labelStatistics.Text = $"It.#: {cnt}, Found: {algo.Result.Count}, # of calc: {cnt * algo.Population.Count}. Avg calc/specimen: {calculationForOneSpecimen}. Iterations until first 10: {iterationsUntilFound10Specimens}";
                labelStatistics.Refresh();

                pictureboxPreview.Refresh();
            }
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

        private void btnStartStopRandomAlgo_Click(object sender, EventArgs e)
        {
            StartRandomAlgo();
        }
    }
}
