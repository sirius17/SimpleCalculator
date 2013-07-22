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

        public abstract void Notify(ICommand command);
    }
}
