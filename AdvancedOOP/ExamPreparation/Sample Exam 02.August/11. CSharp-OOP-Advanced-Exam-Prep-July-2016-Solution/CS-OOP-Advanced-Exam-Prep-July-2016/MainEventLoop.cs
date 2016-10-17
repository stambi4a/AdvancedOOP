namespace CS_OOP_Advanced_Exam_Prep_July_2016
{
    using System;
    using Contracts;
    using Lifecycle.Component;
    using Lifecycle.Request;

    [Component]
    public class MainEventLoop : IRunnable
    {
        [Inject]
        private IReader reader;

        [Inject]
        private IWriter writer;

        [Inject]
        private IDispatcher dispatcher;

        private const string EndLine = "ILIENCI";

        public void Run()
        {
            string command = reader.ReadLine();
            while (command != "ILIENCI")
            {
                string[] tokens = command.Split();
                RequestMethod requestMethod = (RequestMethod)Enum.Parse(typeof(RequestMethod), tokens[0]);
                string uri = tokens[1];
                string result = dispatcher.Dispatch(requestMethod, uri);
                this.writer.WriteLine(result);
                command = reader.ReadLine();
            }
        }
    }
}
