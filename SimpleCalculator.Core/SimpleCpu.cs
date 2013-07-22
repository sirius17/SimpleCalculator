using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core
{
    public class SimpleCpu : ICpu
    {
        public SimpleCpu()
        {
            this.OperandStack = new Stack<string>();
            this.OperatorStack = new Stack<string>();
        }

        public IOperation Find(string opName)
        {
            throw new NotImplementedException();
        }

        public Stack<string> OperandStack { get; private set; }

        public Stack<string> OperatorStack { get; private set; }

        public string Accumulator { get; set; }
    }
}
