using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.States
{
    public class ErrorState : BaseCalculatorState
    {
        public ErrorState(Calculator calc)
            : base(calc)
        {
            calc.CPU.Reset();
        }

        protected override void HandleCommand(Contracts.ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
