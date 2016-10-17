namespace CS_OOP_Advanced_Exam_Prep_July_2016.IO
{
    using System;
    using Contracts;
    using Lifecycle.Component;

    [Component]
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
