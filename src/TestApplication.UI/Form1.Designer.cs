namespace TestApplication.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSettings = new System.Windows.Forms.Panel();
            this.groupboxStatistics = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelIterationsUntilFirst10FoundByRandom = new System.Windows.Forms.Label();
            this.labelIterationsUntilFirst10FoundByEvolution = new System.Windows.Forms.Label();
            this.labelIterationsUntilFirst10Found = new System.Windows.Forms.Label();
            this.btnStartEvolution = new System.Windows.Forms.Button();
            this.btnStartRandomAlgorithm = new System.Windows.Forms.Button();
            this.labelAverageCalculationPerSpecimenByRandom = new System.Windows.Forms.Label();
            this.labelAverageCalculationPerSpecimenByEvolution = new System.Windows.Forms.Label();
            this.labelAverageCalculationPerSpecimen = new System.Windows.Forms.Label();
            this.labelNumberOfFoundSpecimenByRandom = new System.Windows.Forms.Label();
            this.labelNumberOfFoundSpecimenByEvolution = new System.Windows.Forms.Label();
            this.labelEvolution = new System.Windows.Forms.Label();
            this.labelRandom = new System.Windows.Forms.Label();
            this.labelFoundSpecimens = new System.Windows.Forms.Label();
            this.btnStartComparisonOfAlgorithms = new System.Windows.Forms.Button();
            this.numericNumberOfIterations = new System.Windows.Forms.NumericUpDown();
            this.labelNumberOfIterations = new System.Windows.Forms.Label();
            this.comboboxTargetFunction = new System.Windows.Forms.ComboBox();
            this.labelTargetFunctionSelector = new System.Windows.Forms.Label();
            this.textboxAcceptingDistance = new System.Windows.Forms.TextBox();
            this.labelAcceptingDistance = new System.Windows.Forms.Label();
            this.numericStartPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.labelStartPopulation = new System.Windows.Forms.Label();
            this.pictureboxEvolutionPreview = new System.Windows.Forms.PictureBox();
            this.labelIterationInfoForEvolutionAlgorithm = new System.Windows.Forms.Label();
            this.pictureboxRandomPreview = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelIterationInfoForRandomAlgorithm = new System.Windows.Forms.Label();
            this.labelRandomPreview = new System.Windows.Forms.Label();
            this.labelEvolutionPreview = new System.Windows.Forms.Label();
            this.panelSettings.SuspendLayout();
            this.groupboxStatistics.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberOfIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStartPopulationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxEvolutionPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxRandomPreview)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.groupboxStatistics);
            this.panelSettings.Controls.Add(this.numericNumberOfIterations);
            this.panelSettings.Controls.Add(this.labelNumberOfIterations);
            this.panelSettings.Controls.Add(this.comboboxTargetFunction);
            this.panelSettings.Controls.Add(this.labelTargetFunctionSelector);
            this.panelSettings.Controls.Add(this.textboxAcceptingDistance);
            this.panelSettings.Controls.Add(this.labelAcceptingDistance);
            this.panelSettings.Controls.Add(this.numericStartPopulationSize);
            this.panelSettings.Controls.Add(this.labelStartPopulation);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSettings.Location = new System.Drawing.Point(805, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Padding = new System.Windows.Forms.Padding(6);
            this.panelSettings.Size = new System.Drawing.Size(247, 451);
            this.panelSettings.TabIndex = 0;
            // 
            // groupboxStatistics
            // 
            this.groupboxStatistics.Controls.Add(this.tableLayoutPanel1);
            this.groupboxStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupboxStatistics.Location = new System.Drawing.Point(6, 179);
            this.groupboxStatistics.Name = "groupboxStatistics";
            this.groupboxStatistics.Size = new System.Drawing.Size(235, 266);
            this.groupboxStatistics.TabIndex = 10;
            this.groupboxStatistics.TabStop = false;
            this.groupboxStatistics.Text = "Statistics";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelIterationsUntilFirst10FoundByRandom, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelIterationsUntilFirst10FoundByEvolution, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelIterationsUntilFirst10Found, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnStartEvolution, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnStartRandomAlgorithm, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelAverageCalculationPerSpecimenByRandom, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelAverageCalculationPerSpecimenByEvolution, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelAverageCalculationPerSpecimen, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelNumberOfFoundSpecimenByRandom, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelNumberOfFoundSpecimenByEvolution, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelEvolution, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelRandom, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelFoundSpecimens, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnStartComparisonOfAlgorithms, 0, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(229, 247);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelIterationsUntilFirst10FoundByRandom
            // 
            this.labelIterationsUntilFirst10FoundByRandom.AutoSize = true;
            this.labelIterationsUntilFirst10FoundByRandom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelIterationsUntilFirst10FoundByRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIterationsUntilFirst10FoundByRandom.Location = new System.Drawing.Point(117, 150);
            this.labelIterationsUntilFirst10FoundByRandom.Name = "labelIterationsUntilFirst10FoundByRandom";
            this.labelIterationsUntilFirst10FoundByRandom.Size = new System.Drawing.Size(109, 25);
            this.labelIterationsUntilFirst10FoundByRandom.TabIndex = 10;
            this.labelIterationsUntilFirst10FoundByRandom.Text = "-";
            this.labelIterationsUntilFirst10FoundByRandom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelIterationsUntilFirst10FoundByEvolution
            // 
            this.labelIterationsUntilFirst10FoundByEvolution.AutoSize = true;
            this.labelIterationsUntilFirst10FoundByEvolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelIterationsUntilFirst10FoundByEvolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIterationsUntilFirst10FoundByEvolution.Location = new System.Drawing.Point(3, 150);
            this.labelIterationsUntilFirst10FoundByEvolution.Name = "labelIterationsUntilFirst10FoundByEvolution";
            this.labelIterationsUntilFirst10FoundByEvolution.Size = new System.Drawing.Size(108, 25);
            this.labelIterationsUntilFirst10FoundByEvolution.TabIndex = 9;
            this.labelIterationsUntilFirst10FoundByEvolution.Text = "-";
            this.labelIterationsUntilFirst10FoundByEvolution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelIterationsUntilFirst10Found
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.labelIterationsUntilFirst10Found, 2);
            this.labelIterationsUntilFirst10Found.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelIterationsUntilFirst10Found.Location = new System.Drawing.Point(3, 125);
            this.labelIterationsUntilFirst10Found.Name = "labelIterationsUntilFirst10Found";
            this.labelIterationsUntilFirst10Found.Size = new System.Drawing.Size(223, 25);
            this.labelIterationsUntilFirst10Found.TabIndex = 8;
            this.labelIterationsUntilFirst10Found.Text = "Iterations until first 10 found";
            this.labelIterationsUntilFirst10Found.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnStartEvolution
            // 
            this.btnStartEvolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartEvolution.Location = new System.Drawing.Point(3, 190);
            this.btnStartEvolution.Name = "btnStartEvolution";
            this.btnStartEvolution.Size = new System.Drawing.Size(108, 24);
            this.btnStartEvolution.TabIndex = 6;
            this.btnStartEvolution.Text = "Run Evolution";
            this.btnStartEvolution.UseVisualStyleBackColor = true;
            this.btnStartEvolution.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnStartRandomAlgorithm
            // 
            this.btnStartRandomAlgorithm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartRandomAlgorithm.Location = new System.Drawing.Point(117, 190);
            this.btnStartRandomAlgorithm.Name = "btnStartRandomAlgorithm";
            this.btnStartRandomAlgorithm.Size = new System.Drawing.Size(109, 24);
            this.btnStartRandomAlgorithm.TabIndex = 7;
            this.btnStartRandomAlgorithm.Text = "Run random";
            this.btnStartRandomAlgorithm.UseVisualStyleBackColor = true;
            this.btnStartRandomAlgorithm.Click += new System.EventHandler(this.btnStartStopRandomAlgo_Click);
            // 
            // labelAverageCalculationPerSpecimenByRandom
            // 
            this.labelAverageCalculationPerSpecimenByRandom.AutoSize = true;
            this.labelAverageCalculationPerSpecimenByRandom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAverageCalculationPerSpecimenByRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAverageCalculationPerSpecimenByRandom.Location = new System.Drawing.Point(117, 100);
            this.labelAverageCalculationPerSpecimenByRandom.Name = "labelAverageCalculationPerSpecimenByRandom";
            this.labelAverageCalculationPerSpecimenByRandom.Size = new System.Drawing.Size(109, 25);
            this.labelAverageCalculationPerSpecimenByRandom.TabIndex = 7;
            this.labelAverageCalculationPerSpecimenByRandom.Text = "-";
            this.labelAverageCalculationPerSpecimenByRandom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAverageCalculationPerSpecimenByEvolution
            // 
            this.labelAverageCalculationPerSpecimenByEvolution.AutoSize = true;
            this.labelAverageCalculationPerSpecimenByEvolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAverageCalculationPerSpecimenByEvolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAverageCalculationPerSpecimenByEvolution.Location = new System.Drawing.Point(3, 100);
            this.labelAverageCalculationPerSpecimenByEvolution.Name = "labelAverageCalculationPerSpecimenByEvolution";
            this.labelAverageCalculationPerSpecimenByEvolution.Size = new System.Drawing.Size(108, 25);
            this.labelAverageCalculationPerSpecimenByEvolution.TabIndex = 6;
            this.labelAverageCalculationPerSpecimenByEvolution.Text = "-";
            this.labelAverageCalculationPerSpecimenByEvolution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAverageCalculationPerSpecimen
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.labelAverageCalculationPerSpecimen, 2);
            this.labelAverageCalculationPerSpecimen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAverageCalculationPerSpecimen.Location = new System.Drawing.Point(3, 75);
            this.labelAverageCalculationPerSpecimen.Name = "labelAverageCalculationPerSpecimen";
            this.labelAverageCalculationPerSpecimen.Size = new System.Drawing.Size(223, 25);
            this.labelAverageCalculationPerSpecimen.TabIndex = 5;
            this.labelAverageCalculationPerSpecimen.Text = "Average calculation per specimen";
            this.labelAverageCalculationPerSpecimen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelNumberOfFoundSpecimenByRandom
            // 
            this.labelNumberOfFoundSpecimenByRandom.AutoSize = true;
            this.labelNumberOfFoundSpecimenByRandom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNumberOfFoundSpecimenByRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfFoundSpecimenByRandom.Location = new System.Drawing.Point(117, 50);
            this.labelNumberOfFoundSpecimenByRandom.Name = "labelNumberOfFoundSpecimenByRandom";
            this.labelNumberOfFoundSpecimenByRandom.Size = new System.Drawing.Size(109, 25);
            this.labelNumberOfFoundSpecimenByRandom.TabIndex = 4;
            this.labelNumberOfFoundSpecimenByRandom.Text = "-";
            this.labelNumberOfFoundSpecimenByRandom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNumberOfFoundSpecimenByEvolution
            // 
            this.labelNumberOfFoundSpecimenByEvolution.AutoSize = true;
            this.labelNumberOfFoundSpecimenByEvolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNumberOfFoundSpecimenByEvolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfFoundSpecimenByEvolution.Location = new System.Drawing.Point(3, 50);
            this.labelNumberOfFoundSpecimenByEvolution.Name = "labelNumberOfFoundSpecimenByEvolution";
            this.labelNumberOfFoundSpecimenByEvolution.Size = new System.Drawing.Size(108, 25);
            this.labelNumberOfFoundSpecimenByEvolution.TabIndex = 3;
            this.labelNumberOfFoundSpecimenByEvolution.Text = "-";
            this.labelNumberOfFoundSpecimenByEvolution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEvolution
            // 
            this.labelEvolution.AutoSize = true;
            this.labelEvolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEvolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEvolution.Location = new System.Drawing.Point(3, 0);
            this.labelEvolution.Name = "labelEvolution";
            this.labelEvolution.Size = new System.Drawing.Size(108, 25);
            this.labelEvolution.TabIndex = 0;
            this.labelEvolution.Text = "Evolution";
            this.labelEvolution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRandom
            // 
            this.labelRandom.AutoSize = true;
            this.labelRandom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRandom.Location = new System.Drawing.Point(117, 0);
            this.labelRandom.Name = "labelRandom";
            this.labelRandom.Size = new System.Drawing.Size(109, 25);
            this.labelRandom.TabIndex = 1;
            this.labelRandom.Text = "Random";
            this.labelRandom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFoundSpecimens
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.labelFoundSpecimens, 2);
            this.labelFoundSpecimens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFoundSpecimens.Location = new System.Drawing.Point(3, 25);
            this.labelFoundSpecimens.Name = "labelFoundSpecimens";
            this.labelFoundSpecimens.Size = new System.Drawing.Size(223, 25);
            this.labelFoundSpecimens.TabIndex = 2;
            this.labelFoundSpecimens.Text = "Number of found Specimen";
            this.labelFoundSpecimens.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnStartComparisonOfAlgorithms
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnStartComparisonOfAlgorithms, 2);
            this.btnStartComparisonOfAlgorithms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartComparisonOfAlgorithms.Location = new System.Drawing.Point(3, 220);
            this.btnStartComparisonOfAlgorithms.Name = "btnStartComparisonOfAlgorithms";
            this.btnStartComparisonOfAlgorithms.Size = new System.Drawing.Size(223, 24);
            this.btnStartComparisonOfAlgorithms.TabIndex = 11;
            this.btnStartComparisonOfAlgorithms.Text = "Run Compare";
            this.btnStartComparisonOfAlgorithms.UseVisualStyleBackColor = true;
            this.btnStartComparisonOfAlgorithms.Click += new System.EventHandler(this.btnCompareStart_Click);
            // 
            // numericNumberOfIterations
            // 
            this.numericNumberOfIterations.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericNumberOfIterations.Location = new System.Drawing.Point(6, 159);
            this.numericNumberOfIterations.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericNumberOfIterations.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericNumberOfIterations.Name = "numericNumberOfIterations";
            this.numericNumberOfIterations.Size = new System.Drawing.Size(235, 20);
            this.numericNumberOfIterations.TabIndex = 9;
            this.numericNumberOfIterations.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // labelNumberOfIterations
            // 
            this.labelNumberOfIterations.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNumberOfIterations.Location = new System.Drawing.Point(6, 134);
            this.labelNumberOfIterations.Name = "labelNumberOfIterations";
            this.labelNumberOfIterations.Size = new System.Drawing.Size(235, 25);
            this.labelNumberOfIterations.TabIndex = 8;
            this.labelNumberOfIterations.Text = "Number of iterations";
            this.labelNumberOfIterations.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // comboboxTargetFunction
            // 
            this.comboboxTargetFunction.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboboxTargetFunction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboboxTargetFunction.FormattingEnabled = true;
            this.comboboxTargetFunction.Location = new System.Drawing.Point(6, 113);
            this.comboboxTargetFunction.Name = "comboboxTargetFunction";
            this.comboboxTargetFunction.Size = new System.Drawing.Size(235, 21);
            this.comboboxTargetFunction.TabIndex = 5;
            // 
            // labelTargetFunctionSelector
            // 
            this.labelTargetFunctionSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTargetFunctionSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTargetFunctionSelector.Location = new System.Drawing.Point(6, 88);
            this.labelTargetFunctionSelector.Name = "labelTargetFunctionSelector";
            this.labelTargetFunctionSelector.Size = new System.Drawing.Size(235, 25);
            this.labelTargetFunctionSelector.TabIndex = 4;
            this.labelTargetFunctionSelector.Text = "Target Function";
            this.labelTargetFunctionSelector.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textboxAcceptingDistance
            // 
            this.textboxAcceptingDistance.Dock = System.Windows.Forms.DockStyle.Top;
            this.textboxAcceptingDistance.Location = new System.Drawing.Point(6, 68);
            this.textboxAcceptingDistance.Name = "textboxAcceptingDistance";
            this.textboxAcceptingDistance.Size = new System.Drawing.Size(235, 20);
            this.textboxAcceptingDistance.TabIndex = 3;
            this.textboxAcceptingDistance.Text = "0.1";
            this.textboxAcceptingDistance.TextChanged += new System.EventHandler(this.textboxAcceptingDistance_TextChanged);
            // 
            // labelAcceptingDistance
            // 
            this.labelAcceptingDistance.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelAcceptingDistance.Location = new System.Drawing.Point(6, 43);
            this.labelAcceptingDistance.Name = "labelAcceptingDistance";
            this.labelAcceptingDistance.Size = new System.Drawing.Size(235, 25);
            this.labelAcceptingDistance.TabIndex = 2;
            this.labelAcceptingDistance.Text = "Accepting Distance";
            this.labelAcceptingDistance.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // numericStartPopulationSize
            // 
            this.numericStartPopulationSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericStartPopulationSize.Location = new System.Drawing.Point(6, 23);
            this.numericStartPopulationSize.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericStartPopulationSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericStartPopulationSize.Name = "numericStartPopulationSize";
            this.numericStartPopulationSize.Size = new System.Drawing.Size(235, 20);
            this.numericStartPopulationSize.TabIndex = 1;
            this.numericStartPopulationSize.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // labelStartPopulation
            // 
            this.labelStartPopulation.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStartPopulation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelStartPopulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartPopulation.Location = new System.Drawing.Point(6, 6);
            this.labelStartPopulation.Name = "labelStartPopulation";
            this.labelStartPopulation.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelStartPopulation.Size = new System.Drawing.Size(235, 17);
            this.labelStartPopulation.TabIndex = 0;
            this.labelStartPopulation.Text = "Start population size";
            this.labelStartPopulation.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pictureboxEvolutionPreview
            // 
            this.pictureboxEvolutionPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureboxEvolutionPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureboxEvolutionPreview.Location = new System.Drawing.Point(3, 3);
            this.pictureboxEvolutionPreview.Name = "pictureboxEvolutionPreview";
            this.pictureboxEvolutionPreview.Size = new System.Drawing.Size(396, 405);
            this.pictureboxEvolutionPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureboxEvolutionPreview.TabIndex = 1;
            this.pictureboxEvolutionPreview.TabStop = false;
            // 
            // labelIterationInfoForEvolutionAlgorithm
            // 
            this.labelIterationInfoForEvolutionAlgorithm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelIterationInfoForEvolutionAlgorithm.Location = new System.Drawing.Point(3, 431);
            this.labelIterationInfoForEvolutionAlgorithm.Name = "labelIterationInfoForEvolutionAlgorithm";
            this.labelIterationInfoForEvolutionAlgorithm.Size = new System.Drawing.Size(396, 20);
            this.labelIterationInfoForEvolutionAlgorithm.TabIndex = 2;
            this.labelIterationInfoForEvolutionAlgorithm.Text = "-";
            this.labelIterationInfoForEvolutionAlgorithm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureboxRandomPreview
            // 
            this.pictureboxRandomPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureboxRandomPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureboxRandomPreview.Location = new System.Drawing.Point(405, 3);
            this.pictureboxRandomPreview.Name = "pictureboxRandomPreview";
            this.pictureboxRandomPreview.Size = new System.Drawing.Size(397, 405);
            this.pictureboxRandomPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureboxRandomPreview.TabIndex = 3;
            this.pictureboxRandomPreview.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.labelIterationInfoForRandomAlgorithm, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelRandomPreview, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelEvolutionPreview, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pictureboxRandomPreview, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureboxEvolutionPreview, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelIterationInfoForEvolutionAlgorithm, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(805, 451);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // labelIterationInfoForRandomAlgorithm
            // 
            this.labelIterationInfoForRandomAlgorithm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelIterationInfoForRandomAlgorithm.Location = new System.Drawing.Point(405, 431);
            this.labelIterationInfoForRandomAlgorithm.Name = "labelIterationInfoForRandomAlgorithm";
            this.labelIterationInfoForRandomAlgorithm.Size = new System.Drawing.Size(397, 20);
            this.labelIterationInfoForRandomAlgorithm.TabIndex = 6;
            this.labelIterationInfoForRandomAlgorithm.Text = "-";
            this.labelIterationInfoForRandomAlgorithm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRandomPreview
            // 
            this.labelRandomPreview.Location = new System.Drawing.Point(405, 411);
            this.labelRandomPreview.Name = "labelRandomPreview";
            this.labelRandomPreview.Size = new System.Drawing.Size(397, 13);
            this.labelRandomPreview.TabIndex = 5;
            this.labelRandomPreview.Text = "Random preview";
            this.labelRandomPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEvolutionPreview
            // 
            this.labelEvolutionPreview.Location = new System.Drawing.Point(3, 411);
            this.labelEvolutionPreview.Name = "labelEvolutionPreview";
            this.labelEvolutionPreview.Size = new System.Drawing.Size(396, 13);
            this.labelEvolutionPreview.TabIndex = 4;
            this.labelEvolutionPreview.Text = "Evolution preview";
            this.labelEvolutionPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 451);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelSettings);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1068, 490);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Genetic Algorithm Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.groupboxStatistics.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberOfIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStartPopulationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxEvolutionPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxRandomPreview)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label labelAcceptingDistance;
        private System.Windows.Forms.NumericUpDown numericStartPopulationSize;
        private System.Windows.Forms.Label labelStartPopulation;
        private System.Windows.Forms.Button btnStartEvolution;
        private System.Windows.Forms.ComboBox comboboxTargetFunction;
        private System.Windows.Forms.Label labelTargetFunctionSelector;
        private System.Windows.Forms.TextBox textboxAcceptingDistance;
        private System.Windows.Forms.PictureBox pictureboxEvolutionPreview;
        private System.Windows.Forms.Label labelIterationInfoForEvolutionAlgorithm;
        private System.Windows.Forms.Button btnStartRandomAlgorithm;
        private System.Windows.Forms.NumericUpDown numericNumberOfIterations;
        private System.Windows.Forms.Label labelNumberOfIterations;
        private System.Windows.Forms.GroupBox groupboxStatistics;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelEvolution;
        private System.Windows.Forms.Label labelRandom;
        private System.Windows.Forms.Label labelFoundSpecimens;
        private System.Windows.Forms.Label labelIterationsUntilFirst10FoundByRandom;
        private System.Windows.Forms.Label labelIterationsUntilFirst10FoundByEvolution;
        private System.Windows.Forms.Label labelIterationsUntilFirst10Found;
        private System.Windows.Forms.Label labelAverageCalculationPerSpecimenByRandom;
        private System.Windows.Forms.Label labelAverageCalculationPerSpecimenByEvolution;
        private System.Windows.Forms.Label labelAverageCalculationPerSpecimen;
        private System.Windows.Forms.Label labelNumberOfFoundSpecimenByRandom;
        private System.Windows.Forms.Label labelNumberOfFoundSpecimenByEvolution;
        private System.Windows.Forms.Button btnStartComparisonOfAlgorithms;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelRandomPreview;
        private System.Windows.Forms.Label labelEvolutionPreview;
        private System.Windows.Forms.PictureBox pictureboxRandomPreview;
        private System.Windows.Forms.Label labelIterationInfoForRandomAlgorithm;
    }
}

