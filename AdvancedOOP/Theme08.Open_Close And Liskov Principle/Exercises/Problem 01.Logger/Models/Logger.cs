namespace Problem_01.Logger.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Enums;
    using Interfaces;
    public class Logger : ILogger
    {
        public Logger()
        {
            this.Appenders = new HashSet<IAppender>();
        }
        public ISet<IAppender> Appenders { get; }

        public void LogMessage(DateTime date, ThresholdLevel level, string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(date, level, message);
            }
        }

        public void AddAppender(IAppender appender)
        {
            this.Appenders.Add(appender);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Logger info");
            foreach (var appender in this.Appenders)
            {
                builder.AppendLine(appender.ToString());
            }

            return builder.ToString();
        }
    }
}
