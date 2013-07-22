using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Contracts
{
    public interface ICommandSubject
    {
        void Attach(ICommandObserver observer);

        void Detach(ICommandObserver observer);

        void Notify(ICommand command);
    }
}
