using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class BinaryOperatorFixture
    {
        [TestMethod]
        public void SingleOperandShouldQueueOperationTest()
        {
            var cpu = new SimpleCpu();
            cpu.OperandStack.Push(5);
            var op = cpu.FindOperation("+");
            op.Execute();
            Assert.IsTrue(cpu.OperandStack.Count == 1);
            Assert.IsTrue(cpu.OperandStack.Peek() == 5);
            Assert.IsTrue(cpu.OperatorStack.Count == 1);
            Assert.IsTrue(cpu.OperatorStack.Peek() == "+");
        }

        [TestMethod]
        public void TwoOperandWithoutExistingOperatorShouldEvaulateTest()
        {
            var cpu = new SimpleCpu();
            cpu.OperandStack.Push(5);
            cpu.OperandStack.Push(6);
            var op = cpu.FindOperation("+");
            op.Execute();
            Assert.IsTrue(cpu.OperandStack.Count == 1);
            Assert.IsTrue(cpu.OperandStack.Peek() == 11);
            Assert.IsTrue(cpu.OperatorStack.Count == 0);
        }

        [TestMethod]
        public void TwoOperandWithExistingOperatorShouldReduceTest()
        {
            var cpu = new SimpleCpu();
            cpu.OperandStack.Push(5);
            cpu.OperandStack.Push(6);
            cpu.OperatorStack.Push("+");
            var op = cpu.FindOperation("+");
            op.Execute();
            Assert.IsTrue(cpu.OperandStack.Count == 1);
            Assert.IsTrue(cpu.OperandStack.Peek() == 11);
            Assert.IsTrue(cpu.OperatorStack.Count == 1);
            Assert.IsTrue(cpu.OperatorStack.Peek() == "+");
        }
    }
}
