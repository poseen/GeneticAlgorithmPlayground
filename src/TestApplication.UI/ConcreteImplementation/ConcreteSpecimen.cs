using System;

namespace TestApplication.UI.ConcreteImplementation
{
    public class ConcreteSpecimen : IClonable<ConcreteSpecimen>, ICloneable, IEquatable<ConcreteSpecimen>
    {
        public ConcreteSpecimen(double x)
        {
            X = x;
        }

        public double this[int key]
        {
            get
            {
                switch (key)
                {
                    case 0: return X;
                    default: throw new IndexOutOfRangeException("Index has to be between 0-0 inclusive.");
                };
            }
        }

        public double X { get; }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ 155;
        }

        public override string ToString()
        {
            return $"X={X}";
        }

        public ConcreteSpecimen Clone()
        {
            return new ConcreteSpecimen(X);
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

            return X.Equals5Precision(other.X);
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
