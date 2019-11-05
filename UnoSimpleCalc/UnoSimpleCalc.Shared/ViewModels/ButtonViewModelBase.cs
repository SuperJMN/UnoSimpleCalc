using System;
using UnoMvvm;

namespace UnoSimpleCalc.ViewModels
{
    public class ButtonViewModelBase : DelegateCommand
    {
        public string Text { get; private protected set; }
        private readonly Action _postAction;
        public ButtonViewModelBase(Action postAction, string text, Action executeMethod) : this(postAction, text, executeMethod, () => true)
        {
        }

        public ButtonViewModelBase(Action postAction, string text, Action executeMethod, Func<bool> canExecuteMethod) : base(executeMethod, canExecuteMethod)
        {
            _postAction = postAction;
            Text = text;
        }

        protected override void Execute(object parameter)
        {
#if __WASM__
            Console.WriteLine($"Pressed {Text}");
#endif

            base.Execute(parameter);
            _postAction();
        }
    }
}