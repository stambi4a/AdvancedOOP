namespace Problem_01.Logger.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Problem_01.Logger.Enums;

    public interface ILogger
    {
        ISet<IAppender> Appenders { get; }

        void LogMessage(DateTime date, ThresholdLevel level, string message);

        void AddAppender(IAppender appender);
    }
}
