﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApplication;
using TestApplication.GeneticAlgorithm;
using TestApplication.GeneticAlgorithm.Interfaces;
using TestApplication.UI.ConcreteImplementation;

namespace TestApplication.UI
{
    public partial class MainForm : Form
    {
        const int imgWidth = 1000;
        const int imgHeight = 1000;

        private readonly Image _imageEvolutionPreviewImage;
        private readonly Image _bgImgEvolutionPreviewImage;

        private readonly Image _imageRandomPreviewImage;
        private readonly Image _bgImgRandomPreviewImage;

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
            _imageEvolutionPreviewImage = pictureboxEvolutionPreview.Image = new Bitmap(imgWidth, imgHeight);
            _bgImgEvolutionPreviewImage = pictureboxEvolutionPreview.BackgroundImage = new Bitmap(imgWidth, imgHeight);
            _imageRandomPreviewImage = pictureboxRandomPreview.Image = new Bitmap(imgWidth, imgHeight);
            _bgImgRandomPreviewImage = pictureboxRandomPreview.BackgroundImage = new Bitmap(imgWidth, imgHeight);

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

            // Necessary to take the window frame width/height into account
            this.chromeWidth = this.Width - this.ClientSize.Width;
            this.chromeHeight = this.Height - this.ClientSize.Height;
            this.ClientSize = new System.Drawing.Size(1052, 451);
        }

        private IEvolutionRunner<ConcreteSpecimen> Build()
        {
            // Used to build the starter population:
            var builder = new ConcretePopulationBuilder();

            // Used to define the fitness function.
            var fitnessProvider = new ConcreteFitnessProvider(GetSelectedFunction().Function, GetAcceptingDistance());

            // The selector - nature's laws - which will select who will mate with who and what children will be born:
            var selector = new ConcretePopulationSelector(fitnessProvider);

            // The mutator, which will mutate the population slightly to enable evolution:
            var mutator = new ConcretePopulationMutator();

            // The manager of the whole algorithm, it accepts the builder, selector and mutator objects as plugins. (See Strategy pattern.)
            var evolutionAlgorithm = new EvolutionRunner<ConcreteSpecimen, double>(builder, selector, mutator, fitnessProvider);

            return evolutionAlgorithm;
        }

        private FunctionDescription GetSelectedFunction()
        {
            if (comboboxTargetFunction.InvokeRequired)
                return (FunctionDescription)this.Invoke(new Func<FunctionDescription>(() => comboboxTargetFunction.SelectedItem as FunctionDescription));
            else
                return comboboxTargetFunction.SelectedItem as FunctionDescription;
        }

        private double GetAcceptingDistance()
        {
            if (textboxAcceptingDistance.InvokeRequired)
                return (double)this.Invoke(new Func<double>(() => double.Parse(textboxAcceptingDistance.Text)));
            else
                return double.Parse(textboxAcceptingDistance.Text);
        }

        private IEvolutionRunner<ConcreteSpecimen> BuildRandomAlgo()
        {
            // Used to build the starter population:
            var builder = new ConcreteRandomAlgoPopulationBuilder();

            // Used to define the fitness function.
            var fitnessProvider = new ConcreteFitnessProvider(GetSelectedFunction().Function, GetAcceptingDistance());

            // The manager of the whole algorithm, it accepts the builder, selector and mutator objects as plugins. (See Strategy pattern.)
            var evolutionAlgorithm = new ConcreteRandomAlgorithm<ConcreteSpecimen>(builder, fitnessProvider);

            return evolutionAlgorithm;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            var t1 = new Task(() => StartAlgorithm());
            t1.Start();
        }

        private void StartAlgorithm()
        {
            DoSafe(() =>
            {
                btnStartEvolution.Enabled = false;
                btnStartComparisonOfAlgorithms.Enabled = false;
                numericNumberOfIterations.Enabled = false;
                numericStartPopulationSize.Enabled = false;
                comboboxTargetFunction.Enabled = false;
                textboxAcceptingDistance.Enabled = false;
            });

            var algo = Build();
            algo.Initialize((int)numericStartPopulationSize.Value);

            var cnt = 0;
            int iterationsUntilFound10Specimens = 0;

            while (cnt < (int)numericNumberOfIterations.Value)
            {
                cnt++;
                algo.Iterate();

                DoSafe(new Action(() => RefreshEvolutionPreview(algo.Population, algo.Result)));

                var calculationForOneSpecimen = (cnt * algo.Population.Count) / (algo.Result.Count + 1);

                if (algo.Result.Count >= 10 && iterationsUntilFound10Specimens == 0)
                {
                    iterationsUntilFound10Specimens = cnt;
                }

                DoSafe(new Action(() =>
                {
                    labelAverageCalculationPerSpecimenByEvolution.Text = $"{calculationForOneSpecimen}";
                    labelIterationsUntilFirst10FoundByEvolution.Text = $"{iterationsUntilFound10Specimens}";
                    labelNumberOfFoundSpecimenByEvolution.Text = $"{algo.Result.Count}";
                    labelAverageCalculationPerSpecimenByEvolution.Refresh();
                    labelIterationsUntilFirst10FoundByEvolution.Refresh();
                    labelNumberOfFoundSpecimenByEvolution.Refresh();

                    labelIterationInfoForEvolutionAlgorithm.Text = $"It.#: {cnt}, # of calc: {cnt * algo.Population.Count}.";
                    labelIterationInfoForEvolutionAlgorithm.Refresh();
                }));
            }

            DoSafe(() =>
            {
                btnStartEvolution.Enabled = true;
                
                numericNumberOfIterations.Enabled = numericStartPopulationSize.Enabled
                    = comboboxTargetFunction.Enabled
                    = textboxAcceptingDistance.Enabled
                    = btnStartComparisonOfAlgorithms.Enabled
                    = btnStartEvolution.Enabled && btnStartEvolution.Enabled;
            });
        }

        private void RefreshEvolutionPreview(IEnumerable<ConcreteSpecimen> population, IEnumerable<ConcreteSpecimen> acceptedSpecimens)
        {
            var rect = new Rectangle(0, 0, imgWidth, imgHeight);

            var leftMiddle = Translate(-1, 0, imgWidth, imgHeight);
            var rightMiddle = Translate(1, 0, imgWidth, imgHeight);
            var topMiddle = Translate(0, 1, imgWidth, imgHeight);
            var bottomMiddle = Translate(0, -1, imgWidth, imgHeight);

            var b = Brushes.GreenYellow;
            var b2 = Brushes.Red;

            var bg = Graphics.FromImage(_bgImgEvolutionPreviewImage);
            var g = Graphics.FromImage(_imageEvolutionPreviewImage);

            bg.FillRectangle(Brushes.MidnightBlue, rect.X, rect.Y, rect.Width, rect.Height);

            g.Clear(Color.Transparent);

            // Print out whole population
            foreach (var item in population)
            {
                var position = Translate(item.X / 2.0d, item.Y / 2.0d, imgWidth, imgHeight);
                g.FillRectangle(b, position.x - 1, position.y - 1, 2, 2);
            }

            // Print out found specimens:
            foreach (var item in acceptedSpecimens)
            {
                var position = Translate(item.X / 2.0d, item.Y / 2.0d, imgWidth, imgHeight);
                g.FillRectangle(b2, position.x - 1, position.y - 1, 2, 2);
            }

            g.DrawLine(Pens.White, leftMiddle.x, leftMiddle.y, rightMiddle.x, rightMiddle.y);
            g.DrawLine(Pens.White, topMiddle.x, topMiddle.y, bottomMiddle.x, bottomMiddle.y);

            if(pictureboxEvolutionPreview.InvokeRequired)
            {
                pictureboxEvolutionPreview.Invoke(new Action(() => pictureboxEvolutionPreview.Refresh()));
            }
            else
            {
                pictureboxEvolutionPreview.Refresh();
            }
        }

        private void RefreshRandomPreview(IEnumerable<ConcreteSpecimen> population, IEnumerable<ConcreteSpecimen> acceptedSpecimens)
        {
            var rect = new Rectangle(0, 0, imgWidth, imgHeight);

            var leftMiddle = Translate(-1, 0, imgWidth, imgHeight);
            var rightMiddle = Translate(1, 0, imgWidth, imgHeight);
            var topMiddle = Translate(0, 1, imgWidth, imgHeight);
            var bottomMiddle = Translate(0, -1, imgWidth, imgHeight);

            var b = Brushes.GreenYellow;
            var b2 = Brushes.Red;

            var bg = Graphics.FromImage(_bgImgRandomPreviewImage);
            var g = Graphics.FromImage(_imageRandomPreviewImage);

            bg.FillRectangle(Brushes.MidnightBlue, rect.X, rect.Y, rect.Width, rect.Height);

            g.Clear(Color.Transparent);

            // Print out whole population
            foreach (var item in population)
            {
                var position = Translate(item.X / 2.0d, item.Y / 2.0d, imgWidth, imgHeight);
                g.FillRectangle(b, position.x - 1, position.y - 1, 2, 2);
            }

            // Print out found specimens:
            foreach (var item in acceptedSpecimens)
            {
                var position = Translate(item.X / 2.0d, item.Y / 2.0d, imgWidth, imgHeight);
                g.FillRectangle(b2, position.x - 1, position.y - 1, 2, 2);
            }

            g.DrawLine(Pens.White, leftMiddle.x, leftMiddle.y, rightMiddle.x, rightMiddle.y);
            g.DrawLine(Pens.White, topMiddle.x, topMiddle.y, bottomMiddle.x, bottomMiddle.y);

            if (pictureboxRandomPreview.InvokeRequired)
            {
                pictureboxRandomPreview.Invoke(new Action(() => pictureboxRandomPreview.Refresh()));
            }
            else
            {
                pictureboxRandomPreview.Refresh();
            }
        }

        private void StartRandomAlgo()
        {
            DoSafe(() =>
            {
                btnStartRandomAlgorithm.Enabled = false;
                btnStartComparisonOfAlgorithms.Enabled = false;
                numericNumberOfIterations.Enabled = false;
                numericStartPopulationSize.Enabled = false;
                comboboxTargetFunction.Enabled = false;
                textboxAcceptingDistance.Enabled = false;
            });

            var algo = BuildRandomAlgo();
            algo.Initialize((int)numericStartPopulationSize.Value);

            var cnt = 0;
            int iterationsUntilFound10Specimens = 0;

            while (cnt < (int)numericNumberOfIterations.Value)
            {
                cnt++;
                algo.Iterate();

                RefreshRandomPreview(algo.Population, algo.Result);

                var calculationForOneSpecimen = (cnt * algo.Population.Count) / (algo.Result.Count + 1);
                
                if(algo.Result.Count >= 10 && iterationsUntilFound10Specimens == 0)
                {
                    iterationsUntilFound10Specimens = cnt;
                }

                DoSafe(new Action(() =>
                {
                    labelAverageCalculationPerSpecimenByRandom.Text = $"{calculationForOneSpecimen}";
                    labelIterationsUntilFirst10FoundByRandom.Text = $"{iterationsUntilFound10Specimens}";
                    labelNumberOfFoundSpecimenByRandom.Text = $"{algo.Result.Count}";
                    labelAverageCalculationPerSpecimenByRandom.Refresh();
                    labelIterationsUntilFirst10FoundByRandom.Refresh();
                    labelNumberOfFoundSpecimenByRandom.Refresh();

                    labelIterationInfoForRandomAlgorithm.Text = $"It.#: {cnt}, # of calc: {cnt * algo.Population.Count}.";
                    labelIterationInfoForRandomAlgorithm.Refresh();
                }));
            }

            DoSafe(() =>
            {
                btnStartRandomAlgorithm.Enabled = true;

                numericNumberOfIterations.Enabled = numericStartPopulationSize.Enabled
                = comboboxTargetFunction.Enabled
                = textboxAcceptingDistance.Enabled
                = btnStartComparisonOfAlgorithms.Enabled
                = btnStartEvolution.Enabled && btnStartEvolution.Enabled;
            });
        }

        private void DoSafe(Action action)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
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
            var t2 = new Task(() => StartRandomAlgo());
            t2.Start();
        }

        private void btnCompareStart_Click(object sender, EventArgs e)
        {
            var t1 = new Task(() => StartAlgorithm());
            var t2 = new Task(() => StartRandomAlgo());
            t1.Start();
            t2.Start();
        }

        private void textboxAcceptingDistance_TextChanged(object sender, EventArgs e)
        {
            var isParsable = double.TryParse(textboxAcceptingDistance.Text, out _);

            btnStartComparisonOfAlgorithms.Enabled = btnStartEvolution.Enabled = btnStartRandomAlgorithm.Enabled = isParsable;
            textboxAcceptingDistance.BackColor = isParsable ? SystemColors.Window : Color.Red;
        }

        #region Resizer
        private float constantWidth = 2.33259f;
        private float constantHeight = 1;

        private int chromeWidth;
        private int chromeHeight;

        // From Windows SDK
        private const int WM_SIZING = 0x214;

        private const int WMSZ_LEFT = 1;
        private const int WMSZ_RIGHT = 2;
        private const int WMSZ_TOP = 3;
        private const int WMSZ_BOTTOM = 6;

        struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SIZING)
            {
                RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));

                int w = rc.Right - rc.Left - chromeWidth;
                int h = rc.Bottom - rc.Top - chromeHeight;

                switch (m.WParam.ToInt32()) // Resize handle
                {
                    case WMSZ_LEFT:
                    case WMSZ_RIGHT:
                        // Left or right handles, adjust height
                        rc.Bottom = rc.Top + chromeHeight + (int)(constantHeight * w / constantWidth);
                        break;

                    case WMSZ_TOP:
                    case WMSZ_BOTTOM:
                        // Top or bottom handles, adjust width
                        rc.Right = rc.Left + chromeWidth + (int)(constantWidth * h / constantHeight);
                        break;

                    case WMSZ_LEFT + WMSZ_TOP:
                    case WMSZ_LEFT + WMSZ_BOTTOM:
                        // Top-left or bottom-left handles, adjust width
                        rc.Left = rc.Right - chromeWidth - (int)(constantWidth * h / constantHeight);
                        break;

                    case WMSZ_RIGHT + WMSZ_TOP:
                        // Top-right handle, adjust height
                        rc.Top = rc.Bottom - chromeHeight - (int)(constantHeight * w / constantWidth);
                        break;

                    case WMSZ_RIGHT + WMSZ_BOTTOM:
                        // Bottom-right handle, adjust height
                        rc.Bottom = rc.Top + chromeHeight + (int)(constantHeight * w / constantWidth);
                        break;
                }

                Marshal.StructureToPtr(rc, m.LParam, true);
            }

            base.WndProc(ref m);
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
