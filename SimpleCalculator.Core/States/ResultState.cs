using SimpleCalculator.Core.Commands;
using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.States
{
    public class ResultState : BaseCalculatorState
    {
        public ResultState(Calculator calc)
            : base(calc)
        {   
        }

        protected override void HandleCommand(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
