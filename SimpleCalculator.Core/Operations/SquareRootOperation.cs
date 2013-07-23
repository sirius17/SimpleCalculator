using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Operations
{
    public class SquareRootOperation : UnaryOperation
    {
        public SquareRootOperation(ICpu cpu)
            : base(cpu)
        {
        }

        public override string Name
        {
            get { return "sqrt"; }
        }

        protected override decimal Evaluate(decimal operand)
        {
            return Convert.ToDecimal(
                Math.Sqrt(
                    Convert.ToDouble(operand)
                    )
                );
        }
    }
}
