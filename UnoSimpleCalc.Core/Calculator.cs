using System;
using System.Globalization;

namespace UnoSimpleCalc.Core
{
    public class Calculator : ICalculator
    {
        private double decimalPosition;
        private Operator currentOperation = Operator.None;
        private double result;
        private double temp;
        private double working;
        private bool isNegate;
        private bool isDecimal;
        public string TextInput
        {
            get
            {
                var display = working != 0 ? working : result != 0 ? result : temp;
                return display.ToString(CultureInfo.InvariantCulture);
            }
        }

        public void AppendDigit(int digit)
        {
            if (digit < 0 || digit > 10)
            {
                throw new ArgumentException(nameof(digit));
            }

            if (!isDecimal)
            {
                working = working * 10 + digit;
            }
            else
            {
                working += digit / (10 * Math.Pow(10, decimalPosition));
                decimalPosition++;
            }
        }

        public void SetDecimal()
        {
            isDecimal = true;
            decimalPosition = 0;
        }

        public void Evaluate()
        {
            switch (currentOperation.Kind)
            {
                case OperatorKind.Add:
                    result = temp + working;
                    break;
                case OperatorKind.Subtract:
                    result = temp - working;
                    break;
                case OperatorKind.Multiplication:
                    result = temp * working;
                    break;
                case OperatorKind.Division:
                    result = temp / working;
                    break;

                case OperatorKind.None:
                    result = working;
                    break;
            }

            CancelEntry();
        }

        public void CancelEntry()
        {
            currentOperation = Operator.None;
            isNegate = false;
            isDecimal = false;
            working = 0;
        }

        public void Clear()
        {
            CancelEntry();
            result = 0;
            temp = 0;
        }

        public double Result => result;

        public void ApplyOperator(Operator op)
        {
            if (currentOperation.Kind != OperatorKind.None)
            {
                Evaluate();
            }

            currentOperation = op;
            temp = working + result;
            working = 0;
            decimalPosition = 0;
        }

        public void Negate()
        {
            isNegate = !isNegate;
            working = -working;
        }
    }
}