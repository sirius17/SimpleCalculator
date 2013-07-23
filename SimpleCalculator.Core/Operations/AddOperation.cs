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
            /*
             Binary operation would have 4 potential scenarios to handle. 
            1. Only one operand has been provided.
            In this case, the operation would simply queue itself on the stack.
            2. Both operands are provided and there is an existing operator queued.
            In this case, the operation would pop existing operator and evaulate it.
            This would reduce the setup to case 1.
            3. Both operands are provided, and no existing operator exists.
            Simply pop both operands, run operation and push result on operand stack. 
             */
            if (string.IsNullOrWhiteSpace(this.CPU.Accumulator) == false)
                MoveOperandToStack();

            if (this.CPU.OperandStack.Count == 1  )
                QueueOperation();
            else if (this.CPU.OperatorStack.Count == 0 && this.CPU.OperandStack.Count == 2)
                EvaluateOperation();
            else if (this.CPU.OperatorStack.Count == 1 && this.CPU.OperandStack.Count == 2)
            {
                ReduceToSingleOperand();
                QueueOperation();
            }
            else throw new Exception("Invalid operator / operand stack state.");
        }

        private void EvaluateOperation()
        {
            var opB = this.CPU.OperandStack.Pop();
            var opA = this.CPU.OperandStack.Pop();
            var result = this.Evaluate(opA, opB);
            this.CPU.OperandStack.Push(result);
        }

        private void ReduceToSingleOperand()
        {
            var opName = this.CPU.OperatorStack.Pop();
            var pendingOp = this.CPU.FindOperation(opName);
            pendingOp.Execute();
        }

        private void QueueOperation()
        {
            // Queue the current operator
            // Simply push current op on the operator stack.
            this.CPU.OperatorStack.Push(this.Name);
        }

        private void MoveOperandToStack()
        {
            var operand = decimal.Parse(this.CPU.Accumulator);
            this.CPU.Accumulator = null;
            this.CPU.OperandStack.Push(operand);
        }

        private decimal Evaluate(decimal operandA, decimal operandB)
        {
            return operandA + operandB;
        }

        public string Name
        {
            get { return "+"; }
        }
    }
}
