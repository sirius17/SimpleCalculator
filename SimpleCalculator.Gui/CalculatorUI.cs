using SimpleCalculator.Core;
using SimpleCalculator.Core.Commands;
using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleCalculator.Gui
{
    public partial class CalculatorUI : Form
    {
        public CalculatorUI()
        {
            InitializeComponent();
            this.InputDevice = new CommandFeeder();
            this.OutputDevice = new TextBoxDisplayDevice(this.Output);
            this.Calculator = new Calculator(
                this.InputDevice, this.OutputDevice, new SimpleCpu()
                );
        }

        public Calculator Calculator { get; set; }

        public IDisplayDevice OutputDevice { get; set; }

        public ICommandSubject InputDevice { get; set; }

        private void OnDigitClicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var digit = uint.Parse(btn.Tag.ToString());
            this.InputDevice.Notify(new DigitCommand(digit));
        }

        private void OnPointClicked(object sender, EventArgs e)
        {
            this.InputDevice.Notify(PointCommand.Instance);
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            this.InputDevice.Notify(new ClearCommand());
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var @operator = btn.Tag.ToString();
            this.InputDevice.Notify(new OperatorCommand(@operator));
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {
            this.InputDevice.Notify(new EqualsCommand());
        }

    }


    public class CommandFeeder : ICommandSubject
    {
        private List<ICommandObserver> _observers = new List<ICommandObserver>();

        public void Attach(ICommandObserver observer)
        {
            if (_observers.Contains(observer) == false)
                _observers.Add(observer);
        }

        public void Detach(ICommandObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(ICommand command)
        {
            _observers.ForEach(o => o.Notify(command));
        }
    }

    public class TextBoxDisplayDevice : IDisplayDevice
    {
        public TextBoxDisplayDevice(TextBox textBox)
        {
            this.Out = textBox;
        }

        public TextBox Out { get; set; }

        public void Print(string text)
        {
            this.Out.Text = text;
        }
    }
}
