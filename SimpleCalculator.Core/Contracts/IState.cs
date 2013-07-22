using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core.Contracts
{
    public interface IState
    {
        void Notify(ICommand command);
    }
}
