namespace Problem_04.Work_Force.Events
{
    using System;
    public class JobEventArgs :EventArgs
    {
        public JobEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
