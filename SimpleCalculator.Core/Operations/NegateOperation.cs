﻿using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Operations
{
    public class NegateOperation : UnaryOperation
    {
        public NegateOperation(ICpu cpu)
            : base(cpu)
        {
        }

        public override string Name
        {
            get { return "negate"; }
        }

        protected override decimal Evaluate(decimal operand)
        {
            return -operand;
        }
    }
}
