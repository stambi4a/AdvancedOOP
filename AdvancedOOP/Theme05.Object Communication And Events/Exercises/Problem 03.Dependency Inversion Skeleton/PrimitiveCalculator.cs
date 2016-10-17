namespace Problem_03.Dependency_Inversion_Skeleton
{
    using System.Collections.Generic;
    using System.Linq;

    public class PrimitiveCalculator
    {
        private readonly IEnumerable<ICalculateStrategy> strategies;

        private ICalculateStrategy currentStrategy;
        public PrimitiveCalculator(IEnumerable<ICalculateStrategy> strategies)
        {
            this.strategies = strategies;
            this.InitializeStrategy();
        }
        
        public void ChangeStrategy(char @operator)
        {
            this.currentStrategy = this.strategies.FirstOrDefault(strat => strat.Operator == @operator);
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            var result = this.currentStrategy.Calculate(firstOperand, secondOperand);

            return result;
        }

        private void InitializeStrategy()
        {
            this.currentStrategy = this.strategies.FirstOrDefault(strat => strat.Operator == '+');
        }
    }
}
