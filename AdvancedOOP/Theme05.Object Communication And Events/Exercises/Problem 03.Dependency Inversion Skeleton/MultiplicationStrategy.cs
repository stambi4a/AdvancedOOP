namespace Problem_03.Dependency_Inversion_Skeleton
{
    public class MultiplicationStrategy : ICalculateStrategy
    {
        private const char MultiplicationOperatorSymbol = '*';
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }

        public char Operator { get; }

        public MultiplicationStrategy()
        {
            this.Operator = MultiplicationOperatorSymbol;
        }
    }
}
