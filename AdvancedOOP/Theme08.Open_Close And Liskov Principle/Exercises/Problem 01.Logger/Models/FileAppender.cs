namespace Problem_01.Logger.Models
{
    using System;
    using System.IO;

    using Enums;
    using Interfaces;

    public class FileAppender : Appender
    {
        private readonly string pathFile;
        private int fileSize;
        private const string DefaultPathFile = "log.xml";

        public FileAppender(ILayout layout, ThresholdLevel level)
            : base(layout, level)
        {
            this.pathFile = DefaultPathFile;
        }

        public FileAppender(ILayout layout, ThresholdLevel level, string path)
            : base(layout, level)
        {
            this.pathFile = path;
        }

        public override void Append(DateTime date, ThresholdLevel level, string message)
        {
            base.Append(date, level, message);

            if (this.Level > level)
            {
                return;
            }

            using (var fs = new StreamWriter(this.pathFile))
            {
                var format = base.Layout.Format(date, level, message);
                foreach (var letter in format)
                {
                    this.fileSize += letter;
                }

                fs.Write(format);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.fileSize}";
        }
    }
}
