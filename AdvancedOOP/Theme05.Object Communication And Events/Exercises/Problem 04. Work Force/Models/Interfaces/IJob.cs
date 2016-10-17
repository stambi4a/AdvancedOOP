namespace Problem_04.Work_Force.Models.Interfaces
{
    using System;

    using Problem_04.Work_Force.Events;

    public interface IJob
    {
        event JobEventHandler JobDone;

        IEmployee Employee { get; }

        void Update(object sender, EventArgs args);
    }
}
