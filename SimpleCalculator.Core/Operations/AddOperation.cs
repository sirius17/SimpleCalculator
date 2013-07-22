using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Operations
{
    public class AddOperation : IOperation
    {
        public AddOperation(ICpu cpu)
        {
            this.CPU = cpu;
        }

        public ICpu CPU { get; set; }

        public void Execute()
        {
            // The following scenarios need to be supported.
            // 0. If accumulator is empty ??  and operand stack has 2 values and operator stack is empty.
            // then
            //  a. Pop the operands
            //  b. Evaluate the operator
            //  c. Push results into operand stack

            // 1. If accumulator has value and operand stack is empty.
            // then simply push accumulator value to operand stack and
            // push operator to operator stack. Clear accumulator
            // 2. If accumulator has value and operand stack is not empty.
            // then 
            //   a. pop binary operator from operator stack and 
            //   b. evaluate using accumulator value and operand from operand stack.
            //   c. Push result onto operand stack. 
            //   d. Push current operator onto operator stack. 
            //   e. Clear the accumulator.

            if (string.IsNullOrWhiteSpace(this.CPU.Accumulator) == false &&
                this.CPU.OperandStack.Count == 0)
            {
                var operand = decimal.Parse(this.CPU.Accumulator);
                this.CPU.Accumulator = null;
                this.CPU.OperandStack.Push(operand);
                this.CPU.OperatorStack.Push(this.Name);
            }
            else if (string.IsNullOrWhiteSpace(this.CPU.Accumulator) == false &&
                this.CPU.OperandStack.Count != 0)
            {
                var operandA = decimal.Parse(this.CPU.Accumulator);
                var operandB = this.CPU.OperandStack.Pop();
                var opName = this.CPU.OperatorStack.Pop();
            }
        }

        public string Name
        {
            get { return "+"; }
        }
    }
}
