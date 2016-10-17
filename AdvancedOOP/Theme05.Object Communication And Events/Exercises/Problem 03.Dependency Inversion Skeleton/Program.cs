namespace Problem_03.Dependency_Inversion_Skeleton
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Program
    {
        private static void Main(string[] args)
        {
            var strategyTypes =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(
                        type => typeof(ICalculateStrategy).IsAssignableFrom(type)).Where(type=>type.IsClass).ToList();
            var strategies = strategyTypes.Select(type=>(ICalculateStrategy)Activator.CreateInstance(type));
            var primitiveCalculator = new PrimitiveCalculator(strategies);

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var calculatorParams = input.Split();
                if (calculatorParams[0] == "mode")
                {
                    primitiveCalculator.ChangeStrategy(calculatorParams[1][0]);
                }
                else
                {
                    var firstOperand = int.Parse(calculatorParams[0]);
                    var secondOperand = int.Parse(calculatorParams[1]);
                    var result = primitiveCalculator.PerformCalculation(firstOperand, secondOperand);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
