namespace Problem_01.Logger.Models
{
    using System;
    using System.Text;

    using Enums;

    public class SimpleLayout : Layout
    {
        public override string Format(DateTime date, ThresholdLevel level, string message)
        {
            var builder = new StringBuilder();
            builder.Append($"{date} - {level} - {message}");

            return builder.ToString();
        }
    }
}
