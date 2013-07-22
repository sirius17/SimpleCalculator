using SimpleCalculator.Core.Commands;
using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.States
{
    public abstract class BaseCalculatorState : IState
    {
        protected BaseCalculatorState(Calculator calc)
        {
            this.Calculator = calc;
        }

        protected Calculator Calculator { get; set; }

        protected abstract void HandleCommand(ICommand command);

        public void Notify(ICommand command)
        {
            // Specification
            // We handle clear command here since it is common to all
            // Handle the command
            // Print output
            try
            {
                if (command is ClearCommand)
                    HandleClearCommand();
                else 
                    this.HandleCommand(command);
            }
            catch
            {
                this.Calculator.State = new ErrorState(this.Calculator);
            }
            PrintOutput();
        }

        private void HandleClearCommand()
        {
            this.Calculator.State = new ClearState(this.Calculator);
        }

        private void PrintOutput()
        {
            // Specification:
            // Incase the calculator state is in error print -E-
            // Incase the calculator state is clear, print 0
            // Incase the calculator state is present, print it
            if (this.Calculator.State is ErrorState)
                this.Calculator.Output.Print("-E-");
            var value = GetDisplayValue();
            if (string.IsNullOrWhiteSpace(value) == true)
                this.Calculator.Output.Print("0");
            else
                this.Calculator.Output.Print(value);
        }

        private string GetDisplayValue()
        {
            var value = this.Calculator.CPU.Accumulator;
            if (string.IsNullOrWhiteSpace(value) == false)
                return value;
            if (this.Calculator.CPU.OperandStack.Count == 0)
                return null;
            else return this.Calculator.CPU.OperandStack.Peek().ToString();
        }
    }
}
