using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Contracts
{
    public interface ICpu
    {
        IAccumulator Accumulator { get;  }

        IOperation FindOperation(string opName);

        Stack<decimal> OperandStack { get; }

        Stack<string> OperatorStack { get; }

        decimal[] Registers { get;  }

        void Reset();
    }
}
