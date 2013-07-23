using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Operations
{
    public class NegateOperation : IOperation
    {
        public NegateOperation(ICpu cpu)
        {
            this.CPU = cpu;
        }

        protected ICpu CPU { get; set; }

        public string Name
        {
            get { return "negate"; }
        }

        public void Execute()
        {
            // Specification.
            // Unary operations need to handle two situations.
            // Incase the accumulator has a value, then the operation will apply to the accumulator value.
            // Else the operator will pick existing operand from stack and apply itself.
            if (string.IsNullOrWhiteSpace(this.CPU.Accumulator) == false)
            {
                var operand = decimal.Parse(this.CPU.Accumulator);
                this.CPU.Accumulator = this.Evaluate(operand).ToString();
            }
            else
            {
                var operand = this.CPU.OperandStack.Pop();
                var result = this.Evaluate(operand);
                this.CPU.OperandStack.Push(result);
            }
        }

        private decimal Evaluate(decimal operand)
        {
            return -operand;
        }
    }
}
