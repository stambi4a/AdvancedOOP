namespace Problem_03.Dependency_Inversion_Skeleton
{
    public class AdditionStrategy : ICalculateStrategy
    {

        private const char AdditionOperatorSymbol = '+';
        public AdditionStrategy()
        {
            this.Operator = AdditionOperatorSymbol;
        }

        public char Operator { get; }

        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
