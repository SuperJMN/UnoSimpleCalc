namespace UnoSimpleCalc.Core
{
    public interface ICalculator
    {
        string TextInput { get; }
        double Result { get; }
        void AppendDigit(int digit);
        void SetDecimal();
        void Evaluate();
        void ApplyOperator(Operator op);
        void Negate();
        void Clear();
        void CancelEntry();
    }
}