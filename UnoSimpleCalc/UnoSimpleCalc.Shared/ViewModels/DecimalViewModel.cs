using System.Globalization;
using ReactiveUI;
using UnoSimpleCalc.Core;
using UnoSimpleCalc.ViewModels;

namespace UnoSimpleCalc
{
    public class DecimalViewModel : ButtonViewModelBase
    {
        public DecimalViewModel(ICalculator calculator) : base(calculator)
        {
            Text = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            Execute = ReactiveCommand.Create(calculator.SetDecimal);
        }
    }
}