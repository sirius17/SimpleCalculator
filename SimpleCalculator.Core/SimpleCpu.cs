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
            this.Accumulator = new Accumulator();
            this.OperandStack = new Stack<decimal>();
            this.OperatorStack = new Stack<string>();
            this.Registers = InitializeRegisters(); 
            InitializeSupportedOperations();
        }

        private decimal[] InitializeRegisters()
        {
            return Enumerable.Repeat(decimal.Zero, 8).ToArray();
        }

        private void InitializeSupportedOperations()
        {
            this.SupportedOperations = new Dictionary<string, IOperation>();
            // Binary operations
            RegisterOperation(this.SupportedOperations, new AddOperation(this));
            RegisterOperation(this.SupportedOperations, new SubtractOperation(this));
            RegisterOperation(this.SupportedOperations, new DivideOperation(this));
            RegisterOperation(this.SupportedOperations, new MultiplyOperation(this));
            // Unary operations
            RegisterOperation(this.SupportedOperations, new NegateOperation(this));
            RegisterOperation(this.SupportedOperations, new SquareRootOperation(this));
            RegisterOperation(this.SupportedOperations, new InverseOperation(this));
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

        public IAccumulator Accumulator { get; private set; }


        public void Reset()
        {
            this.Accumulator.Clear();
            this.OperandStack.Clear();
            this.OperatorStack.Clear();
            this.Registers = InitializeRegisters();
        }


        public decimal[] Registers { get; private set; }
    }
}
