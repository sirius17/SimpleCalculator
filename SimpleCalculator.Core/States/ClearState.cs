using SimpleCalculator.Core.Commands;
using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.States
{
    public class ClearState : BaseCalculatorState
    {
        public ClearState(Calculator calc)
            : base(calc)
        {
        }

        public override void Notify(ICommand command)
        {
            // Specification
            // The only commands that are supported are point and digit.
            // Rest are invariant
            if (command is DigitCommand)
                HandleDigitCommand(command as DigitCommand);
            else if (command is PointCommand)
                HandlePointCommand();
        }

        private void HandlePointCommand()
        {
            // Spec
            // Set accumulator to 0. and change state to Accumulator
            this.Calculator.CPU.Accumulator = "0.";
            this.Calculator.State = new AccumulatorState(this.Calculator);
        }

        private void HandleDigitCommand(DigitCommand digitCommand)
        {
            // Spec
            // Set accumulator to digit and change state to Accumulator
            this.Calculator.CPU.Accumulator = digitCommand.Digit.ToString();
            this.Calculator.State = new AccumulatorState(this.Calculator);
        }
    }
}
