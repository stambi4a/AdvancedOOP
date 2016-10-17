namespace Problem_01.Logger.Interfaces
{
    using System;

    using Problem_01.Logger.Enums;

    public interface ILayout
    {
        string Format(DateTime date, ThresholdLevel level, string message);
    }
}
