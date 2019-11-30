using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.UnderTest
{
    class Calculator
    {
        private List<double> numbers = new List<double>();

        public double Result { get; private set; }

        public void EnterNumber(double number)
        {
            if (numbers.Count == 2)
            {
                numbers.RemoveAt(0);
            }

            numbers.Add(number);
        }

        public void Operate(string operatorType)
        {
            switch (operatorType)
            {
                case "add":
                    Result = numbers.Sum();
                    break;
                case "subtract":
                    Result = numbers[0] - numbers[1];
                    break;
                case "mutiply":
                    Result = numbers[0] * numbers[1];
                    break;
                case "divide":
                    Result = numbers[0] / numbers[1];
                    break;
            }
        }
    }
     
}
