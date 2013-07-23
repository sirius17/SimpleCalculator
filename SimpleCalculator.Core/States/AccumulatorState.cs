using SimpleCalculator.Core.Commands;
using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.States
{
    public class AccumulatorState : BaseCalculatorState
    {
        public AccumulatorState(Calculator calc)
            : base(calc)
        {
        }

        protected override void HandleCommand(ICommand command)
        {
            // Handle digit command
            if (command is DigitCommand)
                HandleDigitCommand(command as DigitCommand);
            else if (command is PointCommand)
                HandlePointCommand();
            else if (command is OperatorCommand)
                HandleOperatorCommand(command as OperatorCommand);
            else if (command is EqualsCommand)
                HandleEqualsCommand();
            else
                throw new NotImplementedException();
        }

        private const int RegisterIndex = 0;

        private void HandleEqualsCommand()
        {
            var cpu = this.Calculator.CPU;
            // Move accumulator to stack
            if (cpu.Accumulator.IsEmpty == false)
                MoveToStack();
            if (cpu.OperandStack.Count() == 1 && cpu.OperatorStack.Count == 1)
            {
                // Read second operator from register and push onto stack
                var operand = cpu.Registers[RegisterIndex];
                cpu.OperandStack.Push(operand);
                var opName = cpu.OperatorStack.Pop();
                var op = cpu.FindOperation(opName);
                op.Execute();
                cpu.OperatorStack.Push(opName);
            }
            else if (cpu.OperandStack.Count() == 2 && cpu.OperatorStack.Count == 1)
            {
                var opName = cpu.OperatorStack.Pop();
                var op = cpu.FindOperation(opName);
                op.Execute();
                cpu.OperatorStack.Push(opName);
            }
            // Change state to result state
            this.Calculator.State = new ResultState(this.Calculator);
        }

        private void MoveToStack()
        {
            decimal operand;
            this.Calculator.CPU.Accumulator.TryGetValue(out operand); ;
            this.Calculator.CPU.Accumulator.Clear();
            this.Calculator.CPU.OperandStack.Push(operand);
            this.Calculator.CPU.Registers[RegisterIndex] = operand;
        }

        private void HandleOperatorCommand(OperatorCommand operatorCommand)
        {
            // Create the operation and execute.
            var op = this.Calculator.CPU.FindOperation(operatorCommand.OperatorName);
            op.Execute();
        }

        private void HandlePointCommand()
        {
            // Specification:
            // If accumulator does not have a decimal point, then append
            // Else ignore
            var cpu = this.Calculator.CPU;
            if (cpu.Accumulator.ToString().Contains('.') == false)
                cpu.Accumulator.Append(".");
        }

        private void HandleDigitCommand(DigitCommand digitCommand)
        {
            // Scenarios
            // If accumulator has zero and digit is zero then ignore.
            // If accumulator has zero and digit is non zero, then replace
            // Else append
            var cpu = this.Calculator.CPU;
            if (cpu.Accumulator.ToString() == "0" && digitCommand.Digit == 0)
                return;
            if (cpu.Accumulator.ToString() == "0" && digitCommand.Digit != 0)
                cpu.Accumulator.SetValue(digitCommand.Digit);
            else
                cpu.Accumulator.Append(digitCommand.Digit.ToString());
        }
    }
}
