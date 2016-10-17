namespace Problem_03.Dependency_Inversion_Skeleton
{
    public class SubtractionStrategy : ICalculateStrategy
    {
        private const char SubtractionOperatorSymbol = '-';
       
        public SubtractionStrategy()
        {
            this.Operator = SubtractionOperatorSymbol;
        }

        public char Operator { get; }

        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
