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
    public class AccumulatorStateFixture
    {
        [TestMethod]
        public void DigitCommandShouldNotChangeStateTest()
        {
            Calculator calc = CalculatorFactory.BuildNew();
            calc.Notify(new DigitCommand(1));
            Assert.IsTrue(calc.State is AccumulatorState);

            calc.Notify(new DigitCommand(2));
            Assert.IsTrue(calc.State is AccumulatorState);
        }

        [TestMethod]
        public void ZeroDigitWithZeroAccumulatorIsInvariantTest()
        {
            Calculator calc = CalculatorFactory.BuildNew();
            calc.Notify(new DigitCommand(0));
            Assert.IsTrue(calc.State is AccumulatorState);
            Assert.IsTrue(calc.CPU.Accumulator.ToString() == "0");
            calc.Notify(new DigitCommand(0));
            Assert.IsTrue(calc.CPU.Accumulator.ToString() == "0");
        }

        [TestMethod]
        public void NonZeroDigitWithZeroAccumulatorShouldReplaceValueTest()
        {
            Calculator calc = CalculatorFactory.BuildNew();
            calc.Notify(new DigitCommand(0));
            Assert.IsTrue(calc.State is AccumulatorState);
            Assert.IsTrue(calc.CPU.Accumulator.ToString() == "0");
            calc.Notify(new DigitCommand(1));
            Assert.IsTrue(calc.CPU.Accumulator.ToString() == "1");
        }

        [TestMethod]
        public void AnyDigitWithNonZeroAccumulatorShouldAppendDigitTest()
        {
            Calculator calc = CalculatorFactory.BuildNew();
            calc.Notify(new DigitCommand(1));
            Assert.IsTrue(calc.State is AccumulatorState);
            Assert.IsTrue(calc.CPU.Accumulator.ToString() == "1");
            calc.Notify(new DigitCommand(2));
            Assert.IsTrue(calc.CPU.Accumulator.ToString() == "12");
        }


        [TestMethod]
        public void PointCommandShouldNotChangeStateTest()
        {
            Calculator calc = CalculatorFactory.BuildNew();
            calc.Notify(new DigitCommand(1));
            Assert.IsTrue(calc.State is AccumulatorState);

            calc.Notify(PointCommand.Instance);
            Assert.IsTrue(calc.State is AccumulatorState);
        }

        [TestMethod]
        public void PointCommandWithIntergerValueShouldAppendDotTest()
        {
            Calculator calc = CalculatorFactory.BuildNew();
            calc.Notify(new DigitCommand(1));
            Assert.IsTrue(calc.State is AccumulatorState);
            Assert.IsTrue(calc.CPU.Accumulator.ToString() == "1");
            calc.Notify(PointCommand.Instance);
            Assert.IsTrue(calc.CPU.Accumulator.ToString() == "1.");
        }

        [TestMethod]
        public void PointCommandWithDecimalValueShouldBeIgnoredTest()
        {
            Calculator calc = CalculatorFactory.BuildNew();
            calc.Notify(PointCommand.Instance);
            Assert.IsTrue(calc.State is AccumulatorState);
            Assert.IsTrue(calc.CPU.Accumulator.ToString() == "0.");
            calc.Notify(PointCommand.Instance);
            Assert.IsTrue(calc.CPU.Accumulator.ToString() == "0.");
        }


        [TestMethod]
        public void BinaryOperatorCommandShouldNotChangeStateTest()
        {
            Calculator calc = CalculatorFactory.BuildNew();
            calc.Notify(new DigitCommand(1));
            Assert.IsTrue(calc.State is AccumulatorState);
            calc.Notify(new OperatorCommand("+"));
            Assert.IsTrue(calc.State is AccumulatorState);
        }

        [TestMethod]
        public void EqualsCommandShouldChangeStateToResultStateTest()
        {
            Calculator calc = CalculatorFactory.BuildNew();
            calc.Notify(new DigitCommand(1));
            Assert.IsTrue(calc.State is AccumulatorState);

            calc.Notify(new EqualsCommand());
            Assert.IsTrue(calc.State is ResultState);
        }
    }
}
