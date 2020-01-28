using System;
using System.Diagnostics.CodeAnalysis;

namespace TestApplication
{
    public class ConcreteSpecimen : IClonable<ConcreteSpecimen>, ICloneable, IEquatable<ConcreteSpecimen>
    {
        public ConcreteSpecimen(int a, int b, int c, int d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public int this[int key]
        {
            get
            {
                return key switch
                {
                    0 => A,
                    1 => B,
                    2 => C,
                    3 => D,
                    _ => throw new IndexOutOfRangeException("Index has to be between 0-3 inclusive."),
                };
            }
        }

        public int A { get; }

        public int B { get; }

        public int C { get; }
        
        public int D { get; }

        public override int GetHashCode()
        {
            return HashCode.Combine(A, B, C, D);
        }

        public override string ToString()
        {
            return $"A={A} B={B} C={C} D={D}";
        }

        public ConcreteSpecimen Clone()
        {
            return new ConcreteSpecimen(A, B, C, D);
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

            return A == other.A
                && B == other.B
                && C == other.C
                && D == other.D;
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
