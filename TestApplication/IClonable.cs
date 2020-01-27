using System;
using System.Collections.Generic;
using System.Text;

namespace TestApplication
{
    public interface IClonable<T>
    {
        T Clone();
    }
}
