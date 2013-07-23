using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class UnaryOperatorTest
    {

        [TestMethod]
        public void IfAccumulatorNonEmptyThenOperationShouldApplyToAccumulatorTest()
        {
            var cpu = new SimpleCpu();
            cpu.Accumulator.SetValue(15);
            cpu.OperandStack.Push(10);
            var operation = cpu.FindOperation("negate");
            operation.Execute();
            Assert.IsTrue(cpu.Accumulator.ToString() == "-15");
            Assert.IsTrue(cpu.OperandStack.Count == 1);
            Assert.IsTrue(cpu.OperandStack.Peek() == 10);
        }

        [TestMethod]
        public void IfAccumulatorEmptyThenOperationShouldApplyToOperandStackTest()
        {
            var cpu = new SimpleCpu();
            cpu.OperandStack.Push(10);
            var operation = cpu.FindOperation("negate");
            operation.Execute();
            Assert.IsTrue(cpu.OperandStack.Count == 1);
            Assert.IsTrue(cpu.OperandStack.Peek() == -10);
        }

        [TestMethod]
        public void IfStackEmptyThenOperationShouldApplyToAccumulatorTest()
        {
            var cpu = new SimpleCpu();
            cpu.Accumulator.SetValue(10);
            var operation = cpu.FindOperation("negate");
            operation.Execute();
            Assert.IsTrue(cpu.OperandStack.Count == 0);
            Assert.IsTrue(cpu.Accumulator.ToString() == "-10");
        }

        //TODO: Handle the scenario when both accumulator and stack are empty.
    }
}
