using SimpleCalculator.Core;
using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Tests
{
    public class TestInput : ICommandSubject
    {
        public void Attach(ICommandObserver observer)
        {
            // Do nothing
        }

        public void Detach(ICommandObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Notify(ICommand command)
        {
            throw new NotImplementedException();
        }
    }

    internal class CalculatorFactory
    {
        public static Calculator BuildNew()
        {
            return new Calculator( new TestInput(), null, new SimpleCpu());
        }
    }
}
