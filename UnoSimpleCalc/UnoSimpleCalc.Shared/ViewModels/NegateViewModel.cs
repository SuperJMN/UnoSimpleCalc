using System.Globalization;
using ReactiveUI;
using UnoSimpleCalc.Core;

namespace UnoSimpleCalc.ViewModels
{
    public class NegateViewModel : ButtonViewModelBase
    {
        public NegateViewModel(ICalculator calculator) : base(calculator)
        {
            Text = CultureInfo.CurrentCulture.NumberFormat.NegativeSign;
            Execute = ReactiveCommand.Create(calculator.Negate);
        }
    }
}