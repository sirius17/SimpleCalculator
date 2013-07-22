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

        public override void Notify(Contracts.ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
