using SimpleCalculator.Core.Contracts;
using SimpleCalculator.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core
{
    public class SimpleCpu : ICpu
    {
        public SimpleCpu()
        {
            this.OperandStack = new Stack<decimal>();
            this.OperatorStack = new Stack<string>();
            InitializeSupportedOperations();
        }

        private void InitializeSupportedOperations()
        {
            this.SupportedOperations = new Dictionary<string, IOperation>();
            RegisterOperation(this.SupportedOperations, new AddOperation(this));
            RegisterOperation(this.SupportedOperations, new SubtractOperation(this));
            RegisterOperation(this.SupportedOperations, new DivideOperation(this));
            RegisterOperation(this.SupportedOperations, new MultiplyOperation(this));


            RegisterOperation(this.SupportedOperations, new NegateOperation(this));
        }

        private void RegisterOperation(Dictionary<string, IOperation> map, IOperation op)
        {
            map[op.Name] = op;
        }



        private Dictionary<string, IOperation> SupportedOperations = null;
            

        public IOperation FindOperation(string opName)
        {
            return this.SupportedOperations[opName];
        }

        public Stack<decimal> OperandStack { get; private set; }

        public Stack<string> OperatorStack { get; private set; }

        public string Accumulator { get; set; }


        public void Reset()
        {
            this.Accumulator = null;
            this.OperandStack.Clear();
            this.OperatorStack.Clear();
        }
    }
}
