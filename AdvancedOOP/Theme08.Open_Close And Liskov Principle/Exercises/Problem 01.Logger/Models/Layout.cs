namespace Problem_01.Logger.Models
{
    using System;

    using Interfaces;

    using Problem_01.Logger.Enums;

    public abstract class Layout : ILayout
    {
        public abstract string Format(DateTime date, ThresholdLevel level, string message);
    }
}