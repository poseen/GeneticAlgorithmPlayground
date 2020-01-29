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
            this.btnStartStopRandomAlgo = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.comboboxTargetFunction = new System.Windows.Forms.ComboBox();
            this.labelTargetFunctionSelector = new System.Windows.Forms.Label();
            this.textboxAcceptingDistance = new System.Windows.Forms.TextBox();
            this.labelAcceptingDistance = new System.Windows.Forms.Label();
            this.numericStartPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.labelStartPopulation = new System.Windows.Forms.Label();
            this.pictureboxPreview = new System.Windows.Forms.PictureBox();
            this.labelStatistics = new System.Windows.Forms.Label();
            this.labelNumberOfIterations = new System.Windows.Forms.Label();
            this.numericNumberOfIterations = new System.Windows.Forms.NumericUpDown();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericStartPopulationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberOfIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.numericNumberOfIterations);
            this.panelSettings.Controls.Add(this.labelNumberOfIterations);
            this.panelSettings.Controls.Add(this.btnStartStopRandomAlgo);
            this.panelSettings.Controls.Add(this.btnStartStop);
            this.panelSettings.Controls.Add(this.comboboxTargetFunction);
            this.panelSettings.Controls.Add(this.labelTargetFunctionSelector);
            this.panelSettings.Controls.Add(this.textboxAcceptingDistance);
            this.panelSettings.Controls.Add(this.labelAcceptingDistance);
            this.panelSettings.Controls.Add(this.numericStartPopulationSize);
            this.panelSettings.Controls.Add(this.labelStartPopulation);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSettings.Location = new System.Drawing.Point(620, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Padding = new System.Windows.Forms.Padding(6);
            this.panelSettings.Size = new System.Drawing.Size(209, 628);
            this.panelSettings.TabIndex = 0;
            // 
            // btnStartStopRandomAlgo
            // 
            this.btnStartStopRandomAlgo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStartStopRandomAlgo.Location = new System.Drawing.Point(6, 566);
            this.btnStartStopRandomAlgo.Name = "btnStartStopRandomAlgo";
            this.btnStartStopRandomAlgo.Size = new System.Drawing.Size(197, 28);
            this.btnStartStopRandomAlgo.TabIndex = 7;
            this.btnStartStopRandomAlgo.Text = "Run random";
            this.btnStartStopRandomAlgo.UseVisualStyleBackColor = true;
            this.btnStartStopRandomAlgo.Click += new System.EventHandler(this.btnStartStopRandomAlgo_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStartStop.Location = new System.Drawing.Point(6, 594);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(197, 28);
            this.btnStartStop.TabIndex = 6;
            this.btnStartStop.Text = "Run Evolution";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // comboboxTargetFunction
            // 
            this.comboboxTargetFunction.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboboxTargetFunction.FormattingEnabled = true;
            this.comboboxTargetFunction.Location = new System.Drawing.Point(6, 113);
            this.comboboxTargetFunction.Name = "comboboxTargetFunction";
            this.comboboxTargetFunction.Size = new System.Drawing.Size(197, 21);
            this.comboboxTargetFunction.TabIndex = 5;
            // 
            // labelTargetFunctionSelector
            // 
            this.labelTargetFunctionSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTargetFunctionSelector.Location = new System.Drawing.Point(6, 88);
            this.labelTargetFunctionSelector.Name = "labelTargetFunctionSelector";
            this.labelTargetFunctionSelector.Size = new System.Drawing.Size(197, 25);
            this.labelTargetFunctionSelector.TabIndex = 4;
            this.labelTargetFunctionSelector.Text = "Target Function";
            this.labelTargetFunctionSelector.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textboxAcceptingDistance
            // 
            this.textboxAcceptingDistance.Dock = System.Windows.Forms.DockStyle.Top;
            this.textboxAcceptingDistance.Location = new System.Drawing.Point(6, 68);
            this.textboxAcceptingDistance.Name = "textboxAcceptingDistance";
            this.textboxAcceptingDistance.Size = new System.Drawing.Size(197, 20);
            this.textboxAcceptingDistance.TabIndex = 3;
            this.textboxAcceptingDistance.Text = "0.01";
            // 
            // labelAcceptingDistance
            // 
            this.labelAcceptingDistance.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelAcceptingDistance.Location = new System.Drawing.Point(6, 43);
            this.labelAcceptingDistance.Name = "labelAcceptingDistance";
            this.labelAcceptingDistance.Size = new System.Drawing.Size(197, 25);
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
            this.numericStartPopulationSize.Size = new System.Drawing.Size(197, 20);
            this.numericStartPopulationSize.TabIndex = 1;
            this.numericStartPopulationSize.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // labelStartPopulation
            // 
            this.labelStartPopulation.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStartPopulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartPopulation.Location = new System.Drawing.Point(6, 6);
            this.labelStartPopulation.Name = "labelStartPopulation";
            this.labelStartPopulation.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.labelStartPopulation.Size = new System.Drawing.Size(197, 17);
            this.labelStartPopulation.TabIndex = 0;
            this.labelStartPopulation.Text = "Start population size";
            this.labelStartPopulation.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pictureboxPreview
            // 
            this.pictureboxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureboxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureboxPreview.Name = "pictureboxPreview";
            this.pictureboxPreview.Size = new System.Drawing.Size(620, 615);
            this.pictureboxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureboxPreview.TabIndex = 1;
            this.pictureboxPreview.TabStop = false;
            // 
            // labelStatistics
            // 
            this.labelStatistics.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelStatistics.Location = new System.Drawing.Point(0, 615);
            this.labelStatistics.Name = "labelStatistics";
            this.labelStatistics.Size = new System.Drawing.Size(620, 13);
            this.labelStatistics.TabIndex = 2;
            this.labelStatistics.Text = "label1";
            // 
            // labelNumberOfIterations
            // 
            this.labelNumberOfIterations.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNumberOfIterations.Location = new System.Drawing.Point(6, 134);
            this.labelNumberOfIterations.Name = "labelNumberOfIterations";
            this.labelNumberOfIterations.Size = new System.Drawing.Size(197, 25);
            this.labelNumberOfIterations.TabIndex = 8;
            this.labelNumberOfIterations.Text = "Number of iterations";
            this.labelNumberOfIterations.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.numericNumberOfIterations.Size = new System.Drawing.Size(197, 20);
            this.numericNumberOfIterations.TabIndex = 9;
            this.numericNumberOfIterations.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 628);
            this.Controls.Add(this.pictureboxPreview);
            this.Controls.Add(this.labelStatistics);
            this.Controls.Add(this.panelSettings);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Genetic Algorithm Test";
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericStartPopulationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberOfIterations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label labelAcceptingDistance;
        private System.Windows.Forms.NumericUpDown numericStartPopulationSize;
        private System.Windows.Forms.Label labelStartPopulation;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.ComboBox comboboxTargetFunction;
        private System.Windows.Forms.Label labelTargetFunctionSelector;
        private System.Windows.Forms.TextBox textboxAcceptingDistance;
        private System.Windows.Forms.PictureBox pictureboxPreview;
        private System.Windows.Forms.Label labelStatistics;
        private System.Windows.Forms.Button btnStartStopRandomAlgo;
        private System.Windows.Forms.NumericUpDown numericNumberOfIterations;
        private System.Windows.Forms.Label labelNumberOfIterations;
    }
}

