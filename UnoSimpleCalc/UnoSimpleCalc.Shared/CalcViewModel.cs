using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using UnoSimpleCalc.Core;

namespace UnoSimpleCalc
{
    public class CalcViewModel : ReactiveObject
    {
        private string textInput;

        public CalcViewModel(ICalculator calculator)
        {
            Digits = new List<ButtonViewModelBase>
            {
                new ResetViewModel(calculator),
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
                new NothingViewModel(calculator),
                new NothingViewModel(calculator),
                new EvaluateViewModel(calculator),
            };

            var commandExecution = Digits.Select(x => x.Execute).Merge();
            commandExecution.Subscribe(_ => TextInput = calculator.TextInput);
        }

        public string TextInput
        {
            get => textInput;
            set => this.RaiseAndSetIfChanged(ref textInput, value);
        }

        public List<ButtonViewModelBase> Digits { get; }
    }

    public class NothingViewModel : ButtonViewModelBase
    {
        public NothingViewModel(ICalculator calculator) : base(calculator)
        {
            Text = "";
            Execute = ReactiveCommand.Create(() => { });
        }
    }

    public class ResetViewModel : ButtonViewModelBase
    {
        public ResetViewModel(ICalculator calculator) : base(calculator)
        {
            Text = "C";
            Execute = ReactiveCommand.Create(() =>
            {
                calculator.Clear();
                return Unit.Default;
            });
        }
    }


    public class EvaluateViewModel : ButtonViewModelBase
    {
        public EvaluateViewModel(ICalculator calculator) : base(calculator)
        {
            Text = "=";
            Execute = ReactiveCommand.Create(calculator.Evaluate);
        }
    }

    public class OperationViewModel : ButtonViewModelBase
    {
        public OperationViewModel(Operator op, ICalculator calculator) : base(calculator)
        {
            Text = op.Symbol.ToString();
            Execute = ReactiveCommand.Create(() => calculator.ApplyOperator(op));
        }
    }

    public class CancelEntryViewModel : ButtonViewModelBase
    {
        public CancelEntryViewModel(ICalculator calculator) : base(calculator)
        {
            Text = "CE";
            Execute = ReactiveCommand.Create(() =>
            {
                calculator.CancelEntry();
                return Unit.Default;
            });
        }
    }

    public abstract class ButtonViewModelBase
    {
        public ICalculator Calculator { get; }

        public ButtonViewModelBase(ICalculator calculator)
        {
            Calculator = calculator;
        }

        public string Text { get; private protected set; }
        public ReactiveCommand<Unit, Unit> Execute { get; private protected set; }
    }

    public class ButtonViewModel : ButtonViewModelBase
    {
        public ButtonViewModel(int value, ICalculator calculator) : base(calculator)
        {
            Text = value.ToString();
            Execute = ReactiveCommand.Create(() => calculator.AppendDigit(value));
        }
    }
}