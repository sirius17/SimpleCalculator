using SimpleCalculator.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Core
{
    public class Accumulator : IAccumulator
    {
        public ICpu CPU { get; set; }

        private string _backingField = string.Empty;

        public bool TryGetValue(out decimal value)
        {
            value = decimal.Zero;
            if (string.IsNullOrWhiteSpace(_backingField) == true)
                return false;
            else
            {
                value = decimal.Parse(_backingField);
                return true;
            }
        }

        public bool IsEmpty
        {
            get { return string.IsNullOrWhiteSpace(_backingField); }
        }

        public void Append(string @char)
        {
            //TODO: Check for digits and point
            _backingField += @char.ToString();
        }

        public override string ToString()
        {
            return _backingField;
        }


        public void Clear()
        {
            _backingField = string.Empty;
        }


        public void SetValue(decimal value)
        {
            _backingField = value.ToString();
        }
    }
}
