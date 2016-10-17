namespace Problem_02.Black_Box_Integer
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        private static void Main(string[] args)
        {
            var type = typeof(BlackBoxInt);
            var contructor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, default(CallingConventions), Type.EmptyTypes, null);
            var blackBox = contructor.Invoke(new object[] { });

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                var commandParams = input.Split('_');
                var innerValue = int.Parse(commandParams[1]);             
                var method = type.GetMethod(commandParams[0], BindingFlags.NonPublic | BindingFlags.Instance);
                method.Invoke(blackBox, new object[] { innerValue });
                var field = (int)type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault().GetValue(blackBox);
                Console.WriteLine(field);
            }
        }
    }

    class BlackBoxInt
    {
        private static int DefaultValue = 0;

        private int innerValue;

        private BlackBoxInt(int innerValue)
        {
            this.innerValue = innerValue;
        }

        private BlackBoxInt()
        {
            this.innerValue = DefaultValue;
        }

        private void Add(int addend)
        {
            this.innerValue += addend;
        }

        private void Subtract(int subtrahend)
        {
            this.innerValue -= subtrahend;
        }

        private void Multiply(int multiplier)
        {
            this.innerValue *= multiplier;
        }

        private void Divide(int divider)
        {
            this.innerValue /= divider;
        }

        private void LeftShift(int shifter)
        {
            this.innerValue <<= shifter;
        }

        private void RightShift(int shifter)
        {
            this.innerValue >>= shifter;
        }
    }
}
