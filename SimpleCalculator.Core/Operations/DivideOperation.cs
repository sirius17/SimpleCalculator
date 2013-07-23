using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Operations
{
    public class DivideOperation : BinaryOperation
    {
        public DivideOperation(ICpu cpu)
            : base(cpu)
        { }

        protected override decimal Evaluate(decimal operandA, decimal operandB)
        {
            return operandA / operandB;
        }

        public override string Name
        {
            get { return "/"; }
        }
    }
}
