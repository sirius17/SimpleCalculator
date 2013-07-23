using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculator.Tests
{
    class Sample
    {
        public void Run()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            foreach (var num in numbers)
                Console.WriteLine(num);
        }
    }
}
