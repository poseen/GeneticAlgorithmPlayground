using System;
using System.Diagnostics.CodeAnalysis;

namespace TestApplication
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
                return key switch
                {
                    0 => X,
                    1 => Y,
                    _ => throw new IndexOutOfRangeException("Index has to be between 0-1 inclusive."),
                };
            }
        }

        public double X { get; }

        public double Y { get; }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
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

        public bool Equals([AllowNull] ConcreteSpecimen other)
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

        public override bool Equals([AllowNull]object obj)
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
