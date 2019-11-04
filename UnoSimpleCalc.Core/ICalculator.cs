namespace UnoSimpleCalc.Core
{
    public interface ICalculator
    {
        double Result { get; }
        double DisplayResult { get; }
        void AppendDigit(int digit);
        void SetDecimal();
        void Evaluate();
        void ApplyOperator(Operator op);
        void Negate();
        void Clear();
        void CancelEntry();
    }
}