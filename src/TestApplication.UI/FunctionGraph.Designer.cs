namespace TestApplication.UI
{
    partial class FunctionGraph
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnReset = new System.Windows.Forms.Button();
            this.tooltipResetButton = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(574, 247);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(24, 24);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "+";
            this.tooltipResetButton.SetToolTip(this.btnReset, "This will reset the view of the control.\r\nIt will move the viewpoint back to orig" +
        "o and sets the zoom level to -2..2 intervals.");
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tooltipResetButton
            // 
            this.tooltipResetButton.IsBalloon = true;
            this.tooltipResetButton.ToolTipTitle = "Reset";
            // 
            // FunctionGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnReset);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.Name = "FunctionGraph";
            this.Size = new System.Drawing.Size(601, 274);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FunctionGraph_Paint);
            this.MouseLeave += new System.EventHandler(this.FunctionGraph_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FunctionGraph_MouseMove);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FunctionGraph_MouseWheel);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ToolTip tooltipResetButton;
    }
}
