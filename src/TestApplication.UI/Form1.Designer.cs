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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelSettings = new System.Windows.Forms.Panel();
            this.labelIterationInfoForEvolutionAlgorithm = new System.Windows.Forms.Label();
            this.numericNumberOfIterations = new System.Windows.Forms.NumericUpDown();
            this.labelNumberOfIterations = new System.Windows.Forms.Label();
            this.btnStartEvolution = new System.Windows.Forms.Button();
            this.comboboxTargetFunction = new System.Windows.Forms.ComboBox();
            this.labelTargetFunctionSelector = new System.Windows.Forms.Label();
            this.numericStartPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.labelStartPopulation = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelMousePositionHeader = new System.Windows.Forms.Label();
            this.labelMousePositionValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCoordinatePositionValue = new System.Windows.Forms.Label();
            this.labelFunctionValueCaption = new System.Windows.Forms.Label();
            this.labelFunctionValue = new System.Windows.Forms.Label();
            this.labelFunctionDerivativeCaption = new System.Windows.Forms.Label();
            this.labelFunctionDerivativeValue = new System.Windows.Forms.Label();
            this.labelCoordinateLimitsCaption = new System.Windows.Forms.Label();
            this.labelCoordinateLimitsValue = new System.Windows.Forms.Label();
            this.functionGraph1 = new TestApplication.UI.FunctionGraph();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberOfIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStartPopulationSize)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.tableLayoutPanel1);
            this.panelSettings.Controls.Add(this.labelIterationInfoForEvolutionAlgorithm);
            this.panelSettings.Controls.Add(this.numericNumberOfIterations);
            this.panelSettings.Controls.Add(this.labelNumberOfIterations);
            this.panelSettings.Controls.Add(this.btnStartEvolution);
            this.panelSettings.Controls.Add(this.comboboxTargetFunction);
            this.panelSettings.Controls.Add(this.labelTargetFunctionSelector);
            this.panelSettings.Controls.Add(this.numericStartPopulationSize);
            this.panelSettings.Controls.Add(this.labelStartPopulation);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSettings.Location = new System.Drawing.Point(731, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Padding = new System.Windows.Forms.Padding(6);
            this.panelSettings.Size = new System.Drawing.Size(333, 461);
            this.panelSettings.TabIndex = 0;
            // 
            // labelIterationInfoForEvolutionAlgorithm
            // 
            this.labelIterationInfoForEvolutionAlgorithm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelIterationInfoForEvolutionAlgorithm.Location = new System.Drawing.Point(6, 402);
            this.labelIterationInfoForEvolutionAlgorithm.Name = "labelIterationInfoForEvolutionAlgorithm";
            this.labelIterationInfoForEvolutionAlgorithm.Size = new System.Drawing.Size(321, 29);
            this.labelIterationInfoForEvolutionAlgorithm.TabIndex = 2;
            this.labelIterationInfoForEvolutionAlgorithm.Text = "-";
            this.labelIterationInfoForEvolutionAlgorithm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericNumberOfIterations
            // 
            this.numericNumberOfIterations.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericNumberOfIterations.Location = new System.Drawing.Point(6, 114);
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
            this.numericNumberOfIterations.Size = new System.Drawing.Size(321, 20);
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
            this.labelNumberOfIterations.Location = new System.Drawing.Point(6, 89);
            this.labelNumberOfIterations.Name = "labelNumberOfIterations";
            this.labelNumberOfIterations.Size = new System.Drawing.Size(321, 25);
            this.labelNumberOfIterations.TabIndex = 8;
            this.labelNumberOfIterations.Text = "Number of iterations";
            this.labelNumberOfIterations.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnStartEvolution
            // 
            this.btnStartEvolution.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStartEvolution.Location = new System.Drawing.Point(6, 431);
            this.btnStartEvolution.Name = "btnStartEvolution";
            this.btnStartEvolution.Size = new System.Drawing.Size(321, 24);
            this.btnStartEvolution.TabIndex = 6;
            this.btnStartEvolution.Text = "Run Evolution";
            this.btnStartEvolution.UseVisualStyleBackColor = true;
            this.btnStartEvolution.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // comboboxTargetFunction
            // 
            this.comboboxTargetFunction.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboboxTargetFunction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboboxTargetFunction.FormattingEnabled = true;
            this.comboboxTargetFunction.Location = new System.Drawing.Point(6, 68);
            this.comboboxTargetFunction.Name = "comboboxTargetFunction";
            this.comboboxTargetFunction.Size = new System.Drawing.Size(321, 21);
            this.comboboxTargetFunction.TabIndex = 5;
            this.comboboxTargetFunction.SelectedIndexChanged += new System.EventHandler(this.comboboxTargetFunction_SelectedIndexChanged);
            // 
            // labelTargetFunctionSelector
            // 
            this.labelTargetFunctionSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTargetFunctionSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTargetFunctionSelector.Location = new System.Drawing.Point(6, 43);
            this.labelTargetFunctionSelector.Name = "labelTargetFunctionSelector";
            this.labelTargetFunctionSelector.Size = new System.Drawing.Size(321, 25);
            this.labelTargetFunctionSelector.TabIndex = 4;
            this.labelTargetFunctionSelector.Text = "Target Function";
            this.labelTargetFunctionSelector.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.numericStartPopulationSize.Size = new System.Drawing.Size(321, 20);
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
            this.labelStartPopulation.Size = new System.Drawing.Size(321, 17);
            this.labelStartPopulation.TabIndex = 0;
            this.labelStartPopulation.Text = "Start population size";
            this.labelStartPopulation.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.functionGraph1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 461F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(731, 461);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelFunctionValue, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelFunctionValueCaption, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelCoordinatePositionValue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelMousePositionValue, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelMousePositionHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelFunctionDerivativeCaption, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelFunctionDerivativeValue, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelCoordinateLimitsCaption, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelCoordinateLimitsValue, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 134);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(321, 268);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // labelMousePositionHeader
            // 
            this.labelMousePositionHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMousePositionHeader.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMousePositionHeader.Location = new System.Drawing.Point(3, 0);
            this.labelMousePositionHeader.Name = "labelMousePositionHeader";
            this.labelMousePositionHeader.Size = new System.Drawing.Size(154, 40);
            this.labelMousePositionHeader.TabIndex = 0;
            this.labelMousePositionHeader.Text = "Mouse position";
            this.labelMousePositionHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMousePositionValue
            // 
            this.labelMousePositionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMousePositionValue.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMousePositionValue.Location = new System.Drawing.Point(163, 0);
            this.labelMousePositionValue.Name = "labelMousePositionValue";
            this.labelMousePositionValue.Size = new System.Drawing.Size(155, 40);
            this.labelMousePositionValue.TabIndex = 1;
            this.labelMousePositionValue.Text = "X: -\r\nY: -";
            this.labelMousePositionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "Coordinate position";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCoordinatePositionValue
            // 
            this.labelCoordinatePositionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCoordinatePositionValue.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCoordinatePositionValue.Location = new System.Drawing.Point(163, 40);
            this.labelCoordinatePositionValue.Name = "labelCoordinatePositionValue";
            this.labelCoordinatePositionValue.Size = new System.Drawing.Size(155, 40);
            this.labelCoordinatePositionValue.TabIndex = 3;
            this.labelCoordinatePositionValue.Text = "X: -\r\nY: -";
            this.labelCoordinatePositionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFunctionValueCaption
            // 
            this.labelFunctionValueCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFunctionValueCaption.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFunctionValueCaption.Location = new System.Drawing.Point(3, 80);
            this.labelFunctionValueCaption.Name = "labelFunctionValueCaption";
            this.labelFunctionValueCaption.Size = new System.Drawing.Size(154, 20);
            this.labelFunctionValueCaption.TabIndex = 4;
            this.labelFunctionValueCaption.Text = "f(cX)=";
            this.labelFunctionValueCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFunctionValue
            // 
            this.labelFunctionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFunctionValue.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFunctionValue.Location = new System.Drawing.Point(163, 80);
            this.labelFunctionValue.Name = "labelFunctionValue";
            this.labelFunctionValue.Size = new System.Drawing.Size(155, 20);
            this.labelFunctionValue.TabIndex = 5;
            this.labelFunctionValue.Text = "-";
            this.labelFunctionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFunctionDerivativeCaption
            // 
            this.labelFunctionDerivativeCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFunctionDerivativeCaption.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFunctionDerivativeCaption.Location = new System.Drawing.Point(3, 100);
            this.labelFunctionDerivativeCaption.Name = "labelFunctionDerivativeCaption";
            this.labelFunctionDerivativeCaption.Size = new System.Drawing.Size(154, 20);
            this.labelFunctionDerivativeCaption.TabIndex = 6;
            this.labelFunctionDerivativeCaption.Text = "f\'(cX)=";
            this.labelFunctionDerivativeCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFunctionDerivativeValue
            // 
            this.labelFunctionDerivativeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFunctionDerivativeValue.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFunctionDerivativeValue.Location = new System.Drawing.Point(163, 100);
            this.labelFunctionDerivativeValue.Name = "labelFunctionDerivativeValue";
            this.labelFunctionDerivativeValue.Size = new System.Drawing.Size(155, 20);
            this.labelFunctionDerivativeValue.TabIndex = 7;
            this.labelFunctionDerivativeValue.Text = "-";
            this.labelFunctionDerivativeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCoordinateLimitsCaption
            // 
            this.labelCoordinateLimitsCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCoordinateLimitsCaption.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCoordinateLimitsCaption.Location = new System.Drawing.Point(3, 120);
            this.labelCoordinateLimitsCaption.Name = "labelCoordinateLimitsCaption";
            this.labelCoordinateLimitsCaption.Size = new System.Drawing.Size(154, 40);
            this.labelCoordinateLimitsCaption.TabIndex = 8;
            this.labelCoordinateLimitsCaption.Text = "Coordinate limits";
            this.labelCoordinateLimitsCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCoordinateLimitsValue
            // 
            this.labelCoordinateLimitsValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCoordinateLimitsValue.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCoordinateLimitsValue.Location = new System.Drawing.Point(163, 120);
            this.labelCoordinateLimitsValue.Name = "labelCoordinateLimitsValue";
            this.labelCoordinateLimitsValue.Size = new System.Drawing.Size(155, 40);
            this.labelCoordinateLimitsValue.TabIndex = 9;
            this.labelCoordinateLimitsValue.Text = "X:[-999...999]\r\nY:[-999...999]";
            this.labelCoordinateLimitsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // functionGraph1
            // 
            this.functionGraph1.AxesFont = new System.Drawing.Font("Courier New", 12F);
            this.functionGraph1.AxisColor = System.Drawing.Color.Black;
            this.functionGraph1.BackColor = System.Drawing.Color.White;
            this.functionGraph1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.functionGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.functionGraph1.GraphColor = System.Drawing.Color.Blue;
            this.functionGraph1.Location = new System.Drawing.Point(3, 3);
            this.functionGraph1.MaximumX = 2D;
            this.functionGraph1.MaximumY = 2D;
            this.functionGraph1.MinimumX = -2D;
            this.functionGraph1.MinimumY = -2D;
            this.functionGraph1.Name = "functionGraph1";
            this.functionGraph1.Size = new System.Drawing.Size(725, 455);
            this.functionGraph1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.functionGraph1.TabIndex = 3;
            this.functionGraph1.StatsChanged += new System.EventHandler(this.functionGraph1_StatsChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 461);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelSettings);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Genetic Algorithm Test";
            this.panelSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberOfIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStartPopulationSize)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.NumericUpDown numericStartPopulationSize;
        private System.Windows.Forms.Label labelStartPopulation;
        private System.Windows.Forms.ComboBox comboboxTargetFunction;
        private System.Windows.Forms.Label labelTargetFunctionSelector;
        private System.Windows.Forms.NumericUpDown numericNumberOfIterations;
        private System.Windows.Forms.Label labelNumberOfIterations;
        private System.Windows.Forms.Button btnStartEvolution;
        private System.Windows.Forms.Label labelIterationInfoForEvolutionAlgorithm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private FunctionGraph functionGraph1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelFunctionValue;
        private System.Windows.Forms.Label labelFunctionValueCaption;
        private System.Windows.Forms.Label labelCoordinatePositionValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMousePositionValue;
        private System.Windows.Forms.Label labelMousePositionHeader;
        private System.Windows.Forms.Label labelFunctionDerivativeCaption;
        private System.Windows.Forms.Label labelFunctionDerivativeValue;
        private System.Windows.Forms.Label labelCoordinateLimitsCaption;
        private System.Windows.Forms.Label labelCoordinateLimitsValue;
    }
}

