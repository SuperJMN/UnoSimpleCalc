namespace UnoSimpleCalc.Core
{
    public class Operator
    {
        public char Symbol { get; }
        public OperatorKind Kind { get; }

        public Operator(char symbol, OperatorKind kind)
        {
            Symbol = symbol;
            Kind = kind;
        }

        public static readonly Operator None = new Operator('#', OperatorKind.None);
        public static readonly Operator Add = new Operator('+', OperatorKind.Add);
        public static readonly Operator Subtract = new Operator('-', OperatorKind.Subtract);
        public static readonly Operator Multiplication = new Operator('*', OperatorKind.Multiplication);
        public static readonly Operator Division = new Operator('/', OperatorKind.Division);

    }

    public enum OperatorKind
    {
        None,
        Add,
        Subtract,
        Multiplication,
        Division
    }
}