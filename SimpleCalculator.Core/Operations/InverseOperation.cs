using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Operations
{
    public class InverseOperation : UnaryOperation
    {
        public InverseOperation(ICpu cpu)
            : base(cpu)
        {
        }

        public override string Name
        {
            get { return "inverse"; }
        }

        protected override decimal Evaluate(decimal operand)
        {
            return 1/operand;
        }
    }
}
