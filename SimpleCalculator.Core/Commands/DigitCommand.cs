using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Commands
{
    public class DigitCommand : ICommand
    {
        public DigitCommand(uint digit)
        {
            if (digit < 0 || digit > 9)
                throw new ArgumentException("digit must be between 0 and 9.");
            this.Digit = digit;
        }

        public uint Digit { get; set; }
    }
}
