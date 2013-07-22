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
        private List<ICommandObserver> _observers = new List<ICommandObserver>();

        public void Attach(ICommandObserver observer)
        {
            if (_observers.Contains(observer) == false)
                _observers.Add(observer);
        }

        public void Detach(ICommandObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(ICommand command)
        {
            _observers.ForEach(o => o.Notify(command));
        }
    }


    public class ConsoleDisplay : IDisplayDevice
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }

    internal class CalculatorFactory
    {
        public static Calculator BuildNew()
        {
            return new Calculator( new TestInput(),  new ConsoleDisplay(), new SimpleCpu());
        }
    }
}
