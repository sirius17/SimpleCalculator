using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core
{
    public interface IAccumulator
    {
        bool TryGetValue(out decimal value);

        bool IsEmpty { get; }

        void Append(string digit);

        string ToString();

        void Clear();

        void SetValue(decimal value);
    }
}
