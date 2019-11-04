using System;

namespace UnoSimpleCalc.Core
{
    public class Calculator : ICalculator
    {
        private double decimalPosition;
        private Operator currentOperation = Operator.None;
        private double working;
        private bool isNegate;
        private bool isDecimal;
        private double result;
        public double Result => result;
        public double DisplayResult => working != 0 ? working : result;

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
            result = Evaluate(currentOperation, result, working);
            CancelEntry();
            currentOperation = Operator.None;
        }

        public void CancelEntry()
        {
            working = 0;
            ResetFlags();
        }

        public void Clear()
        {
            working = 0;
            result = 0;
            
            ResetFlags();
        }

        public void ApplyOperator(Operator op)
        {
            if (currentOperation.Kind != OperatorKind.None)
            {
                result = Evaluate(currentOperation, result, working);
            }
            else
            {
                result = working;
            }

            ResetFlags();
            working = 0;
            currentOperation = op;
        }

        private void ResetFlags()
        {
            isDecimal = false;
            isNegate = false;
            decimalPosition = 0;
        }

        private double Evaluate(Operator op, double a, double b)
        {
            switch (op.Kind)
            {
                case OperatorKind.Add:
                    return a + b;
                case OperatorKind.Subtract:
                    return a - b;
                case OperatorKind.Multiplication:
                    return a * b;
                case OperatorKind.Division:
                    return a / b;
                case OperatorKind.None:
                    return b;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Negate()
        {
            isNegate = !isNegate;
            working = -working;
        }
    }
}