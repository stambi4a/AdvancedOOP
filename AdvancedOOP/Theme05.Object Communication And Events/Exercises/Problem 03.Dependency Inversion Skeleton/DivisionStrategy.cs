namespace Problem_03.Dependency_Inversion_Skeleton
{
    public class DivisionStrategy : ICalculateStrategy
    {
        private const char DivisionOperatorSymbol = '/';
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }

        public char Operator { get; }

        public DivisionStrategy()
        {
            this.Operator = DivisionOperatorSymbol;
        }
    }
}
