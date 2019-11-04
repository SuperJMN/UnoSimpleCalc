using ReactiveUI;
using UnoSimpleCalc.Core;
using UnoSimpleCalc.ViewModels;

namespace UnoSimpleCalc
{
    public class NothingViewModel : ButtonViewModelBase
    {
        public NothingViewModel(ICalculator calculator) : base(calculator)
        {
            Text = "";
            Execute = ReactiveCommand.Create(() => { });
        }
    }
}