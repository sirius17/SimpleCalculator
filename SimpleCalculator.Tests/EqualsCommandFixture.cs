using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator.Core;
using SimpleCalculator.Core.Commands;
using SimpleCalculator.Core.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class EqualsCommandFixture
    {
        [TestMethod]
        public void EqualsCommandShouldPushAccumulatorToStack()
        {
            Calculator calc = CalculatorFactory.BuildNew();
            calc.Notify(new DigitCommand(5));
            Assert.IsTrue(calc.State is AccumulatorState);
            Assert.IsTrue(calc.CPU.Accumulator.ToString()  == "5");
            Assert.IsTrue(calc.CPU.OperandStack.Count == 0);
            calc.Notify(new EqualsCommand());
            Assert.IsTrue( calc.CPU.Accumulator.IsEmpty );
            Assert.IsTrue(calc.CPU.OperandStack.Count == 1);
            Assert.IsTrue(calc.CPU.OperandStack.Peek() == 5);
        }

        [TestMethod]
        public void EqualsCommandWithSingleOperandShouldReuseOperandRegisterTest()
        {
            Calculator calc = CalculatorFactory.BuildNew();
            calc.Notify(new DigitCommand(5));
            Assert.IsTrue(calc.State is AccumulatorState);
            calc.Notify(new OperatorCommand("+"));
            calc.Notify(new EqualsCommand());

            Assert.IsTrue(calc.CPU.OperandStack.Count == 1);
            Assert.IsTrue(calc.CPU.OperandStack.Peek() == 10);
            Assert.IsTrue(calc.CPU.OperatorStack.Count == 1);
            Assert.IsTrue(calc.CPU.OperatorStack.Peek() == "+");
        }

        [TestMethod]
        public void SequentialEqualsCommandWithSingleOperandShouldReuseFirstOperandRegisterTest()
        {
            Calculator calc = CalculatorFactory.BuildNew();
            calc.Notify(new DigitCommand(5));
            Assert.IsTrue(calc.State is AccumulatorState);
            calc.Notify(new OperatorCommand("+"));
            calc.Notify(new EqualsCommand());
            calc.Notify(new EqualsCommand());
            Assert.IsTrue(calc.CPU.OperandStack.Count == 1);
            Assert.IsTrue(calc.CPU.OperandStack.Peek() == 15);
            Assert.IsTrue(calc.CPU.OperatorStack.Count == 1);
            Assert.IsTrue(calc.CPU.OperatorStack.Peek() == "+");
        }

        [TestMethod]
        public void EqualsCommandWithTwoOperandShouldIgnoreRegisterTest()
        {
            Calculator calc = CalculatorFactory.BuildNew();
            calc.Notify(new DigitCommand(5));
            Assert.IsTrue(calc.State is AccumulatorState);
            calc.Notify(new OperatorCommand("+"));
            calc.Notify(new DigitCommand(6));
            calc.Notify(new EqualsCommand());
            Assert.IsTrue(calc.CPU.OperandStack.Count == 1);
            Assert.IsTrue(calc.CPU.OperandStack.Peek() == 11);
            Assert.IsTrue(calc.CPU.OperatorStack.Count == 1);
            Assert.IsTrue(calc.CPU.OperatorStack.Peek() == "+");
        }
    }
}
