using System;
using System.Collections.Generic;
using System.Globalization;
using UnoMvvm;
using UnoSimpleCalc.Core;

namespace UnoSimpleCalc.ViewModels
{
    public class CalcViewModel : BindableBase
    {
        private double _result;

        public CalcViewModel(ICalculator calculator)
        {
            void PostAction() => Result = calculator.DisplayResult;

            ButtonViewModelBase AddNumber(int n) =>
                new ButtonViewModelBase(PostAction, n.ToString(), () => calculator.AppendDigit(n));

            ButtonViewModelBase AddOperation(Operator op) => new ButtonViewModelBase(PostAction, op.Symbol.ToString(),
                () => calculator.ApplyOperator(op));

            ButtonViewModelBase Add(string text, Action action) => new ButtonViewModelBase(PostAction, text, action);
            var numberFormat = CultureInfo.CurrentCulture.NumberFormat;
            Digits = new List<ButtonViewModelBase>
            {
                Add("C", calculator.Clear),
                Add("CE", calculator.CancelEntry),
                Add("", () => { }),
                AddOperation(Operator.Division),

                AddNumber(7),
                AddNumber(8),
                AddNumber(9),

                AddOperation(Operator.Multiplication),

                AddNumber(4),
                AddNumber(5),
                AddNumber(6),
                AddOperation(Operator.Subtract),

                AddNumber(1),
                AddNumber(2),
                AddNumber(3),
                AddOperation(Operator.Add),

                AddNumber(0),
                Add(numberFormat.NumberDecimalSeparator, calculator.SetDecimal),
                Add(numberFormat.NegativeSign, calculator.Negate),
                Add("=", calculator.Evaluate)
            };
        }

        public double Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        public List<ButtonViewModelBase> Digits { get; }
    }
}