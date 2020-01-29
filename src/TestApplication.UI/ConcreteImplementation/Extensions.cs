using System;

namespace TestApplication.UI.ConcreteImplementation
{
    public static class Extensions
    {
        public static bool Equals5Precision(this double a, double b)
        {
            return Math.Abs(a - b) < 0.00001d;
        }
    }
}
