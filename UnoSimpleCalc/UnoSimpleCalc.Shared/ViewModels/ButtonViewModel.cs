using ReactiveUI;
using UnoSimpleCalc.Core;

namespace UnoSimpleCalc.ViewModels
{
    public class ButtonViewModel : ButtonViewModelBase
    {
        public ButtonViewModel(int value, ICalculator calculator) : base(calculator)
        {
            Text = value.ToString();
            Execute = ReactiveCommand.Create(() => calculator.AppendDigit(value));
        }
    }
}