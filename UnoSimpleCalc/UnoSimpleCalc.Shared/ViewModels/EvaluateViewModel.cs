using ReactiveUI;
using UnoSimpleCalc.Core;
using UnoSimpleCalc.ViewModels;

namespace UnoSimpleCalc
{
    public class EvaluateViewModel : ButtonViewModelBase
    {
        public EvaluateViewModel(ICalculator calculator) : base(calculator)
        {
            Text = "=";
            Execute = ReactiveCommand.Create(calculator.Evaluate);
        }
    }
}