using System;
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
        private enum Function
        {
            /// <summary>
            /// Double waving function
            /// f(x) = (cos(x) * cos(5x)) * sin(10x)
            /// </summary>
            DoubleWaving,
            
            /// <summary>
            /// Sin(x) * |x|
            /// </summary>
            SinusXAbsoluteX,

            /// <summary>
            /// Tan(x)
            /// </summary>
            Tangent
        }

        private class FunctionDescription
        {
            public FunctionDescription(string title, Function funcEnum, Func<double, double> function)
            {
                Title = title;
                FunctionEnum = funcEnum;
                Function = function;
            }

            public Func<double, double> Function { get; }

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

            _functions = new Dictionary<int, FunctionDescription>()
            {
                { 0, new FunctionDescription("Double Waving", Function.DoubleWaving, (x) => Math.Cos(x) * Math.Cos(5*x) * Math.Sin(10*x)) },
                { 1, new FunctionDescription("sin(x) * |x|", Function.SinusXAbsoluteX, (x) => Math.Sin(x) * Math.Abs(x)) },
                { 2, new FunctionDescription("tan(x)", Function.Tangent, (x) => Math.Tan(x)) }
            };

            comboboxTargetFunction.Items.AddRange(_functions.Values.ToArray());
            comboboxTargetFunction.SelectedIndex = 0;
        }

        private IEvolutionRunner<ConcreteSpecimen> Build()
        {
            // Used to build the starter population:
            var builder = new ConcretePopulationBuilder();

            // Used to define the fitness function.
            var fitnessProvider = new ConcreteFitnessProvider(GetSelectedFunction().Function);

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

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            var t1 = new Task(() => StartAlgorithm());
            t1.Start();
        }

        private void StartAlgorithm()
        {
            //DoSafe(() =>
            //{
            //    btnStartEvolution.Enabled = false;
            //    numericNumberOfIterations.Enabled = false;
            //    numericStartPopulationSize.Enabled = false;
            //    comboboxTargetFunction.Enabled = false;
            //});

            //var algo = Build();
            //algo.Initialize((int)numericStartPopulationSize.Value);

            //var cnt = 0;

            //while (cnt < (int)numericNumberOfIterations.Value)
            //{
            //    cnt++;
            //    algo.Iterate();

            //    DoSafe(new Action(() => RefreshEvolutionPreview(algo.Population)));

            //    DoSafe(new Action(() =>
            //    {
            //        labelIterationInfoForEvolutionAlgorithm.Text = $"It.#: {cnt}, # of calc: {cnt * algo.Population.Count}.";
            //        labelIterationInfoForEvolutionAlgorithm.Refresh();
            //    }));
            //}

            //DoSafe(() =>
            //{
            //    btnStartEvolution.Enabled = true;
                
            //    numericNumberOfIterations.Enabled = numericStartPopulationSize.Enabled
            //        = comboboxTargetFunction.Enabled
            //        = btnStartEvolution.Enabled && btnStartEvolution.Enabled;
            //});
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

        private void comboboxTargetFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = (FunctionDescription)comboboxTargetFunction.SelectedItem;

            functionGraph1.SetFunction(selectedItem.Function);
        }
    }
}
