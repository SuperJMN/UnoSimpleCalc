using ReactiveUI;
using UnoSimpleCalc.Core;
using UnoSimpleCalc.ViewModels;

namespace UnoSimpleCalc
{
    public class OperationViewModel : ButtonViewModelBase
    {
        public OperationViewModel(Operator op, ICalculator calculator) : base(calculator)
        {
            Text = op.Symbol.ToString();
            Execute = ReactiveCommand.Create(() => calculator.ApplyOperator(op));
        }
    }
}