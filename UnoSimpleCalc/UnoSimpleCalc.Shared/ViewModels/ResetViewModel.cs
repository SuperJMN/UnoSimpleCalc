using System.Reactive;
using ReactiveUI;
using UnoSimpleCalc.Core;
using UnoSimpleCalc.ViewModels;

namespace UnoSimpleCalc
{
    public class ClearViewModel : ButtonViewModelBase
    {
        public ClearViewModel(ICalculator calculator) : base(calculator)
        {
            Text = "C";
            Execute = ReactiveCommand.Create(() =>
            {
                calculator.Clear();
                return Unit.Default;
            });
        }
    }
}