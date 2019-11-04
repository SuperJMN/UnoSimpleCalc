using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using ReactiveUI;
using UnoSimpleCalc.Core;

namespace UnoSimpleCalc.ViewModels
{
    public class CalcViewModel : ReactiveObject
    {
        private double result;

        public CalcViewModel(ICalculator calculator)
        {
            Digits = new List<ButtonViewModelBase>
            {
                new ClearViewModel(calculator),
                new CancelEntryViewModel(calculator),
                new NothingViewModel(calculator),
                new OperationViewModel(Operator.Division, calculator),

                new ButtonViewModel(7, calculator),
                new ButtonViewModel(8, calculator),
                new ButtonViewModel(9, calculator),
                
                new OperationViewModel(Operator.Multiplication, calculator),

                new ButtonViewModel(4, calculator),
                new ButtonViewModel(5, calculator),
                new ButtonViewModel(6, calculator),
                new OperationViewModel(Operator.Subtract, calculator),

                new ButtonViewModel(1, calculator),
                new ButtonViewModel(2, calculator),
                new ButtonViewModel(3, calculator),
                new OperationViewModel(Operator.Add, calculator),

                new ButtonViewModel(0, calculator),
                new DecimalViewModel(calculator),
                new NegateViewModel(calculator),
                new EvaluateViewModel(calculator),
            };

            var commandExecution = Digits.Select(x => x.Execute).Merge();
            commandExecution.Subscribe(_ => Result = calculator.DisplayResult);
        }

        public double Result
        {
            get => result;
            set => this.RaiseAndSetIfChanged(ref result, value);
        }

        public List<ButtonViewModelBase> Digits { get; }
    }
}