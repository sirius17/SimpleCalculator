using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Operations
{
    public abstract class BinaryOperation : IOperation
    {
        protected BinaryOperation(ICpu cpu)
        {
            this.CPU = cpu;
        }

        public ICpu CPU { get; set; }

        protected abstract decimal Evaluate(decimal operandA, decimal operandB);

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
            4. If a single operand is provided, with existing operator, 
             * then current operator should replace the existing operator.
             */
            if (string.IsNullOrWhiteSpace(this.CPU.Accumulator) == false)
                MoveOperandToStack();
            bool bothOperandsAvailable = this.CPU.OperandStack.Count == 2;
            bool pendingOperatorPresent = this.CPU.OperatorStack.Count != 0;

            if (bothOperandsAvailable == false && pendingOperatorPresent == false)
                QueueOperation();
            else if (bothOperandsAvailable == false && pendingOperatorPresent == true)
                ReplaceOperation();
            else if (bothOperandsAvailable == true && pendingOperatorPresent == false)
                EvaluateOperation();
            else
            {
                ReduceToSingleOperand();
                QueueOperation();
            }
        }

        private void ReplaceOperation()
        {
            // Remove pending operator
            this.CPU.OperatorStack.Pop();
            // Push the current one
            this.CPU.OperatorStack.Push(this.Name);
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

        public abstract string Name { get; }
    }
}
