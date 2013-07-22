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
    public class ClearStateFixtire
    {
        [TestMethod]
        public void ClearCommandInClearStateShouldBeInvariantTest()
        {
            var calc = CalculatorFactory.BuildNew();
            var state = new ClearState(calc);
            state.Notify(new ClearCommand());
            Assert.IsTrue(calc.State is ClearState);
        }

        [TestMethod]
        public void EqualsCommandInClearStateShouldBeInvariantTest()
        {
            var calc = CalculatorFactory.BuildNew();
            var state = new ClearState(calc);
            state.Notify(new EqualsCommand());
            Assert.IsTrue(calc.State is ClearState);
        }

        [TestMethod]
        public void OperatorCommandInClearStateShouldBeInvariantTest()
        {
            var calc = CalculatorFactory.BuildNew();
            var state = new ClearState(calc);
            state.Notify(new OperatorCommand("+"));
            Assert.IsTrue(calc.State is ClearState);
        }

        [TestMethod]
        public void DigitCommandInClearStateShouldChangeToAccumulatorStateTest()
        {
            var calc = CalculatorFactory.BuildNew();
            var state = new ClearState(calc);
            state.Notify(new DigitCommand(1));
            Assert.IsTrue(calc.State is AccumulatorState);
        }

        [TestMethod]
        public void PointCommandInClearStateShouldChangeToAccumulatorStateTest()
        {
            var calc = CalculatorFactory.BuildNew();
            var state = new ClearState(calc);
            state.Notify(PointCommand.Instance);
            Assert.IsTrue(calc.State is AccumulatorState);
        }

        [TestMethod]
        public void DigitCommandShouldSetAccumulatorTest()
        {
            var calc = CalculatorFactory.BuildNew();
            var state = new ClearState(calc);
            Assert.IsTrue(string.IsNullOrWhiteSpace(calc.CPU.Accumulator) == true);
            state.Notify(new DigitCommand(1));
            Assert.IsTrue(calc.State is AccumulatorState);
            Assert.IsTrue(calc.CPU.Accumulator == "1");
        }

        [TestMethod]
        public void PointCommandShouldSetAccumulatorTest()
        {
            var calc = CalculatorFactory.BuildNew();
            var state = new ClearState(calc);
            Assert.IsTrue(string.IsNullOrWhiteSpace(calc.CPU.Accumulator) == true);
            state.Notify(PointCommand.Instance);
            Assert.IsTrue(calc.State is AccumulatorState);
            Assert.IsTrue(calc.CPU.Accumulator == "0.");
        }
    }
}
