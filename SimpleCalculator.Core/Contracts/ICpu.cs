using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Contracts
{
    public interface ICpu
    {
        string Accumulator { get; set; }

        IOperation FindOperation(string opName);

        Stack<decimal> OperandStack { get; }

        Stack<string> OperatorStack { get; }

        void Reset();
    }
}
