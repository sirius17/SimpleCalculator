using SimpleCalculator.Core.Contracts;
using SimpleCalculator.Core.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core
{
    public class Calculator : ICommandObserver
    {
        public Calculator(ICommandSubject input, IDisplayDevice output, ICpu processor)
        {
            this.Input = input;
            this.Output = output;
            this.CPU = processor;
            this.Input.Attach(this);
            this.State = new ClearState(this);
        }

        public ICommandSubject Input { get; set; }

        public IDisplayDevice Output { get; set; }

        public ICpu CPU { get; set; }

        public IState State { get; set; }

        public void Notify(ICommand newCommand)
        {
            this.State.Notify(newCommand);
        }
    }
}
