using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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

            sfRightTop = new StringFormat()
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Near
            };
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

        public double DisplayWidth => this.Width;

        public double DisplayHeight => this.Height;

        public double CoordinateWidth => MaximumX - MinimumX;

        public double CoordinateHeight => MaximumY - MinimumY;

        public double HorizontalPixelPerUnit => DisplayWidth / CoordinateWidth;

        public double VerticalPixelPerUnit => DisplayHeight / CoordinateHeight;

        public double HorizontalUnitPerPixel => CoordinateWidth / DisplayWidth;

        public double VerticalUnitPerPixel => CoordinateHeight / DisplayHeight;

        public int? MouseDisplayX { get; private set; }

        public int? MouseDisplayY { get; private set; }

        public double? MouseCoordinateX => MouseDisplayX.HasValue ? ToHorizontalUnit(MouseDisplayX.Value) : (double?)null;

        public double? MouseCoordinateY => MouseDisplayY.HasValue ? ToVerticalUnit(MouseDisplayY.Value) : (double?)null;

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

        private SolidBrush _axisBrush;
        private SolidBrush AxisBrush
        {
            get
            {
                if (_axisBrush?.Color != this.AxisColor)
                {
                    _axisBrush = new SolidBrush(AxisColor);
                }

                return _axisBrush;
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

        public Color GridColor { get; set; } = Color.LightGray;

        private Pen _gridPen;
        private Pen GridPen
        {
            get
            {
                if (_gridPen?.Color != this.GridColor)
                {
                    _gridPen = new Pen(GridColor, 1.0f);
                }

                return _gridPen;
            }
        }

        public SmoothingMode SmoothingMode { get; set; } = SmoothingMode.AntiAlias;

        private void FunctionGraph_Paint(object sender, PaintEventArgs e)
        {
            // Initialize
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode;
            g.Clear(this.BackColor);

            DrawGrid(g);
            DrawAxes(g);
            DrawFunction(g);
            DrawFunctionValueSelection(g);
        }

        private void DrawGrid(Graphics g)
        {
            DrawVerticalLines(g);
            DrawHorizontalLines(g);
        }

        private void DrawVerticalLines(Graphics g)
        {
            var horizontalInterval = Math.Max(MaximumX, MinimumX) - Math.Min(MaximumX, MinimumX);
            var log = Math.Log10(horizontalInterval);
            var power = log <= 0 ? (int)log : ((int)log - 1);
            var stepSize = Math.Pow(10, power);
            var numberOfVerticalLines = (int)Math.Round(horizontalInterval / stepSize);
            var startX = 0;

            for (var i = 0; i < numberOfVerticalLines; i++)
            {
                var x = startX + ToHorizontalPixel(i * stepSize);
                g.DrawLine(GridPen, x, 0, x, Height);
            }
        }

        private void DrawHorizontalLines(Graphics g)
        {
            var verticalInterval = Math.Max(MaximumY, MinimumY) - Math.Min(MaximumY, MinimumY);
            var log = Math.Log10(verticalInterval);
            var power = log <= 0 ? (int)log : ((int)log - 1);
            var stepSize = Math.Pow(10, power);
            var numberOfHorizontalLines = (int)Math.Round(verticalInterval / stepSize);
            var startY = 0;

            for (var i = 0; i < numberOfHorizontalLines; i++)
            {
                var y = startY + ToVerticalPixel(i * stepSize);
                g.DrawLine(GridPen, 0, y, Width, y);
            }
        }

        private void DrawFunctionValueSelection(Graphics g)
        {
            if(!MouseDisplayX.HasValue)
            {
                CurrentFunctionValue = null;
                CurrentFunctionDerivative = null;
                return;
            }

            CurrentFunctionValue = MathFunction(MouseCoordinateX.Value);
            CurrentFunctionDerivative = Derivative(MathFunction, MouseCoordinateX.Value);

            // Select function value at mouse:
            var chordY = ToVerticalPixel(CurrentFunctionValue.Value);
            if (chordY >= 0 && chordY <= Height)
            {
                g.DrawEllipse(FunctionValuePen, MouseDisplayX.Value - 3, chordY - 3, 6, 6);
            }

            // Draw derivative with red
            var derivativeLineLength = 25;

            var p1 = new PointF(MouseDisplayX.Value - derivativeLineLength, (float)(chordY + derivativeLineLength * CurrentFunctionDerivative.Value));
            var p2 = new PointF(MouseDisplayX.Value + derivativeLineLength, (float)(chordY - derivativeLineLength * CurrentFunctionDerivative.Value));

            var a = p2.X - p1.X;
            var b = p2.Y - p1.Y;
            var c = Math.Sqrt(a * a + b * b);

            var cosAlpha = b / c;
            var alphaRadian = Math.Acos(cosAlpha);
            var sinAlpha = Math.Sin(alphaRadian);

           
            var d1Point = new PointF((float)(MouseDisplayX.Value + sinAlpha * derivativeLineLength),
                                     (float)(chordY + cosAlpha * derivativeLineLength));

            var d2Point = new PointF((float)(MouseDisplayX.Value - sinAlpha * derivativeLineLength),
                                     (float)(chordY - cosAlpha * derivativeLineLength));

            if(d1Point.Y < 0 || d1Point.Y > Height || d2Point.Y < 0 || d2Point.Y > Height)
            {
                // We don't draw anything off the window...
                return;
            }

            g.DrawLine(DerivativePen, d1Point, d2Point);
        }

        public Color DerivativeColor { get; set; } = Color.Red;

        private Pen _derivativePen;
        private Pen DerivativePen
        {
            get
            {
                if (_derivativePen?.Color != this.DerivativeColor)
                {
                    _derivativePen = new Pen(DerivativeColor, 1.3f);
                }

                return _derivativePen;
            }
        }

        private static double h = 10e-6; // I'm not sure if this is valid C#, I'm used to C++

        private static double Derivative(Func<double, double> f, double x)
        {
            double h2 = h * 2;
            return (f(x - h2) - 8 * f(x - h) + 8 * f(x + h) - f(x + h2)) / (h2 * 6);
        }

        public double? CurrentFunctionValue { get; private set; }

        public double? CurrentFunctionDerivative { get; private set; }

        public Font AxesFont { get; set; } = new Font(FontFamily.GenericMonospace, 12);

        private readonly StringFormat sfRightTop;

        private void DrawAxes(Graphics g)
        {
            var xAxisVerticalPosition = ToVerticalPixel(0);
            if (xAxisVerticalPosition > 0 && xAxisVerticalPosition < Height)
            {
                g.DrawLine(AxisPen, 0, xAxisVerticalPosition, Width, xAxisVerticalPosition);
                g.FillPolygon(AxisBrush,
                              new[]
                              {
                                  new PointF(Width, xAxisVerticalPosition),
                                  new PointF(Width - 20, xAxisVerticalPosition - 4),
                                  new PointF(Width - 20, xAxisVerticalPosition + 4)
                              });
                
                g.DrawString("X", AxesFont, AxisBrush, new PointF(Width, xAxisVerticalPosition + 5), sfRightTop);
            }

            var yAxisHorizontalPosition = ToHorizontalPixel(0);
            if (yAxisHorizontalPosition > 0 && yAxisHorizontalPosition < Width)
            {
                g.DrawLine(AxisPen, yAxisHorizontalPosition, 0, yAxisHorizontalPosition, Height);
                g.FillPolygon(AxisBrush,
                              new[]
                              {
                                  new PointF(yAxisHorizontalPosition, 0),
                                  new PointF(yAxisHorizontalPosition - 4, 20),
                                  new PointF(yAxisHorizontalPosition + 4, 20)
                              });
                g.DrawString("Y", AxesFont, AxisBrush, new PointF(yAxisHorizontalPosition + 5, 0));
            }
        }

        private void DrawFunction(Graphics g)
        {
            var pointListsList = new List<List<PointF>>();
            pointListsList.Clear();

            var points = new List<PointF>();
            for (var x = 0; x < Width; x++)
            {
                var fx = ToHorizontalUnit(x);
                var fy = MathFunction(fx);
                var fdy = Derivative(MathFunction, fx);

                if (Math.Abs(fdy) > 500)
                {
                    pointListsList.Add(points);
                    points = new List<PointF>();
                }

                points.Add(new PointF((float)fx, (float)fy));
            }

            if(points.Count > 1)
            {
                pointListsList.Add(points);
            }

            foreach (var p in pointListsList)
            {
                if (p.Count > 2)
                {
                    var path = new System.Drawing.Drawing2D.GraphicsPath();
                    path.AddLines(p.Select(x => new PointF(ToHorizontalPixel(x.X), ToVerticalPixel(x.Y))).ToArray());
                    g.DrawPath(GraphPen, path);
                }
            }
        }

        public Color FunctionValueColor { get; set; } = Color.Gray;

        private Pen _functionValuePen;
        private Pen FunctionValuePen
        {
            get
            {
                if (_functionValuePen?.Color != this.FunctionValueColor)
                {
                    _functionValuePen = new Pen(FunctionValueColor, 1.3f);
                }

                return _functionValuePen;
            }
        }

        private void FunctionGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var moveX = MouseDisplayX.Value - e.X;
                var moveY = MouseDisplayY.Value - e.Y;

                var coordMoveX = moveX * HorizontalUnitPerPixel;
                var coordMoveY = moveY * VerticalUnitPerPixel;

                MaximumX += coordMoveX;
                MinimumX += coordMoveX;

                MaximumY += coordMoveY;
                MinimumY += coordMoveY;
            }

            MouseDisplayX = e.X;
            MouseDisplayY = e.Y;

            StatsChanged?.Invoke(this, new EventArgs());
            this.Refresh();
        }

        private void FunctionGraph_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var zoomFactor = Math.Sign(e.Delta) * 0.1d;

            MinimumX -= zoomFactor;
            MaximumX += zoomFactor;
            MinimumY -= zoomFactor;
            MaximumY += zoomFactor;
            StatsChanged?.Invoke(this, new EventArgs());
            this.Refresh();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            MinimumY = -2;
            MaximumY = 2;
            MinimumX = -2;
            MaximumX = 2;
            StatsChanged?.Invoke(this, new EventArgs());
            this.Refresh();
        }

        private void FunctionGraph_MouseLeave(object sender, EventArgs e)
        {
            MouseDisplayX = null;
            MouseDisplayY = null;
            StatsChanged?.Invoke(this, new EventArgs());
            this.Refresh();
        }

        public event EventHandler StatsChanged;
    }
}
