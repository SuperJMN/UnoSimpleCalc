using System.Reactive;
using ReactiveUI;
using UnoSimpleCalc.Core;
using UnoSimpleCalc.ViewModels;

namespace UnoSimpleCalc
{
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
}