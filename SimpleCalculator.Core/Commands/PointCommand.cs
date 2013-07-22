using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Commands
{
    public class PointCommand : ICommand
    {
        private PointCommand()
        {
        }

        public static readonly PointCommand Instance = new PointCommand();
    }
}
