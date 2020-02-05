using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApplication.UI
{
    public partial class FunctionGraph : UserControl
    {
        public FunctionGraph()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);

            // Default math function
            MathFunction = (x) => Math.Cos(x) * Math.Cos(5 * x) * Math.Sin(10 * x);
        }

        public Color GraphColor { get; set; }

        public Color AxisColor { get; set; }

        public Func<double, double> MathFunction { get; private set; }

        public double MinimumX { get; set; }

        public double MaximumX { get; set; }

        public double MinimumY { get; set; }

        public double MaximumY { get; set; }

        public void SetFunction(Func<double, double> mathFunction)
        {
            MathFunction = mathFunction;
            this.Refresh();
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

        public double DisplayWidth => this.Width;

        public double DisplayHeight => this.Height;

        public double CoordinateWidth => MaximumX - MinimumX;

        public double CoordinateHeight => MaximumY - MinimumY;

        public double HorizontalPixelPerUnit => DisplayWidth / CoordinateWidth;

        public double VerticalPixelPerUnit => DisplayHeight / CoordinateHeight;

        public double HorizontalUnitPerPixel => CoordinateWidth / DisplayWidth;

        public double VerticalUnitPerPixel => CoordinateHeight / DisplayHeight;

        public int MouseDisplayX { get; private set; }

        public int MouseDisplayY { get; private set; }

        public double MouseCoordinateX => ToHorizontalUnit(MouseDisplayX);

        public double MouseCoordinateY => ToVerticalUnit(MouseDisplayY);

        private int ToHorizontalPixel(double coordX)
        {
            return (int)Math.Round((coordX - MinimumX) * HorizontalPixelPerUnit);
        }

        private int ToVerticalPixel(double coordY)
        {
            return (int)Math.Round((-1 * coordY - MinimumY) * VerticalPixelPerUnit);
        }

        private double ToHorizontalUnit(int displayX)
        {
            return MinimumX + displayX * HorizontalUnitPerPixel;
        }

        private double ToVerticalUnit(int displayY)
        {
            return -1 * (MinimumY + displayY * VerticalUnitPerPixel);
        }

        private Pen _axisPen;
        private Pen AxisPen
        {
            get
            {
                if(_axisPen?.Color != this.AxisColor)
                {
                    _axisPen = new Pen(AxisColor);
                }

                return _axisPen;
            }
        }

        private Pen _graphPen;
        private Pen GraphPen
        {
            get
            {
                if (_graphPen?.Color != this.GraphColor)
                {
                    _graphPen = new Pen(GraphColor, 1.3f);
                }

                return _graphPen;
            }
        }

        private void FunctionGraph_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var rect = this.ClientRectangle;
            var imgWidth = rect.Width;
            var imgHeight = rect.Height;

            points.Clear();
            for (var x = 0; x < imgWidth; x++)
            {
                var fx = ToHorizontalUnit(x);
                var fy = MathFunction(fx);
                points.Add(new PointF((float)fx, (float)fy));
            }

            var leftMiddle = Translate(-1, 0, imgWidth, imgHeight);
            var rightMiddle = Translate(1, 0, imgWidth, imgHeight);
            var topMiddle = Translate(0, 1, imgWidth, imgHeight);
            var bottomMiddle = Translate(0, -1, imgWidth, imgHeight);

            var b = Brushes.GreenYellow;
            var b2 = Brushes.Red;

            g.Clear(this.BackColor);

            g.DrawLine(AxisPen, leftMiddle.x, leftMiddle.y, rightMiddle.x, rightMiddle.y);
            g.DrawLine(AxisPen, topMiddle.x, topMiddle.y, bottomMiddle.x, bottomMiddle.y);

            var functionValue = MathFunction(ToHorizontalUnit(MouseDisplayX));
            g.DrawString($"{MouseDisplayX}; {MouseDisplayY}{Environment.NewLine}{MouseCoordinateX:0.0000}; {MouseCoordinateY:0.0000}{Environment.NewLine}f(x) = {functionValue:0.0000}", new Font(FontFamily.GenericMonospace, 10), Brushes.Black, new PointF(0, 0));

            // Select function value at mouse:
            var chordY = ToVerticalPixel(functionValue);
            if (chordY >= 0 && chordY <= Height)
            {
                g.FillEllipse(FunctionValueSelectionBrush, MouseDisplayX - 6, chordY - 6, 12, 12);
            }

            if (points.Count > 1)
            {
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddLines(points.Select(x => new PointF(ToHorizontalPixel(x.X), ToVerticalPixel(x.Y))).ToArray());
                g.DrawPath(GraphPen, path);
            }
        }

        public Brush FunctionValueSelectionBrush { get; set; } = Brushes.BlueViolet;

        private void FunctionGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var moveX = MouseDisplayX - e.X;
                var moveY = MouseDisplayY - e.Y;

                var coordMoveX = moveX * HorizontalUnitPerPixel;
                var coordMoveY = moveY * VerticalUnitPerPixel;

                MaximumX += coordMoveX;
                MinimumX += coordMoveX;

                MaximumY += coordMoveY;
                MinimumY += coordMoveY;
            }

            MouseDisplayX = e.X;
            MouseDisplayY = e.Y;

            this.Refresh();
        }

        private void FunctionGraph_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var zoomFactor = Math.Sign(e.Delta) * 0.1d;

            MinimumX -= zoomFactor;
            MaximumX += zoomFactor;
            MinimumY -= zoomFactor;
            MaximumY += zoomFactor;
            this.Refresh();
        }

        private List<PointF> points = new List<PointF>();

        private void FunctionGraph_MouseUp(object sender, MouseEventArgs e)
        {
            switch(e.Button)
            {
                case MouseButtons.Left:
                    var x = (float)ToHorizontalUnit(e.X);
                    var y = (float)ToVerticalUnit(e.Y);
                    points.Add(new PointF(x, y));
                    break;
                case MouseButtons.Right:
                    points.Clear();
                    break;
                default:
                    break;
            }
            this.Refresh();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            MinimumY = -2;
            MaximumY = 2;
            MinimumX = -2;
            MaximumX = 2;
            this.Refresh();
        }
    }
}
