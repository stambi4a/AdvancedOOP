namespace Problem_01.Logger
{
    using System;

    using Problem_01.Logger.Enums;
    using Problem_01.Logger.Interfaces;
    using Problem_01.Logger.Models;

    public class Program
    {
        private static void Main(string[] args)
        {
            var appenderCount = int.Parse(Console.ReadLine());
            var logger = new Logger();
            for (var i = 0; i < appenderCount; i++)
            {
                var input = Console.ReadLine().Split();
                var appenderName = input[0];
                var layoutName = input[1];
                var level = ThresholdLevel.Info;
                if (input.Length == 3)
                {
                    level = (ThresholdLevel)Enum.Parse(typeof(ThresholdLevel), input[2], true);
                }

                var type = Type.GetType("Problem_01.Logger.Models." + layoutName);
                var layout = Activator.CreateInstance(type);
                type = Type.GetType("Problem_01.Logger.Models." + appenderName);
                var appender = (IAppender)Activator.CreateInstance(type, new object[] { layout, level });
                logger.AddAppender(appender);
            }

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }

                var input = line.Split('|');
                var date = DateTime.Parse(input[1]);
                var level = (ThresholdLevel)Enum.Parse(typeof(ThresholdLevel), input[0], true);
                var message = input[2];
                logger.LogMessage(date, level, message);
            }

            Console.WriteLine(logger);
        }
    }
}
