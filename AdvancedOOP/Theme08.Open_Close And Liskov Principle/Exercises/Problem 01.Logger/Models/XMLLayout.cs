namespace Problem_01.Logger.Models
{
    using System;
    using System.Text;

    using Enums;

    public class XmlLayout : Layout
    {
        public override string Format(DateTime date, ThresholdLevel level, string message)
        {
            var builder = new StringBuilder();
            builder.Append("<log>").AppendLine();
            builder.Append("    <date>").Append(date).Append("</date>").AppendLine();
            builder.Append("    <level>").Append(level).Append("</level>").AppendLine();
            builder.Append("    <message>").Append(message).Append("</message>").AppendLine();
            builder.Append("</log>").AppendLine();

            return builder.ToString();
        }
    }
}
