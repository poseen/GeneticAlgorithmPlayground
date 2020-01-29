using System;
using System.Diagnostics.CodeAnalysis;

namespace TestApplication.UI.ConcreteImplementation
{
    public class ConcreteSpecimen : IClonable<ConcreteSpecimen>, ICloneable, IEquatable<ConcreteSpecimen>
    {
        public ConcreteSpecimen(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double this[int key]
        {
            get
            {
                switch (key)
                {
                    case 0: return X;
                    case 1: return Y;
                    default: throw new IndexOutOfRangeException("Index has to be between 0-1 inclusive.");
                };
            }
        }

        public double X { get; }

        public double Y { get; }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ 155;
        }

        public override string ToString()
        {
            return $"X={X} Y={Y}";
        }

        public ConcreteSpecimen Clone()
        {
            return new ConcreteSpecimen(X, Y);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public bool Equals(ConcreteSpecimen other)
        {
            if(other is null)
            {
                return false;
            }

            if(ReferenceEquals(this, other))
            {
                return true;
            }

            return X.Equals5Precision(other.X) && Y.Equals5Precision(other.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if(GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((ConcreteSpecimen)obj);
        }
    }
}
