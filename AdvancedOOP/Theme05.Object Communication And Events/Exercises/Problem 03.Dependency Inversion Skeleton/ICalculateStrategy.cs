namespace Problem_03.Dependency_Inversion_Skeleton
{
    public interface ICalculateStrategy
    {
        int Calculate(int firstOperand, int secondOperand);

        char Operator { get; }
    }
}
