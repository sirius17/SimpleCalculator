using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Commands
{
    public class OperatorCommand : ICommand
    {
        public OperatorCommand(string operatorName)
        {
            this.OperatorName = operatorName;
        }

        public string OperatorName { get; set; }
    }
}
