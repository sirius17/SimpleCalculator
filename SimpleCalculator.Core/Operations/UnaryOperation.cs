using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Operations
{
    public abstract class UnaryOperation : IOperation
    {
        protected UnaryOperation(ICpu cpu)
        {
            this.CPU = cpu;
        }

        public abstract string Name { get; }

        protected abstract decimal Evaluate(decimal operand);

        public void Execute()
        {
            // Unary operaters can apply both on accumulator and stack
            // always giving preference to the accumulator.
            bool stackEmpty = this.CPU.OperandStack.Count == 0;

            decimal value = decimal.Zero;
            if (this.CPU.Accumulator.IsEmpty == false)
            {
                this.CPU.Accumulator.TryGetValue(out value);
                this.CPU.Accumulator.SetValue(this.Evaluate(value));
            }
            else if (stackEmpty == false)
                this.CPU.OperandStack.Push(this.Evaluate(this.CPU.OperandStack.Pop()));
            else
                throw new Exception("Both accumulator and operator stack are empty.");
        }

        protected ICpu CPU { get; set; }
    }
}
