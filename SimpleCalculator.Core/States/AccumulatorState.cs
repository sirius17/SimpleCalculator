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
            else
                throw new NotImplementedException();
        }

        private void HandleOperatorCommand(OperatorCommand operatorCommand)
        {
            // Clear accumulator state.
            if (string.IsNullOrWhiteSpace(this.Calculator.CPU.Accumulator) == false)
            {
                var operand = decimal.Parse(this.Calculator.CPU.Accumulator);
                this.Calculator.CPU.OperandStack.Push(operand);
                this.Calculator.CPU.Accumulator = null;
            }
            
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
            if (cpu.Accumulator.Contains('.') == false)
                cpu.Accumulator += ".";
        }

        private void HandleDigitCommand(DigitCommand digitCommand)
        {
            // Scenarios
            // If accumulator has zero and digit is zero then ignore.
            // If accumulator has zero and digit is non zero, then replace
            // Else append
            var cpu = this.Calculator.CPU;
            if (cpu.Accumulator == "0" && digitCommand.Digit == 0)
                return;
            if (cpu.Accumulator == "0" && digitCommand.Digit != 0)
                cpu.Accumulator = digitCommand.Digit.ToString();
            else
                cpu.Accumulator += digitCommand.Digit.ToString();
        }
    }
}
