namespace Problem_04.Work_Force.Models
{
    using System;

    using Problem_04.Work_Force.Events;
    using Problem_04.Work_Force.Models.Interfaces;
    public class Job : IJob
    {
        public event JobEventHandler JobDone;
        private string name;
        private int workHours;
        public Job(string name, int workHours, IEmployee employee)
        {
            this.name = name;
            this.workHours = workHours;
            this.Employee = employee;
            
        }
        public IEmployee Employee { get; }

        public void Update(object sender, EventArgs args)
        {
            this.workHours -= this.Employee.WorkHoursPerWeek;
            if (this.workHours <= 0)
            {
                this.OnJobDone(new JobEventArgs(this.name));
            }
        }

        public void OnJobDone(JobEventArgs jea)
        {
            this.JobDone?.Invoke(this, jea);
        }

        public override string ToString()
        {
            return $"Job: {this.name} Hours Remaining: {this.workHours}";
        }
    }
}
