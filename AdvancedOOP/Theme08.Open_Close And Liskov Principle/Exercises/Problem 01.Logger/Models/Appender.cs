namespace Problem_01.Logger.Models
{
    using System;
    using System.Text;

    using Problem_01.Logger.Enums;
    using Problem_01.Logger.Interfaces;

    public abstract class Appender :IAppender
    {
        protected Appender(ILayout layout, ThresholdLevel level)
        {
            this.Layout = layout;
            this.Level = level;
        }
        public ILayout Layout { get; }

        public ThresholdLevel Level { get; }

        public int MessageCount { get; protected set; }

        public virtual void Append(DateTime date, ThresholdLevel level, string message)
        {
            this.MessageCount ++;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level}, Messages appended: {this.MessageCount}");

            return builder.ToString();
        }
    }
}
