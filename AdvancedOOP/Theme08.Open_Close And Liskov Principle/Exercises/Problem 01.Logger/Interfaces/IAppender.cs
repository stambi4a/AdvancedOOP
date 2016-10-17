namespace Problem_01.Logger.Interfaces
{
    using System;

    using Problem_01.Logger.Enums;

    public interface IAppender
    {
        ILayout Layout { get; }

        ThresholdLevel Level { get; }

        int MessageCount { get; }

        void Append(DateTime date, ThresholdLevel level, string message);
    }
}
