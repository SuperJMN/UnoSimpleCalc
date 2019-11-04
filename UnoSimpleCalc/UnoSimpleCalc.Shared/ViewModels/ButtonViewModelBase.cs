using System.Reactive;
using ReactiveUI;
using UnoSimpleCalc.Core;

namespace UnoSimpleCalc.ViewModels
{
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
}