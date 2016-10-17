namespace Problem_01.Logger.Models
{
    using System;

    using Problem_01.Logger.Enums;
    using Problem_01.Logger.Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, ThresholdLevel level)
            : base(layout, level)
        {
        }

        public override void Append(DateTime date, ThresholdLevel level, string message)
        {
            base.Append(date, level, message);
            if (this.Level > level)
            {
                return;
            }

            var format = base.Layout.Format(date, level, message);
            Console.WriteLine(format);
        }
    }
}
